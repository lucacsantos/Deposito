import { Component, inject, OnInit, TemplateRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import { RouterLink } from "@angular/router";
import { ClientService } from '../../services/client-service/client.service';
import { Client } from '../../models/Client';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef, BsModalService, ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css'],
  imports: [CommonModule, MatButtonModule, MatMenuModule, RouterLink, ModalModule, TooltipModule]
})
export class ClientComponent implements OnInit {
  public clients : Client[] = [];
  public clientList : Client[] = [];
  clientDelete?: string;
  modalRef?: BsModalRef;
  message?: string;

  private _filterList : string = '';
   private _snackBar = inject(MatSnackBar);

  public get filterList(): string{
    return this._filterList;
  }

  public set filterList(value : string) {
    this._filterList = value;
    this.clientList = this.filterList ? this.filterClient(this.filterList) : this.clients;
  }

  constructor(private clientService : ClientService, private modalService: BsModalService) { }

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

openModal(template: TemplateRef<void>, id: string) {
  this.clientDelete = id;
  this.modalRef = this.modalService.show(template, {class:'modal-sm'});
}
 
confirmDelete() {
  if (!this.clientDelete) return;

 this.clientService.delete(this.clientDelete).subscribe({
    next: () => {
      this.clientList = this.clients.filter(c => c.id !== this.clientDelete);

      this._snackBar.open('Cliente deletado com sucesso!', 'Fechar',{
      duration: 3000,
      horizontalPosition: 'end',
      verticalPosition: 'top',
      }); 
       this.modalRef?.hide();
    },

    error: (err) => {
      this._snackBar.open(`Erro ao excluir cliente: ${err}`, 'Fechar',{
      duration: 4000,
      horizontalPosition: 'end',
      verticalPosition: 'top',
      }); 
      
      this.modalRef?.hide();
    }
  });  
}

}