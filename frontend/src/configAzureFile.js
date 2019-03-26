import { AuthenticationContext } from "react-adal";
const adalConfig = {
  tenant: "mailitsligo.onmicrosoft.com",
  clientId: "237ac643-844c-406e-b7fd-5bd143766f77",
  endpoints: {
    api: "https://localhost:44342/237ac643-844c-406e-b7fd-5bd143766f77"
  },
  redirectUri: "https://localhost:3000/",
  cacheLocation: "localStorage"
};
export const authContext = new AuthenticationContext(adalConfig);
export const getToken = () => {
  return authContext.getCachedToken(authContext.config.clientId);
};
