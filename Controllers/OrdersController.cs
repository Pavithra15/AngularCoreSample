using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using AngularwithASPCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace AngularwithASPCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        // POST: api/Orders
        [HttpPost]

        [Route("DataSource")]
        public object DataSource([FromBody]Data dm)
        {
            var order = OrdersDetails.GetAllRecords();
            var Data = order.ToList();
            int count = order.Count();
            return dm.requiresCounts ? Json(new { result = Data.Skip(dm.skip).Take(dm.take), count = count }) : Json(Data);

        }
        [HttpPost]

        [Route("Update")]
        public Object Update([FromBody]CRUDModel<OrdersDetails> value)
        {
            var ord = value.value;
            OrdersDetails val = OrdersDetails.GetAllRecords().Where(or => or.OrderID.Equals(ord.OrderID)).FirstOrDefault();
            val.OrderID = ord.OrderID;
            val.EmployeeID = ord.EmployeeID;
            val.CustomerID = ord.CustomerID;
            val.Freight = ord.Freight;
            val.OrderDate = ord.OrderDate;
            val.ShipCity = ord.ShipCity;

            return Json(value.value);
        }
        //insert the record
        [HttpPost]

        [Route("Insert")]
        public Object Insert([FromBody]CRUDModel<OrdersDetails> value)
        {

            OrdersDetails.GetAllRecords().Insert(0, value.value);
            return Json(value.value);
        }
        //Delete the record
        [HttpPost]

        [Route("Delete")]
        public Object Delete([FromBody]CRUDModel<OrdersDetails> value)
        {
            OrdersDetails.GetAllRecords().Remove(OrdersDetails.GetAllRecords().Where(or => or.OrderID.Equals(value.key)).FirstOrDefault());
            return Json(value);
        }

        public class Data
        {

            public bool requiresCounts { get; set; }
            public int skip { get; set; }
            public int take { get; set; }
        }
        public class CRUDModel<T> where T : class
        {
            public string action { get; set; }

            public string table { get; set; }

            public string keyColumn { get; set; }

            public int key { get; set; }

            public T value { get; set; }

            public List<T> added { get; set; }

            public List<T> changed { get; set; }

            public List<T> deleted { get; set; }

            public IDictionary<string, object> @params { get; set; }
        }
    }
}
