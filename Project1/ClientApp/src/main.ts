// import { enableProdMode } from '@angular/core';
// import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

// import { AppModule } from './app/app.module';
// import { environment } from './environments/environment';

// if (environment.production) {
//   enableProdMode();
// }

// platformBrowserDynamic().bootstrapModule(AppModule)
//   .catch(err => console.error(err));
// Load `$localize` onto the global scope - used if i18n tags appear in Angular templates.
import '@angular/localize/init';

import { enableProdMode } from '@angular/core';
import { loadTranslations } from '@angular/localize';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { getTranslations, ParsedTranslationBundle } from '@locl/core';

import { environment } from './environments/environment';
import { Locale } from './assets/i18n/local';

if (environment.production) {
  enableProdMode();
}

let language = localStorage.getItem('selectedLanguage');
if (language == null) {
  language = 'fr';
}
getTranslations(`./assets/i18n/${language}.json`).then((frData: ParsedTranslationBundle) => {
      console.log(frData);
      loadTranslations(frData.translations);
      Locale.selectedLanguage = language;
      import('./app/app.module').then((module) => {
        platformBrowserDynamic()
          .bootstrapModule(module.AppModule)
          .catch((err) => alert(err));
      });
});