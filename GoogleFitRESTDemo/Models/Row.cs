using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleFitRESTDemo.Models
{
    /// <summary>
    /// Defines a <see cref="GoogleVisualizationDataTable"/> row.
    /// </summary>
    public class Row
    {
        /// <summary>
        /// Gets or sets the row values.
        /// </summary>
        /// <value>
        /// The row values.
        /// </value>
        [JsonProperty(PropertyName = "c")]
        public IEnumerable<RowValue> RowValues { get; set; }

        /// <summary>
        /// Defines a row value.
        /// </summary>
        public class RowValue
        {
            /// <summary>
            /// Gets the value.
            /// </summary>
            /// <value>
            /// The value.
            /// </value>
            [JsonProperty(PropertyName = "v")]
            public object Value { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="RowValue"/> class.
            /// </summary>
            /// <param name="value">The value.</param>
            public RowValue(object value)
            {
                Value = value;
            }
        }
    }
}