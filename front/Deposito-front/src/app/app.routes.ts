import { Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { ClientComponent } from './client/client-list/client.component';
import { OrdersComponent } from './orders/orders.component';
import { ClientCreateComponent } from './client/client-create/client-create.component';
import { ClientEditComponent } from './client/client-edit/client-edit.component';

export const routes: Routes = [
    { path: 'products', component: ProductComponent},

    { path: 'clients', component: ClientComponent},
    { path: 'clients/create', component: ClientCreateComponent},
    { path: 'clients/edit/:id', component: ClientEditComponent },

    { path: 'orders', component: OrdersComponent}
];
