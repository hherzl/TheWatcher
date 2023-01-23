import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { WatcherListComponent } from './components/watcher-list/watcher-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'watcher', component: WatcherListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
