using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Fitness.v1;
using Google.Apis.Util.Store;
using GoogleFitRESTDemo.Configuration;

namespace GoogleFitRESTDemo.Authentication
{
    public class AppFlowMetadata : FlowMetadata
    {
        /// <summary>
        /// The client identifier
        /// </summary>
        private static readonly string ClientId = GoogleClientSettings.ClientId;

        /// <summary>
        /// The client secret{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private static readonly string ClientSecret = GoogleClientSettings.ClientSecret;

        private static readonly IAuthorizationCodeFlow flow = 
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret
                },
                Scopes = new[]
                {
                    FitnessService.Scope.FitnessBodyRead
                },
                DataStore = new FileDataStore("~/App_Data/Auth")
            });

        public override string GetUserId(Controller controller)
        {
            var user = controller.Session["user"];
            if (user == null)
            {
                user = Guid.NewGuid();
                controller.Session["user"] = user;
            }
            return user.ToString();
        }

        public override IAuthorizationCodeFlow Flow
        {
            get { return flow; }
        }
    }
}