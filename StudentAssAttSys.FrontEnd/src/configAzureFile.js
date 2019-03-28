import { AuthenticationContext } from "react-adal";
const adalConfig = {
  tenant: "mailitsligo.onmicrosoft.com",
  clientId: "237ac643-844c-406e-b7fd-5bd143766f77",
  endpoints: {
    api: "237ac643-844c-406e-b7fd-5bd143766f77"
  },
  redirectUri: "https://localhost:3000/",
  cacheLocation: "localStorage",
  scopes:
    "https://mailitsligo.onmicrosoft.com/fada38c1-380d-40c2-8147-f6291832f959/user_impersonation"
};
export const authContext = new AuthenticationContext(adalConfig);

export const getToken = () => {
  return authContext.getCachedToken(authContext.config.clientId);
};
