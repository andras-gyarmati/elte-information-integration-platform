// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
export const environment = {
  name: 'local',
  authRedirectUri: 'http://localhost:4200/authenticated',
  apiUrl: 'https://localhost:7112',
  uiUrl: 'http://localhost:4200',
  msalConfig: {
    auth: {
      clientId: 'ee56d57b-cd93-4289-bd17-d09b8a0ce831',
      authority: 'https://login.microsoftonline.com/0133bb48-f790-4560-a64d-ac46a472fbbc'
    }
  },
  apiConfig: {
    scopes: ['api://cd6489d0-8e19-4b37-b8a4-5d3efe281fe0/ANYU-Api.Access'],
    uri: 'https://localhost:7112'
  },
  graphApiConfig: {
    scopes: ['user.read'],
    uri: 'https://graph.microsoft.com/v1.0/me'
  }
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
