export const environment = {
  name: 'prod',
  //authRedirectUri: 'https://anyu-ui.azurewebsites.net/authenticated',
  apiUrl: 'https://anyu-api.azurewebsites.net',
  uiUrl: 'https://anyu-ui.azurewebsites.net',
  msalConfig: {
    auth: {
      clientId: 'ee56d57b-cd93-4289-bd17-d09b8a0ce831',
      authority: 'https://login.microsoftonline.com/0133bb48-f790-4560-a64d-ac46a472fbbc'
    }
  },
  apiConfig: {
    scopes: ['api://cd6489d0-8e19-4b37-b8a4-5d3efe281fe0/ANYU-Api.Access'],
    uri: 'https://anyu-api.azurewebsites.net'
  },
  graphApiConfig: {
    scopes: ['user.read'],
    uri: 'https://graph.microsoft.com/v1.0/me'
  }
};
