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
using System.Web;

namespace WebApplication1.Controllers
{
    public class PrzepisyController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM dbo.Przepisy";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        //api/przepisy/{id}
        public HttpResponseMessage Get(int id)
        {
            string query = @"SELECT * FROM dbo.Przepisy WHERE id_przepisu = " + id;

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        //api/przepisy/{nazwa}
        public HttpResponseMessage Get(string nazwa)
        {
            string query = @"SELECT id_przepisu FROM dbo.Przepisy WHERE nazwa = '" + nazwa + @"'";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }




        public string Post([FromBody] Przepisy przepis)
        {
            try
            {
                string query = @"insert into dbo.Przepisy(Nazwa, Autor, Opis, photoName) 
                                Values( '" + przepis.Nazwa + @"', '" + przepis.Autor + @"', '" + przepis.Opis;

                if (przepis.photoName == null)
                {
                   query += @"', 'anonymous.png')";
                }
                else
                {
                    query += @"', '" + przepis.photoName + @"')";
                }


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Dodano przepis";

            }
            catch (Exception)
            {
                return "Nie dodano przepisu";
            }

        }



        [Route("api/przepisy/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);

                postedFile.SaveAs(physicalPath);

                return filename;
            }
            catch (Exception)
            {

                return "anonymous.png";
            }
        }

        public string Put([FromBody] Przepisy przepisy)
        {
            try
            {
                string query = @"UPDATE dbo.Przepisy SET widocznosc = ";
                if (przepisy.Widocznosc)
                {
                    query += @"1";
                }
                else query += @"0";

                query += @" WHERE id_przepisu = " + przepisy.Id_przepisu + @"";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Zmieniono widoczność przepisu";

            }
            catch (Exception)
            {

                return "Nie zmieniono widoczności przepisu";
            }

        }


    }
}
