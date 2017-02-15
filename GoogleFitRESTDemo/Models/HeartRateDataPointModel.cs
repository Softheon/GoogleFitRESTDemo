using System;

namespace GoogleFitRESTDemo.Models
{
    /// <summary>
    /// Represents a heart rate datapoint.
    /// </summary>
    public class HeartRateDataPointModel
    {
        /// <summary>
        /// Gets or sets the BPM.
        /// </summary>
        /// <value>
        /// The BPM.
        /// </value>
        public double? BPM { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        /// <value>
        /// The time stamp.
        /// </value>
        public DateTime TimeStamp { get; set; }
    }
}