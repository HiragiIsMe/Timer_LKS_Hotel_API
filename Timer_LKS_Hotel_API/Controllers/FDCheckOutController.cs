using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Timer_LKS_Hotel_API.Models;
namespace Timer_LKS_Hotel_API.Controllers
{
    public class FDCheckOutController : ApiController
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HUJGH1E\SQLEXPRESS;Initial Catalog=timerHotel;Integrated Security=True;");
        public IHttpActionResult post(FDCheckOutModel f)
        {
            SqlCommand cmd = new SqlCommand("select top(1) ID from ReservationRoom where RoomID="+ f.RoomID +"", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int IdReser = reader.GetInt32(0);
            conn.Close();

            SqlCommand cmd1 = new SqlCommand("insert FDCheckOut values("+ IdReser +", "+ f.FDID +", "+ f.Qty +", "+ f.TotalPrice +", "+ f.EmployeeID +")", conn);
            conn.Open();
            try
            {
                cmd1.ExecuteNonQuery();
                conn.Close();

                ResponseModel resp = new ResponseModel();
                resp.Response = "Success";
                return Ok(resp);
            }catch (Exception ex)
            {
                conn.Close();

                ResponseModel resp = new ResponseModel();
                resp.Response = "Failed";
                return Ok(resp);
            }
        }
    }
}
