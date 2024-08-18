import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Pusher, { Channel } from 'pusher-js';
import { subscribeOn } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PusherService {
  private pusher: Pusher;
  private channels: Channel;

  constructor(
    private _http: HttpClient
  ) {
    this.pusher = new Pusher('8a829afa7dcf355c9ab8', {
      cluster: 'sa1',
    });
    this.channels= this.pusher.subscribe('my-channel')
  }bindEvent(eventName: string, callback: (data: any) => void): void {
    this.channels.bind(eventName, callback);
  }

  unbindEvent(eventName: string): void {
    this.channels.unbind(eventName);
  }
 /*  [{"mesa":1, "estado":1, "cantidad":2, "Productos":{"id":1,"nombre":"hamburgues", "precio":12.00 }, "empleado":2},
    {"mesa":2, "estado":1, "cantidad":4, "Productos":{"id":1,"nombre":"hamburgues", "precio":12.00 }, "empleado":2},
    {"mesa":3, "estado":1, "cantidad":5, "Productos":{"id":1,"nombre":"hamburgues", "precio":12.00 }, "empleado":2}] */

}
