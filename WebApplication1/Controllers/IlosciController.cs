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
                                + ilosci.Ilosc + @", '"
                                + ilosci.Skladnik_nazwa + @"', '"
                                + ilosci.Jednostka_nazwa + @"', "
                                + ilosci.Przepis_id +  @")";

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
    }
}
