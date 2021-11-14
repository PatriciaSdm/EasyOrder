import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatExpansionModule } from '@angular/material/expansion'
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatCardModule } from '@angular/material/card';
import { MatStepperModule } from '@angular/material/stepper';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { SidenavComponent } from './sidenav/sidenav.component';
import { NovaComandaComponent } from './pages/nova-comanda/nova-comanda.component';
import { PainelPedidosComponent } from './pages/painel-pedidos/painel-pedidos.component';
import { ComandasComponent } from './pages/comandas/comandas.component';
import { ProdutosComponent } from './pages/produtos/produtos/produtos.component';
import { CategoriasComponent } from './pages/produtos/categorias/categorias.component';
import { AdicionaisComponent } from './pages/produtos/adicionais/adicionais.component';
import { UsuarioComponent } from './pages/administração/usuario/usuario.component';
import { PerfilComponent } from './pages/administração/perfil/perfil.component';
import { PermissoesComponent } from './pages/administração/permissoes/permissoes.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ProdutoFormComponent } from './pages/produtos/produtos/produto-form/produto-form.component';
import { CategoriasFormComponent } from './pages/produtos/categorias/categorias-form/categorias-form.component';
import { AdicionaisFormComponent } from './pages/produtos/adicionais/adicionais-form/adicionais-form.component';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    SidenavComponent,
    NovaComandaComponent,
    PainelPedidosComponent,
    ComandasComponent,
    ProdutosComponent,
    CategoriasComponent,
    AdicionaisComponent,
    UsuarioComponent,
    PerfilComponent,
    PermissoesComponent,
    ProdutoFormComponent,
    CategoriasFormComponent,
    AdicionaisFormComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule,
    DashboardRoutingModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatToolbarModule,
    MatExpansionModule,
    MatInputModule,
    MatButtonModule,
    MatDividerModule,
    MatFormFieldModule,
    MatCheckboxModule,
    MatCardModule,
    MatStepperModule,
    MatSlideToggleModule
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class DashboardModule { }
