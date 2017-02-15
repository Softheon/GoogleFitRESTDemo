using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Fitness.v1;
using Google.Apis.Services;
using GoogleFitRESTDemo.Authentication;
using GoogleFitRESTDemo.Configuration;
using GoogleFitRESTDemo.Models;
using GoogleFitRESTDemo.Queries;

namespace GoogleFitRESTDemo.Controllers
{
    /// <summary>
    /// Provides methods to respond to HTTP requests for Google Fit data.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class GoogleFitController : Controller
    {
        /// <summary>
        /// Initiates a query for available data sources and displays them in a view.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The index view.</returns>
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var authResult = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata())
                .AuthorizeAsync(cancellationToken);

            if (authResult.Credential != null)
            {
                return View();
            }
            return new RedirectResult(authResult.RedirectUri);
        }

        /// <summary>
        /// Gets the heart rate.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// Heartrate data in JSON format.
        /// </returns>
        public async Task<JsonResult> GetHeartRate(string startDate, CancellationToken cancellationToken)
        {
            var authResult = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata())
                .AuthorizeAsync(cancellationToken);

            if (authResult.Credential != null)
            {
                try
                {
                    var service = new FitnessService(new BaseClientService.Initializer
                    {
                        ApiKey = GoogleClientSettings.ApiKey,
                        ApplicationName = GoogleClientSettings.ApplicationName,
                        HttpClientInitializer = authResult.Credential
                    });

                    var date = DateTime.Parse(startDate).Date.ToUniversalTime();
                    var query = new HeartRateQuery(service);
                    var data = query.QueryHeartRate(date, date.AddDays(1));

                    var dataTabe = new GoogleVisualizationDataTable();

                    dataTabe.AddColumn("Time", "string");
                    dataTabe.AddColumn("Heartrate", "number");

                    foreach (var dataPoint in data)
                    {
                        var values = new List<object>
                        {
                            dataPoint.TimeStamp.ToLocalTime().ToString("t"),
                            dataPoint.BPM
                        };
                        dataTabe.AddRow(values);
                    }
                    return Json(dataTabe, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("e: " + e.Message);
                    return Json(string.Empty);
                }
            }
            return Json(string.Empty);
        }

        /// <summary>
        /// Creates a <see cref="T:System.Web.Mvc.JsonResult" /> object that serializes the specified object to JavaScript Object Notation (JSON) format using the content type, content encoding, and the JSON request behavior.
        /// </summary>
        /// <param name="data">The JavaScript object graph to serialize.</param>
        /// <param name="contentType">The content type (MIME type).</param>
        /// <param name="contentEncoding">The content encoding.</param>
        /// <param name="behavior">The JSON request behavior</param>
        /// <returns>
        /// The result object that serializes the specified object to JSON format.
        /// </returns>
        protected override JsonResult Json(object data, string contentType,
            System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {

            var json = new Newtonsoft.JsonResult.JsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };

            return json;
        }

    }
}