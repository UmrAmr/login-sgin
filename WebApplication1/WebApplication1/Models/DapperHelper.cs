using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Data; //added by umer
using System.Data.SqlClient; //added by umer
using Dapper; //added by umer

namespace WebApplication1.Models
{
    public class DapperHelper
    {
        public readonly SqlConnection Connection;
        public DapperHelper()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString());
        }

        ////added this method by umer chatgbt
        //public void InsertUser(AppUsers user)
        //{
        //    using (IDbConnection db = new SqlConnection(connection))
        //    {
        //        string query = "INSERT INTO Users (username, password, email, name) VALUES (@username, @password, @email, @name)";
        //        db.Execute(query, user);
        //    }
        //}
    }
}


