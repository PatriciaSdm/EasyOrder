import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PerfilComponent } from './pages/administração/perfil/perfil.component';
import { PermissoesComponent } from './pages/administração/permissoes/permissoes.component';
import { UsuarioComponent } from './pages/administração/usuario/usuario.component';
import { ComandasComponent } from './pages/comandas/comandas.component';
import { NovaComandaComponent } from './pages/nova-comanda/nova-comanda.component';
import { PainelPedidosComponent } from './pages/painel-pedidos/painel-pedidos.component';
import { AdicionaisFormComponent } from './pages/produtos/adicionais/adicionais-form/adicionais-form.component';
import { AdicionaisComponent } from './pages/produtos/adicionais/adicionais.component';
import { CategoriasFormComponent } from './pages/produtos/categorias/categorias-form/categorias-form.component';
import { CategoriasComponent } from './pages/produtos/categorias/categorias.component';
import { ProdutoFormComponent } from './pages/produtos/produtos/produto-form/produto-form.component';
import { ProdutosComponent } from './pages/produtos/produtos/produtos.component';
import { SidenavComponent } from './sidenav/sidenav.component';

const dashboardRouterConfig: Routes = [
    {
        path: '',
        component: SidenavComponent,
        children: [
            {
                path: 'nova-comanda',
                component: NovaComandaComponent
            },
            {
                path: 'painel-pedidos',
                component: PainelPedidosComponent
            },
            {
                path: 'comandas',
                component: ComandasComponent
            },
            {
                path: 'produtos',
                component: ProdutosComponent
            },
            {
                path: 'categorias',
                component: CategoriasComponent
            },
            {
                path: 'adicionais',
                component: AdicionaisComponent
            },
            {
                path: 'usuario',
                component: UsuarioComponent
            },
            {
                path: 'perfil',
                component: PerfilComponent
            },
            {
                path: 'permissoes',
                component: PermissoesComponent
            },
            {
                path: 'produto-form/:produtoId',
                component: ProdutoFormComponent
            },
            {
                path: 'categorias-form',
                component: CategoriasFormComponent
            },
            {
                path: 'adicionais-form',
                component: AdicionaisFormComponent
            },
        ]
    },
    {
        path: '**',
        redirectTo: '/dashboard',
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(dashboardRouterConfig)
    ],
    exports: [RouterModule]
})
export class DashboardRoutingModule { }