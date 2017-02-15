using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace GoogleFitRESTDemo.Models
{
    /// <summary>
    /// Facilitates JSON serialization into the Google Charts API DataTable format.
    /// </summary>
    public class GoogleVisualizationDataTable
    {
        /// <summary>
        /// Gets the columns.
        /// </summary>
        /// <value>
        /// The columns.
        /// </value>
        [JsonProperty(PropertyName = "cols")]
        public IList<Column> Columns { get; }

        /// <summary>
        /// Gets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        [JsonProperty(PropertyName = "rows")]
        public IList<Row> Rows { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleVisualizationDataTable"/> class.
        /// </summary>
        public GoogleVisualizationDataTable()
        {
            Rows = new List<Row>();
            Columns = new List<Column>();
        }

        /// <summary>
        /// Adds the column.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="type">The type.</param>
        public void AddColumn(string label, string type)
        {
            Columns.Add(new Column
            {
                Label = label,
                Type = type
            });
        }

        /// <summary>
        /// Adds the row.
        /// </summary>
        /// <param name="values">The values.</param>
        public void AddRow(IList<object> values)
        {
            Rows.Add(new Row
            {
                RowValues = values.Select(x => new Row.RowValue(x))
            });
        }
    }
}