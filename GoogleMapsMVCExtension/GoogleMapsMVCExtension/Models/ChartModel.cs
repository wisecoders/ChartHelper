using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsMVCExtension.Models
{
    public class ChartModel
    {
        public Dictionary<string, string> columns { get; set; }
        public DataTable rows { get; set; }

        public Dictionary<string, string> Options { get; set; }

        public ChartModel()
        {
            columns = new Dictionary<string, string>();
            Options = new Dictionary<string, string>();
        }
    }
}
