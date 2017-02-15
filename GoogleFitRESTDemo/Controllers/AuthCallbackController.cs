using Google.Apis.Auth.OAuth2.Mvc;
using GoogleFitRESTDemo.Authentication;

namespace GoogleFitRESTDemo.Controllers
{
    /// <summary>
    /// The controller that implements the Google authentication flow.
    /// </summary>
    /// <seealso cref="Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController" />
    public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
    {
        /// <summary>
        /// Gets the flow data which contains
        /// </summary>
        protected override FlowMetadata FlowData
        {
            get
            {
                return new AppFlowMetadata();
            }
        }
    }
}