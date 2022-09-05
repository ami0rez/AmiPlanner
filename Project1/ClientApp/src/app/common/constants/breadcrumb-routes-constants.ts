export class BreadCrumbRoutesConstants {
  // Home
  public static readonly home = '/';
  public static readonly editMode = 'edit';

  //#region Security
  public static readonly security = 'security';
  public static readonly loginUrl = `${BreadCrumbRoutesConstants.security}/login`;
  public static readonly logoutUrl = `${BreadCrumbRoutesConstants.security}/logout`;
  public static readonly utilisateurEditionPath = 'utilisateur-edit/:id/edit';
  public static readonly utilisateurCreationPath = 'utilisateur-create';
  public static readonly utilisateurListePath = 'utilisateur-liste';
  public static readonly updatePasswordPath = 'changer-mot-de-passe';
  public static readonly utilisateurCreation = `${BreadCrumbRoutesConstants.security}/${BreadCrumbRoutesConstants.utilisateurCreationPath}`;
  public static readonly utilisateurEdition = `${BreadCrumbRoutesConstants.security}/utilisateur-edit`;
  public static readonly utilisateurListe = `${BreadCrumbRoutesConstants.security}/${BreadCrumbRoutesConstants.utilisateurListePath}`;
  public static readonly updatePassword = `${BreadCrumbRoutesConstants.security}/${BreadCrumbRoutesConstants.updatePasswordPath}`;
  //#endregion

  //#region sous ordonnateur
  public static readonly sousOrdonnateur = 'sous-ordonnateur';
  public static readonly sousOrdonnateurList = 'sous-ordonnateur-list';
  public static readonly referentielModuleUrl = 'referentiel';
  public static readonly ruoList = 'ruo-list';
  public static readonly ruosListUrl = `${BreadCrumbRoutesConstants.referentielModuleUrl}/ruo-list`;
  public static readonly sousOrdonnateurListUrl = `${BreadCrumbRoutesConstants.referentielModuleUrl}/sous-ordonnateur-list`;
  public static readonly sousOrdonnateurEditionUrl = `${BreadCrumbRoutesConstants.referentielModuleUrl}/sous-ordonnateur`;
  public static readonly sousOrdonnateurEditionPath =
    `${BreadCrumbRoutesConstants.sousOrdonnateur}/:id/` +
    BreadCrumbRoutesConstants.editMode;
  //#endregion

  //#region parametrage
  public static readonly parametrage = 'parametrage';
  public static readonly parametrageModuleUrl = 'parametrage';
  //#endregion

  //#region budget
  public static readonly budget = 'budget';
  public static readonly budgetModuleUrl = 'budget';
  //#endregion

  //#region delegation
  public static readonly delegation = 'delegation';
  public static readonly delegationList = 'delegation-list';
  public static readonly delegationModuleUrl = 'delegation';
  public static readonly delegationListUrl = `${BreadCrumbRoutesConstants.delegationModuleUrl}/delegation-list`;
  public static readonly delegationEditionUrl = `${BreadCrumbRoutesConstants.delegationModuleUrl}/delegation`;
  //#endregion

  //#region depense
  public static readonly depense = 'depense';
  public static readonly depenseList = 'depense-list';
  public static readonly depenseModuleUrl = 'depense';
  public static readonly depenseListUrl = `${BreadCrumbRoutesConstants.depenseModuleUrl}/depense-list`;
  public static readonly depenseEditionUrl = `${BreadCrumbRoutesConstants.depenseModuleUrl}/depense`;
  public static readonly depenseEditionPath =
    `${BreadCrumbRoutesConstants.depenseModuleUrl}/depense/:id/` +
    BreadCrumbRoutesConstants.editMode;
  public static readonly depenseEditable = 'depense/:id/edit';
  public static readonly depenseConsultable = 'depense/:id';
  //#endregion

  //#region engagement
  public static readonly engagement = 'engagement';
  public static readonly engagementList = 'engagement-list';
  public static readonly engagementModuleUrl = 'engagement';
  public static readonly engagementListUrl = `${BreadCrumbRoutesConstants.engagementModuleUrl}/engagement-list`;
  public static readonly engagementEditionUrl = `${BreadCrumbRoutesConstants.engagementModuleUrl}/engagement`;
  public static readonly engagementEditable = 'engagement/:id/edit';
  public static readonly engagementConsultable = 'engagement/:id';
  public static readonly engagementViewer = 'engagement/';
  public static readonly engageDepenseUrl = `depense/:id`;
  public static readonly engageDepense = `${BreadCrumbRoutesConstants.engagementModuleUrl}/depense`;
  //#endregion

  //#region ordonnancement
  public static readonly ordonnancement = 'ordonnancement';
  public static readonly ordonnancementList = 'ordonnancement-list';
  public static readonly ordonnancementModuleUrl = 'ordonnancement';
  public static readonly ordonnancementListUrl = `${BreadCrumbRoutesConstants.ordonnancementModuleUrl}/ordonnancement-list`;
  public static readonly ordonnancementEditionUrl = `${BreadCrumbRoutesConstants.ordonnancementModuleUrl}/ordonnancement`;
  public static readonly ordonnancementEditable = 'ordonnancement/:id/edit';
  public static readonly ordonnancementConsultable = 'ordonnancement/:id';
  public static readonly ordonnancementViewer = 'ordonnancement/';
  public static readonly ordonnancerDepenseUrl = `depense/:id`;
  public static readonly ordonnancerDepense = `${BreadCrumbRoutesConstants.ordonnancementModuleUrl}/depense`;
  public static readonly ordonnancerEngagementUrl = `engagement/:id`;
  public static readonly ordonnancerEngagement = `${BreadCrumbRoutesConstants.ordonnancementModuleUrl}/engagement`;
  public static readonly ordonnancementListFromKpi = `${BreadCrumbRoutesConstants.ordonnancementList}/exercice/:exercice/bdg-line/:bdgLine/valide/:valide/paye/:paye`;
  public static readonly ordonnancementListFromKpiUrl = `${BreadCrumbRoutesConstants.ordonnancementListUrl}/exercice/:exercice/bdg-line/:bdgLine/:valide/paye/:paye`;
  //#endregion

  //#region etat d'execution
  public static readonly etatExecutionModuleUrl = 'etat-execution';
  public static readonly etatExecutionUrl = 'etat-execution';
  //#endregion

  //#region activation
  public static readonly activation = 'activation';
  public static readonly activationModuleUrl = 'activation';
  //#endregion

  //#region journal de communication
  public static readonly journalCommunication = 'journal-communication';
  public static readonly journalCommunicationModuleUrl =
    'journal-communication';
  //#endregion

  // Report viewer
  public static readonly reportModuleUrl = 'report';
  public static readonly viewerUrl = `${BreadCrumbRoutesConstants.reportModuleUrl}/viewer/`;
  //#endregion

  // Urls used for dashboard
  public static readonly engagementByAllFilters =
    'engagement-list/exercice/:exercice/type/:engagementType/bdg-line/:bdgLine';

  public static readonly engagementDepenseByAllFilters =
    'engagement-list/exercice/:exercice/depense-type/:depense/bdg-line/:bdgLine';

  public static readonly etatExecutionByAllFilters =
    'etat-execution/exercice/:exercice/bdg-line/:bdgLine';
  //#endregion
}
