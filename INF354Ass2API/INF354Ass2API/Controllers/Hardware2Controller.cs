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
    public class Hardware2Controller : ApiController
    {
        [System.Web.Mvc.Route("api/Hardware2/getTables")]

        public List<dynamic> getTables()
        {
            HardwareDBEntities db = new HardwareDBEntities();
            List<dynamic> tableList = new List<dynamic>();

            foreach(lgemployee emp in db.lgemployees)
            {
                dynamic employees = new ExpandoObject();
                employees.emp_num = emp.emp_num;
                employees.emp_fname = emp.emp_fname;
                //employees.dept_num = emp.dept_num;
                tableList.Add(employees);
            }

            foreach(lgdepartment dept in db.lgdepartments)
            {
                dynamic department = new ExpandoObject();
                department.dept_num = dept.dept_num;
                department.dept_name = dept.dept_name;
                department.emp_num = dept.emp_num;
                tableList.Add(department);
            }
            return tableList;
        }
    }
}
