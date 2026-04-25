import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule,  Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { ClientService } from '../../services/client-service/client.service';
import { Client } from '../../models/Client';
import {MatSnackBar, MatSnackBarModule} from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-client-create',
  templateUrl: './client-create.component.html',
  styleUrls: ['./client-create.component.css'],
  imports: [MatFormFieldModule, MatInputModule, FormsModule, ReactiveFormsModule, MatSnackBarModule ]
})
export class ClientCreateComponent implements OnInit {

  private _snackBar = inject(MatSnackBar);
  
  clientForm = new FormGroup({
    email : new FormControl('', [Validators.required, Validators.email]),
    firstName : new FormControl('', [Validators.required]),
    lastName: new FormControl('', [Validators.required]),
    phone: new FormControl('', [Validators.required])
  });   

  constructor(private clientService: ClientService, private router: Router ) { }

  ngOnInit() {
  }

  Create(){
    if (this.clientForm.invalid) return;

    this.clientService.create(this.clientForm.value as Client).subscribe();
    this.openSnackbar();
     this.router.navigate(['/clients']);

  }

  openSnackbar(){
     this._snackBar.open('Cliente criado com sucesso!!', 'Fechar', {
      horizontalPosition: 'end',
      verticalPosition: 'top',
      duration: 5 * 1000,
    });
  }

}
//adicionar snackbar para mensagem de certo ou erro ao criar cliente
