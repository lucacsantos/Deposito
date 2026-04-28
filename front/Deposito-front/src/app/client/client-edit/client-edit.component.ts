import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ClientService } from '../../services/client-service/client.service';
import { Client } from '../../models/Client';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-client-edit',
  templateUrl: './client-edit.component.html',
  styleUrls: ['./client-edit.component.css'],
  imports: [FormsModule, CommonModule]
})
export class ClientEditComponent implements OnInit {

  client!: Client;

  constructor(private route: ActivatedRoute, private clientService: ClientService) { }

  ngOnInit() {
    const id =  this.route.snapshot.paramMap.get('id')!;

    if(!id) return



    this.clientService.getById(id).subscribe({
      next: (res) => {
        this.client = res;
      },
      error: (err) => {
        alert(err);
      }
    });
  }

}
