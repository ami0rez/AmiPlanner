import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChangerMotDePasseComponent } from './changer-mot-de-passe/components/changer-mot-de-passe/changer-mot-de-passe.component';
import { AuthGuard } from './common/auth.guard';
import { LoginComponent } from './login/components/login/login.component';
import { LogoutComponent } from './login/components/logout/logout.component';
import { UtilisateurEditionComponent } from './utilisateur/components/utilisateur-edition/utilisateur-edition.component';
import { UtilisateurComponent } from './utilisateur/components/utilisateur-liste/utilisateur-liste.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'logout', component: LogoutComponent },
  {
    path: 'utilisateur-create',
    component: UtilisateurEditionComponent,
    data: { requireAdmin: true },
    canActivate: [AuthGuard],
  },
  {
    path: 'utilisateur-liste',
    component: UtilisateurComponent,
    data: { requireAdmin: true },
    canActivate: [AuthGuard],
  },
  {
    path: 'utilisateur-edit/:id',
    component: UtilisateurEditionComponent,
    data: { requireAdmin: true },
    canActivate: [AuthGuard],
  },
  {
    path: 'utilisateur-edit/:id/edit',
    component: UtilisateurEditionComponent,
    data: { requireAdmin: true },
    canActivate: [AuthGuard],
  },
  {
    path: 'changer-mot-de-passe',
    component: ChangerMotDePasseComponent,
    canActivate: [AuthGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SecurityRoutingModule {}
