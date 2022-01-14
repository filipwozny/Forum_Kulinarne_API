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
    public class UzytkownicyController : ApiController
    {
        public HttpResponseMessage Get()
        {

            string query = @"SELECT * FROM dbo.Uzytkownicy";

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


        public string Post([FromBody] Uzytkownicy user)
        {
            try
            {
                string query = @"insert into dbo.Uzytkownicy(Nazwa_uzytkownika, Haslo, Imie, Nazwisko, Numer_telefonu, Mail) 
                                Values( '"
                                + user.Nazwa_uzytkownika + @"', '"
                                + user.Haslo + @"', '"
                                + user.Imie + @"', '"
                                + user.Nazwisko + @"', ";

                if (user.Numer_telefonu > 0)
                {
                    query += user.Numer_telefonu + @", ";
                }
                else
                {
                    query += @"NULL, ";
                }

                if (user.Mail != null)
                {
                    query += @" '" + user.Mail + @"'";
                }
                else
                {
                    query += @"NULL";
                }

                query += @")";


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Dodano użytkownika";

            }
            catch (Exception)
            {

                return "Nie dodano użytkownika";
            }

        }

        public HttpResponseMessage Get(string id)
        {
            try
            {
                string query = @"SELECT * FROM dbo.Uzytkownicy WHERE Nazwa_uzytkownika = '" + id + @"'";

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
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage Get(string id, string pass)
        {
            try
            {
                string query = @"SELECT * FROM dbo.Uzytkownicy WHERE Nazwa_uzytkownika = '" + id + @"' AND haslo = '" + pass + @"'";

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
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        public string Delete(string id)
        {
            try
            {
                string query = @"DELETE FROM dbo.Uzytkownicy WHERE Nazwa_uzytkownika = '" + id + @"'";


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Usunięto użytkownika";

            }
            catch (Exception)
            {

                return "Nie znaleziono użytkownika";
            }

        }

    }

}

