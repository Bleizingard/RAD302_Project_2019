using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using StudentAssAttSys.API.Providers;
using StudentAssAttSys.API.Models;
using Microsoft.Owin.Security.MicrosoftAccount;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Notifications;

namespace StudentAssAttSys.API
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // The Client ID (a.k.a. Application ID) is used by the application to uniquely identify itself to Azure AD
        string clientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"];

        // RedirectUri is the URL where the user will be redirected to after they sign in
        string redirectUrl = System.Configuration.ConfigurationManager.AppSettings["redirectUrl"];

        // Tenant is the tenant ID (e.g. contoso.onmicrosoft.com, or 'common' for multi-tenant)
        static string tenant = System.Configuration.ConfigurationManager.AppSettings["Tenant"];

        // Authority is the URL for authority, composed by Azure Active Directory endpoint and the tenant name (e.g. https://login.microsoftonline.com/contoso.onmicrosoft.com)
        string authority = String.Format(System.Globalization.CultureInfo.InvariantCulture, System.Configuration.ConfigurationManager.AppSettings["Authority"], tenant);


        /// <summary>
        /// Configure OWIN to use OpenIdConnect 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            //Configure the app to use OpenId Connect [1 tenant only]
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    // Sets the ClientId, authority, RedirectUri as obtained from web.config
                    ClientId = clientId,
                    Authority = authority,
                    RedirectUri = redirectUrl,

                    // PostLogoutRedirectUri is the page that users will be redirected to after sign-out. In this case, it is using the home page
                    PostLogoutRedirectUri = redirectUrl,

                    //Scope is the requested scope: OpenIdConnectScopes.OpenIdProfileis equivalent to the string 'openid profile': in the consent screen, this will result in 'Sign you in and read your profile'
                    Scope = OpenIdConnectScope.OpenIdProfile,

                    // ResponseType is set to request the id_token - which contains basic information about the signed-in user
                    ResponseType = OpenIdConnectResponseType.IdToken,

                    // ValidateIssuer set to false to allow work accounts from any organization to sign in to your application
                    // To only allow users from a single organizations, set ValidateIssuer to true and 'tenant' setting in web.config to the tenant name or Id (example: contoso.onmicrosoft.com)
                    // To allow users from only a list of specific organizations, set ValidateIssuer to true and use ValidIssuers parameter
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                    },

                    // OpenIdConnectAuthenticationNotifications configures OWIN to send notification of failed authentications to OnAuthenticationFailed method
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = OnAuthenticationFailed
                    }
                }
            );

            // Configurer l'application pour le flux basé sur OAuth
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // Jeu de modes en production AllowInsecureHttp = false
                AllowInsecureHttp = true
            };
        }

        /// <summary>
        /// Handle failed authentication requests by redirecting the user to the home page with an error in the query string
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
        {
            context.HandleResponse();
            context.Response.Redirect("/?errormessage=" + context.Exception.Message);
            return Task.FromResult(0);
        }

        // Pour plus d'informations sur la configuration de l'authentification, visitez https://go.microsoft.com/fwlink/?LinkId=301864
        //public void ConfigureAuth(IAppBuilder app)
        //{
        //    // Configurer le contexte de base de données et le gestionnaire des utilisateurs pour utiliser une instance unique par demande
        //    app.CreatePerOwinContext(ApplicationDbContext.Create);
        //    app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

        //    // Activer l'application pour utiliser un cookie afin de stocker les informations de l'utilisateur connecté
        //    // et utiliser un cookie pour stocker temporairement des informations sur un utilisateur qui se connecte avec un fournisseur de connexion tiers
        //    app.UseCookieAuthentication(new CookieAuthenticationOptions());
        //    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        //    // Configurer l'application pour le flux basé sur OAuth
        //    PublicClientId = "self";
        //    OAuthOptions = new OAuthAuthorizationServerOptions
        //    {
        //        TokenEndpointPath = new PathString("/Token"),
        //        Provider = new ApplicationOAuthProvider(PublicClientId),
        //        AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
        //        // Jeu de modes en production AllowInsecureHttp = false
        //        AllowInsecureHttp = true
        //    };

        // Activer l'application pour utiliser les jetons du porteur afin d'authentifier les utilisateurs
        //app.UseOAuthBearerTokens(OAuthOptions);

        // Décommenter les lignes suivantes pour activer la connexion avec des fournisseurs de connexion tiers
        //app.UseMicrosoftAccountAuthentication(
        //    clientId: "75827463-fb25-423a-b9b7-f48a7f4be6b5",
        //    clientSecret: "zfnNEJW828:-zueeSQR39%#");

        //app.UseTwitterAuthentication(
        //    consumerKey: "",
        //    consumerSecret: "");

        //app.UseFacebookAuthentication(
        //    appId: "",
        //    appSecret: "");

        //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
        //{
        //    ClientId = "",
        //    ClientSecret = ""
        //});
    }
}
}
