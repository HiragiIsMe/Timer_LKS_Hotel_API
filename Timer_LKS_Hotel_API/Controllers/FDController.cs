using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Timer_LKS_Hotel_API.Controllers
{
    public class FDController : ApiController
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HUJGH1E\SQLEXPRESS;Initial Catalog=timerHotel;Integrated Security=True;");

        [HttpGet]
        public DataTable get()
        {
            SqlCommand cmd = new SqlCommand("select ID, Name, Price from FoodsAndDrinks", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }
    }
}
