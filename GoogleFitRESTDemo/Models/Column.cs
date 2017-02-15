using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GoogleFitRESTDemo.Models
{
    /// <summary>
    /// Defines a <see cref="GoogleVisualizationDataTable"/> column.
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}