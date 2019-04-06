using System;
using System.Collections.Generic;
using System.Dynamic;
using INF354Ass2API.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace INF354Ass2API.Controllers
{
    public class Hardware3Controller : ApiController
    {
        [System.Web.Mvc.Route("api/Hardware/getAllEmployees")]

        public List<dynamic> getAllEmployees()
        {
            HardwareDBEntities db = new HardwareDBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<dynamic> empList = new List<dynamic>();
            foreach (lgemployee employee in db.lgemployees)
            {
                dynamic employees = new ExpandoObject();
                employees.emp_num = employee.emp_num;
                employees.emp_fname = employee.emp_fname;
                employees.emp_title = employee.emp_title;
                empList.Add(employees);
            }
            return empList;
        }

        [System.Web.Mvc.Route("api/Hardware3/addEmployees")]

        public List<dynamic> addEmployees([FromBody] List<lgemployee> employees)
        {
            HardwareDBEntities db = new HardwareDBEntities();
            db.Configuration.ProxyCreationEnabled = false;

            db.lgemployees.AddRange(employees);
            db.SaveChanges();
            return getAllEmployees();
        }

    }
}
