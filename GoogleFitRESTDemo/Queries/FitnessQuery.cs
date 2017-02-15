using System;
using Google.Apis.Fitness.v1;
using Google.Apis.Fitness.v1.Data;

namespace GoogleFitRESTDemo.Queries
{
    /// <summary>
    /// Helper class that hides the complexity of the fitness API.
    /// </summary>
    public abstract class FitnessQuery
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly FitnessService _service;

        /// <summary>
        /// The data source identifier
        /// </summary>
        private readonly string _dataSourceId;

        /// <summary>
        /// The data type
        /// </summary>
        private string _dataType;

        /// <summary>
        /// Initializes a new instance of the <see cref="FitnessQuery"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="dataSourceId">The data source identifier.</param>
        /// <param name="dataType">Type of the data.</param>
        protected FitnessQuery(FitnessService service, string dataSourceId, string dataType)
        {
            _service = service;
            _dataSourceId = dataSourceId;
            _dataType = dataType;
        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns></returns>
        protected virtual string CreateRequest(DateTime start, DateTime end)
        {
            var startTimeNanos = GetNanoseconds(start);
            var endTimeNanos = GetNanoseconds(end);
            return string.Format("{0}-{1}", startTimeNanos, endTimeNanos);
        }

        /// <summary>
        /// Executes the request.
        /// </summary>
        /// <param name="dataSetId">The data set identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>The data set.</returns>
        protected virtual Dataset ExecuteRequest(string dataSetId, string userId = "me")
        {
            var request = _service.Users.DataSources.Datasets.Get(userId, _dataSourceId, dataSetId);
            return request.Execute();
        }

        /// <summary>
        /// Gets the nanoseconds elapesed since the Epoch for a given date time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>A the nanoseconds from the epoch.</returns>
        private long GetNanoseconds(DateTime date)
        {
            var zeroDate = new DateTime(1970, 1, 1);
            long elapsedTicks = date.Ticks - zeroDate.Ticks;

            return elapsedTicks * 100;
        }
    }
}