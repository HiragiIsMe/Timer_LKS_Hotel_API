using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using Timer_LKS_Hotel_API.Models;
namespace Timer_LKS_Hotel_API.Controllers
{
    public class EmployeeController : ApiController
    {
        timerHotelEntities ent = new timerHotelEntities();

        public string EncPass(string pass)
        {
            using(SHA256Managed sha256Managed = new SHA256Managed())
            {
                byte[] password = sha256Managed.ComputeHash(Encoding.UTF8.GetBytes(pass));
                string getPass = Convert.ToBase64String(password);

                return getPass;
            }
        }
        public IHttpActionResult post(Employee emp)
        {
            string query = "select * from Employee where Username='" + emp.Username + "' and Password='" + EncPass(emp.Password) + "'";
            var user = ent.Employees.SqlQuery(query).FirstOrDefault();
            if(user != null)
            {
                EmployeeModel employee = new EmployeeModel();
                employee.ID = user.ID;
                employee.Name = user.Name;
                employee.Username = user.Username;

                return Ok(employee);
            }
            else
            {
                return Ok(user);
            }

            return BadRequest();
        }
    }
}
