using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class IlosciController : ApiController
    {

        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM dbo.Ilosci";

            System.Data.DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        //api/Ilosci/{id_przepisu}
        public HttpResponseMessage Get(int id)
        {
            string query = @"SELECT * FROM dbo.Ilosci WHERE przepis_id = " + id;

            System.Data.DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        public string Post([FromBody] Ilosci ilosci)
        {
            try
            {
                string query = @"insert into ilosci(ilosc , skladnik_nazwa , jednostka_nazwa , przepis_id) 
                                Values( "
                                + ilosci.ilosc + @", '"
                                + ilosci.skladnik_nazwa + @"', '"
                                + ilosci.jednostka_nazwa + @"', "
                                + ilosci.przepis_id + @")";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Dodano skladnik do przepisu";

            }
            catch (Exception)
            {

                return "Nie dodano skladniku do przepisu";
            }

        }

        public string Delete(string id)
        {
            try
            {
<<<<<<< HEAD
                string query = @"DELETE FROM dbo.ilosci WHERE przepis_id = '" + id + @"'";
=======
                string query = @"DELETE FROM dbo.ilosci WHERE id_przepisu = '" + id + @"'";
>>>>>>> 9cc3b04b3db1de3420086b136daf654fb51ab372


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
<<<<<<< HEAD
                return "Usunięto użytkownika";
=======
                return "Usunięto ilości";
>>>>>>> 9cc3b04b3db1de3420086b136daf654fb51ab372

            }
            catch (Exception)
            {

<<<<<<< HEAD
                return "Nie znaleziono użytkownika";
=======
                return "Nie znaleziono ilości";
>>>>>>> 9cc3b04b3db1de3420086b136daf654fb51ab372
            }

        }
    }
}
