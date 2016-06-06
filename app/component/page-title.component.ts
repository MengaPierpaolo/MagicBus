import { Component } from '@angular/core';
import { HomeViewModel } from '../model/homeViewModel';

@Component ({
    selector: 'page-title',
    template: `
    <div class="jumbotron">
      <h1>{{pageDetails.Title}}</h1>
      <h2>{{pageDetails.SubTitle}}</h2>
    </div>
    `
})
export class PageTitleComponent
{
  pageDetails: HomeViewModel = {
    Title: "Magic Bus",
    SubTitle: "Your groovy new travel diary - In Angular 2!"
  }
}