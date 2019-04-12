import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DuckbillsComponent } from './duckbills.component';

import { DuckbillsListComponent } from './duckbills-list/duckbills-list.component';
import { DuckbillsEditComponent } from './duckbills-edit/duckbills-edit.component';

const routes: Routes = [
  {
    path: '', component: DuckbillsComponent, data: { navArea: 'duckbill' },
    children: [
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: DuckbillsListComponent },
      //{ path: 'edit/:id', component: DuckbillsEditComponent },
      { path: 'edit', component: DuckbillsEditComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DuckbillsRoutingModule {
  static routedComponents = [DuckbillsComponent, DuckbillsListComponent, DuckbillsEditComponent];
}
