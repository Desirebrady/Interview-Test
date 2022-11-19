import { Component, OnInit } from '@angular/core';
import { first, tap } from 'rxjs/operators';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  Heroes = [];
  updateHero?: any;
  colors = ['blue', 'green', 'yellow', 'purple']

  constructor(private _apiService: ApiService) {
  }

  ngOnInit(): void {
    this.initData();
  }

  initData(): void {
    this._apiService.get().pipe(first(), tap(Heroes => {
      this.Heroes = Heroes;
    })).subscribe();
  }

  getHeroesStats(key: string, data: any[]): string {
    return data.find(stat => stat.key === key).value;
  }

  getColors(): string {
    return this.colors[Math.floor(Math.random() * 4)];
  }

  handleEvovle(name: string, hero: any): void {
    this._apiService.evolve(name).pipe(first(), tap(result => {
      this.updateHero = result;
      this.initData();
    })).subscribe();
  }

  delete(id : number): void {
    this._apiService.delete(id).pipe(first(), tap(_ => this.initData())).subscribe();
  }
}
