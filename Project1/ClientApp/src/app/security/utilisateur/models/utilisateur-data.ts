import { UtilisateurListItemResponse } from './utilisateur-list-item-response';
import { UtilisateurResponse } from './utilisateur-response';

export class UtilisateurData{
  listeUtilisateurs: UtilisateurListItemResponse[] = [];
  listeUtilisateursFiltre: UtilisateurListItemResponse[] = [];
  utilisateur: UtilisateurResponse = new UtilisateurResponse();
}
