using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularwithASPCore.Models
{
    public class Employee1Details
    {
        public static List<Employee1Details> order = new List<Employee1Details>();
        public Employee1Details()
        {

        }
        public Employee1Details(int EmployeeId, string FirstName, string LastName, int ReportsTO)
        {
            this.EmployeeID = EmployeeId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ReportsTo = ReportsTo;
        }
        public static List<Employee1Details> GetAllRecords()
        {
            if (order.Count() == 0)
            {
                int code = 10000;
                for (int i = 1; i < 2; i++)
                {
                    order.Add(new Employee1Details(i + 0, "Nancy", "Davolio", i + 0));
                    order.Add(new Employee1Details(i + 1, "Andrew", "Fuller", i + 0));
                    order.Add(new Employee1Details(i + 2, "Janet", "Leverling", i + 0));
                    order.Add(new Employee1Details(i + 3, "Margaret", "Peacock", i + 0));
                    order.Add(new Employee1Details(i + 4, "John", "Dev", i + 0));
                    order.Add(new Employee1Details(i + 5, "Peter", "Fuller", i + 0));
                    order.Add(new Employee1Details(i + 6, "Robert", "d", i + 0));
                    order.Add(new Employee1Details(i + 7, "Cihan", "Peacock", i + 0));
                    code += 5;
                }
            }
            return order;
        }


        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ReportsTo { get; set; }
    }
}
