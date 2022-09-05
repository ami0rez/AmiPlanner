import { InputTextModule } from 'primeng/inputtext';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/components/login/login.component';
import { SecurityRoutingModule } from './security-routing.module';
import { ButtonModule } from 'primeng/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InvolysLibraryModule } from 'involys-library';
import { TableModule } from 'primeng/table';
import { LogoutComponent } from './login/components/logout/logout.component';
import { UtilisateurEditionComponent } from './utilisateur/components/utilisateur-edition/utilisateur-edition.component';
import { UtilisateurComponent } from './utilisateur/components/utilisateur-liste/utilisateur-liste.component';
import { SplitButtonModule } from 'primeng/splitbutton';
import { ChangerMotDePasseComponent } from './changer-mot-de-passe/components/changer-mot-de-passe/changer-mot-de-passe.component';

@NgModule({
  declarations: [
    LoginComponent,
    LogoutComponent,
    UtilisateurEditionComponent,
    UtilisateurComponent,
    ChangerMotDePasseComponent
  ],
  imports: [
    SecurityRoutingModule,
    CommonModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TableModule,
    ButtonModule,
    InvolysLibraryModule,
    SplitButtonModule,
    InputTextModule
  ],
})
export class SecurityModule {}
