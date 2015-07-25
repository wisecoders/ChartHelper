using GoogleMapsMVCExtension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;

namespace GoogleMapsMVCExtension.Helpers
{
    public static class ChartHelper
    {
        private static string scriptstring = @"<script type='text/javascript' src='https://www.google.com/jsapi'></script>
  <script type = 'text/javascript' >

    // Load the Visualization API and the piechart package.
    google.load('visualization', '1', {{'packages':['corechart']}});

    // Set a callback to run when the Google Visualization library is loaded.
    google.setOnLoadCallback(drawChart);

    // Callback that creates and populates a data table,
    // instantiates the pie chart, passes in the data and
    // draws it.
    function drawChart()
    {{

        // Create our data table.
        var data = new google.visualization.DataTable();
        {0}
        data.addRows([
        {1}
    ]);

    var options = {{{2}}};

    // Instantiate and draw our chart, passing in some options.
        var chart = new google.visualization.{3}(document.getElementById('{4}'));
    chart.draw(data, options);
  }}
  </script>";
        public static MvcHtmlString DrawChart(ChartModel chartmodel, string charttype, string element)
        {
            string result = "";

            string columns = GetChartColumns(chartmodel.columns);
            string rows = GetChartRows(chartmodel.rows);
            string options = GetChartOptions(chartmodel.Options);

            result = string.Format(scriptstring, columns, rows, options, charttype, element);
            return new MvcHtmlString(result);
        }

        private static string GetChartOptions(Dictionary<string, string> attributes)
        {
            string attributestring = "";
            foreach (KeyValuePair<string, string> entry in attributes)
            {
                attributestring += "'" + entry.Key + "':'" + entry.Value + "',";
            }

            attributestring = attributestring.Substring(0, attributestring.Length - 1);

            return attributestring;
        }

        private static string GetChartRows(DataTable rows)
        {
            string rowstring = "";
            foreach (DataRow dr in rows.Rows)
            {
                rowstring += "[";
                foreach (DataColumn col in rows.Columns)
                {
                    if (col.DataType.ToString() == "System.String" || col.DataType.ToString() == "System.DateTime")
                    {
                        if (dr[col] != null)
                            rowstring += "'" + dr[col].ToString() + "',";
                    }
                    else
                    {
                        if (dr[col] != null)
                            rowstring += dr[col].ToString() + ",";
                    }
                }
                rowstring = rowstring.Substring(0, rowstring.Length - 1);
                rowstring += "],"; //+ Environment.NewLine;
            }
            rowstring = rowstring.Substring(0, rowstring.Length - 1);

            return rowstring;
        }

        private static string GetChartColumns(Dictionary<string, string> columns)
        {
            string columnstring = "";
            foreach (KeyValuePair<string, string> entry in columns)
            {
                columnstring += "data.addColumn('" + entry.Key + "','" + entry.Value + "');";
            }

            return columnstring;
        }
    }
}
