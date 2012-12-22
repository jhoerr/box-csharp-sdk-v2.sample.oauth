using System;
using System.Text;
using System.Web.Mvc;
// ReSharper disable RedundantUsingDirective
// Removing this messes up the nuget package...
using BoxApi.V2;
// ReSharper restore RedundantUsingDirective
using BoxApi.V2.Authentication.OAuth2;
using BoxApi.V2.Samples.WebAuthentication.MVC.Models;

namespace BoxApi.V2.Samples.WebAuthentication.MVC.Controllers
{
    public class HomeController : Controller
    {
        #region constants
        private const string JsonFormat =
            @"{{
    ""ClientId"": ""{0}"",
    ""ClientSecret"": ""{1}"",
    ""AccessToken"": ""{2}"",
    ""RefreshToken"": ""{3}"",
    ""CollaboratingUserEmail"": ""box.csharp.sdk@gmail.com"",
    ""CollaboratingUserId"": ""186800768""
}}";

        private const string ClientId = "clientId";
        private const string ClientSecret = "clientSecret";
        private const string AccessToken = "accessToken";
        private const string RefreshToken = "refreshToken";
        #endregion

        public ActionResult Index()
        {
            return IsError()
                       ? Error(Request.QueryString["error"], Request.QueryString["error_description"], Request.QueryString["state"])
                       : IsCode()
                             ? Token(Request.QueryString["code"])
                             : Start();
        }

        private ActionResult Start()
        {
            ClearSession();
            return View();
        }

        private void ClearSession()
        {
            Session[ClientId] = null;
            Session[ClientSecret] = null;
            Session[AccessToken] = null;
            Session[RefreshToken] = null;
        }

        public ActionResult InitiateAuthorization(string clientId, string clientSecret)
        {
            Session[ClientId] = clientId;
            Session[ClientSecret] = clientSecret;
            var boxAuthenticator = new TokenProvider(clientId, clientSecret);
            return new RedirectResult(boxAuthenticator.GetAuthorizationUrl());
        }

        private bool IsCode()
        {
            return Request.QueryString["code"] != null;
        }

        private bool IsError()
        {
            return Request.QueryString["error"] != null;
        }

        private ActionResult Token(string arg1)
        {
            try
            {
                var boxAuthenticator = new TokenProvider(Session[ClientId] as string, Session[ClientSecret] as string);
                OAuthToken accessToken = boxAuthenticator.GetAccessToken(arg1);
                Session[AccessToken] = accessToken.AccessToken;
                Session[RefreshToken] = accessToken.RefreshToken;
                return View("Authorize", accessToken);
            }
            catch (BoxException e)
            {
                return Error(e.Error.Status, e.Message);
            }
            catch (Exception e)
            {
                return Error(e.Message, e.StackTrace);
            }
        }

        private ViewResult Error(string error, string description, string state = null)
        {
            ClearSession();
            return View("Error", new ErrorModel {Message = error, Description = description ?? "(none)", State = state ?? "(none)"});
        }

        public FileResult Save()
        {
            string result = string.Format(JsonFormat, Session[ClientId] as string, Session[ClientSecret] as string, Session[AccessToken] as string, Session[RefreshToken] as string);
            ClearSession();
            return File(Encoding.UTF8.GetBytes(result), "application/json", "test_info.json");
        }
    }
}