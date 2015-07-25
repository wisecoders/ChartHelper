using GoogleMapsMVCExtension.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleMapsMVCExtension.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            ChartModel model = new ChartModel();

            model.columns.Add("string", "Topping");
            model.columns.Add("number", "Slices");

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Topping");
            dt.Columns.Add("Slices");
            dt.Columns["Slices"].DataType = System.Type.GetType("System.Int32");

            DataRow dr = dt.NewRow();
            dr["Topping"] = "Mushrooms";
            dr["Slices"] = 3;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Topping"] = "Onions";
            dr["Slices"] = 3;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Topping"] = "Olives";
            dr["Slices"] = 1;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Topping"] = "Zucchini";
            dr["Slices"] = 1;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Topping"] = "Pepperoni";
            dr["Slices"] = 2;
            dt.Rows.Add(dr);

            model.rows = dt;

            model.Options.Add("Width", "100%");
            model.Options.Add("Height", "65%");
            model.Options.Add("Title", "My pie chart");

            return View(model);
        }
    }
}