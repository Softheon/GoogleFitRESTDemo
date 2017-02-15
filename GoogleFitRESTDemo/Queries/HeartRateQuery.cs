using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Fitness.v1;
using GoogleFitRESTDemo.Models;

namespace GoogleFitRESTDemo.Queries
{
    /// <summary>
    /// Queries the heart rate data source of Google Fit.
    /// </summary>
    /// <seealso cref="GoogleFitRESTDemo.Queries.FitnessQuery" />
    public class HeartRateQuery : FitnessQuery
    {
        /// <summary>
        /// The data source
        /// </summary>
        private const string DataSource =
            "derived:com.google.heart_rate.bpm:com.google.android.gms:merge_heart_rate_bpm";

        /// <summary>
        /// The data type
        /// </summary>
        private const string DataType = "com.google.heart_rate.bpm";

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartRateQuery" /> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public HeartRateQuery(FitnessService service) : base(service, DataSource, DataType)
        {
        }

        /// <summary>
        /// Queries the heart rate.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>A list with heart rate data points.</returns>
        public IList<HeartRateDataPointModel> QueryHeartRate(DateTime start, DateTime end)
        {
            var request = CreateRequest(start, end);
            var response = ExecuteRequest(request);

            return response.Point.SelectMany(p =>
                {
                    return p.Value.Select(v => new HeartRateDataPointModel
                    {
                        BPM = v.FpVal,
                        TimeStamp = GoogleTime.FromNanoseconds(p.StartTimeNanos).ToDateTime()
                    });
                })
                .ToList();
        }
    }
}