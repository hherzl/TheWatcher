import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  /** Based on the screen size, switch from standard to one column per row */
  cards = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(({ matches }) => {
      if (matches) {
        return [
          { title: 'Card 1', cols: 1, rows: 1 },
          { title: 'Card 2', cols: 1, rows: 1 },
          { title: 'Card 3', cols: 1, rows: 1 },
          { title: 'Card 4', cols: 1, rows: 1 }
        ];
      }

      return [
        { title: 'Card 1', cols: 2, rows: 1 },
        { title: 'Card 2', cols: 1, rows: 1 },
        { title: 'Card 3', cols: 1, rows: 2 },
        { title: 'Card 4', cols: 1, rows: 1 }
      ];
    })
  );

  constructor(private breakpointObserver: BreakpointObserver) { }

  private hubConnection!: signalR.HubConnection;

  ngOnInit(): void {
    this.hubConnection = new signalR
      .HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Debug)
      .withUrl('https://localhost:13003/monitorhub')
      .build()
      ;

    this
      .hubConnection
      .start()
      .then(() => {
        console.log('Connection started!');
      })
      .catch(err => console.log(`Error while starting connection: ${err}`))
      ;

    this.hubConnection.on('receiveResourceWatch', (notification: ResourceWatchArg) => {
      console.log(notification);
    });
  }
}

export class ResourceWatchArg {
  public resource!: string;
  public isSuccess!: boolean;
}
