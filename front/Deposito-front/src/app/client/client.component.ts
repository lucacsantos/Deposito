import { Component, OnInit } from '@angular/core';
import { Client } from '../models/Client';
import { ClientService } from '../services/client-service/client.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css'],
  imports: [CommonModule]
})
export class ClientComponent implements OnInit {
  public clients : Client[] = [];
  public clientList : Client[] = [];

  private _filterList : string = '';

  public get filterList(): string{
    return this._filterList;
  }

  public set filterList(value : string) {
    this._filterList = value;
    this.clientList = this.filterList ? this.filterClient(this.filterList) : this.clients;
  }

  constructor(private clientService : ClientService) { }

  ngOnInit() {
    this.getClients()
  }

  public filterClient(filter: string): Client[] {
    filter = filter.toLocaleLowerCase();
    return this.clients.filter((
      client: {lastName: string}) => client.lastName.toLocaleLowerCase().indexOf(filter)  !== -1 )
  }

  public getClients(): void {
    const oberserver = {
      next:(response: Client[]) => {
        this.clients = response;
        this.clientList = this.clients;
      },
      error: (error: any) => console.log(error)
    };
    this.clientService.getClients().subscribe(oberserver);
  }
}
