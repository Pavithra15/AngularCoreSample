using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AngularwithASPCore.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;

namespace AngularwithASPCore.Controllers
{
    public class HomeController : Controller
    {
        public static List<OrdersDetails> order = new List<OrdersDetails>();
        public IActionResult Index()
        {
            return View();
        }
        public string[] ddDatasource([FromBody] Data dm)
        {
            var ddlData = new String[] { "USA", "Germany", "France", "Japan", "UK" };
            return ddlData;
        }
        public IActionResult UrlDatasource([FromBody] ExtendDataManager dm)
        {
            var grid = dm.ej2grid;
            var CustomValue = dm.CustomValue;
            var Value = dm.Value;
            IEnumerable DataSource = OrdersDetails.GetAllRecords();
            DataOperations operation = new DataOperations();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<OrdersDetails>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
        }
        public IActionResult BatchUpdate([FromBody] CRUDModel batchmodel)
        {
            if (batchmodel.Changed != null)
            {
                for (var i = 0; i < batchmodel.Changed.Count(); i++)
                {
                    var ord = batchmodel.Changed[i];
                    OrdersDetails val = OrdersDetails.GetAllRecords().Where(or => or.OrderID == ord.OrderID).FirstOrDefault();
                    val.OrderID = ord.OrderID;
                    val.EmployeeID = ord.EmployeeID;
                    val.CustomerID = ord.CustomerID;
                    val.ShipCity = ord.ShipCity;
                    val.OrderDate = ord.OrderDate;
                }
            }

            if (batchmodel.Deleted != null)
            {
                for (var i = 0; i < batchmodel.Deleted.Count(); i++)
                {
                    OrdersDetails.GetAllRecords().Remove(OrdersDetails.GetAllRecords().Where(or => or.OrderID == batchmodel.Deleted[i].OrderID).FirstOrDefault());
                }
            }

            if (batchmodel.Added != null)
            {
                for (var i = 0; i < batchmodel.Added.Count(); i++)
                {
                    OrdersDetails.GetAllRecords().Insert(0, batchmodel.Added[i]);
                }
            }
            var data = order.ToList();
            return Json(data);

        }
        public class CRUDModel
        {
            public List<OrdersDetails> Added { get; set; }
            public List<OrdersDetails> Changed { get; set; }
            public List<OrdersDetails> Deleted { get; set; }
            public OrdersDetails Value { get; set; }
            public int key { get; set; }
            public string action { get; set; }
        }
        public ActionResult Update([FromBody] CRUDModel<OrdersDetails> value)
        {
            var ord = value.value;
            OrdersDetails val = OrdersDetails.GetAllRecords().Where(or => or.OrderID == ord.OrderID).FirstOrDefault();
            val.OrderID = ord.OrderID;
            val.EmployeeID = ord.EmployeeID;
            val.CustomerID = ord.CustomerID;
            val.Freight = ord.Freight;
            val.OrderDate = ord.OrderDate;
            val.ShipCity = ord.ShipCity;
            val.ShipCountry = ord.ShipCountry;

            return Json(value.value);
        }
        //insert the record
        public ActionResult Insert([FromBody] CRUDModel<OrdersDetails> value)
        {

            OrdersDetails.GetAllRecords().Insert(0, value.value);
            return Json(value.value);
        }
        //Delete the record
        public ActionResult Delete(int key)
        {
            OrdersDetails.GetAllRecords().Remove(OrdersDetails.GetAllRecords().Where(or => or.OrderID == key).FirstOrDefault());
            return Json(key);
        }
        public class CRUDModel<T> where T : class
        {
            public string action { get; set; }

            public string table { get; set; }

            public string keyColumn { get; set; }

            public object key { get; set; }

            public T value { get; set; }

            public List<T> added { get; set; }

            public List<T> changed { get; set; }

            public List<T> deleted { get; set; }

            public IDictionary<string, object> @params { get; set; }
        }


        public class ExtendDataManager: DataManagerRequest
        {
            public bool ej2grid { get; set; }
            public int CustomValue { get; set; }
            public string Value { get; set; }
}

        public IActionResult EmployeeDatasource([FromBody]Data dm)
        {
            var Data = Employee1Details.GetAllRecords();
            int count = Data.Count();
            if (dm.skip != 0)
                Data = Data.Skip(dm.skip).ToList();
            if (dm.take != 0)
                Data = Data.Take(dm.take).ToList();
            return dm.requiresCounts ? Json(new
            {
                result = Data,
                count = count
            }) : Json(Data);
        }
    }
}



public class Data
{

    public bool requiresCounts { get; set; }
    public int skip { get; set; }
    public int take { get; set; }
    public List<Wheres> where { get; set; }
}
public class Wheres
    {
        public List<Predicates> predicates { get; set; }
        public string field { get; set; }
        public bool ignoreCase { get; set; }

        public bool isComplex { get; set; }

        public string value { get; set; }
        public string Operator { get; set; }

    }
    public class Predicates
    {

        public string value { get; set; }
        public string field { get; set; }

        public bool isComplex { get; set; }

        public bool ignoreCase { get; set; }
        public string Operator { get; set; }

    }