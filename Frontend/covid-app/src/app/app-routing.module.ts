import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCovidComponent } from './list-covid/list-covid.component'

const routes: Routes = [{
  path: '', component: ListCovidComponent,
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
