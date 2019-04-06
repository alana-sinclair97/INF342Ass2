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
    public class HardwareController : ApiController
    {
        //demo function that returns all the types from the Db. HttpPost Header means that it will only work for post requests not get.
        //route header defines the path the function will be accessible from.
        //proxyCreationEnabled=false makes sure that EF doesn't create proxy classes and so this optimises memory use
        //data collected from the db is passed to the getReturnList function which formats it in JSON for return
        //result of the call is returned to the client

        [System.Web.Http.Route("api/Hardware/getAllEmployees")]
        [System.Web.Mvc.HttpPost]

        public List<dynamic> getAllEmployees()
        {
            HardwareDBEntities db = new HardwareDBEntities();
            db.Configuration.ProxyCreationEnabled = false;
            List<dynamic> empList = new List<dynamic>();
            foreach(lgemployee employee in db.lgemployees)
            {
                dynamic employees = new ExpandoObject();
                employees.emp_num = employee.emp_num;
                employees.emp_fname = employee.emp_fname;
                employees.emp_title = employee.emp_title;
                empList.Add(employees);
            }
            return empList;
        }
    }
}
