using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APImc.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        static SqlConnection db = new SqlConnection("Server=devlab.thenotepad.eu;Database= PSI20L_PedroAntonio_2220088;User Id=U2220088;Password=NbfcF5G8;");

        public string Get()
        {
            return "welcome to the web API";
        }

        public string setUser(string nome, string pass)
        {
            
            try
            {
                db.Open();
                db.Insert(new tabelaUsers
                {
                    Nome = nome,
                    Passe = pass
                });
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.Close();
            }
            return "success";
        }
        public string Get(int id)
        {
            db.Open();
            string Nome = db.Get<tabelaUsers>(id).Nome;
            db.Close();
            return Nome;

            //return new List<string>
            //{
            //    "Data1",
            //    "Data2"
            //};
        }
    }

    [Table("Users")]
    public class tabelaUsers
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Passe { get; set; }
    }
}
