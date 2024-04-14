﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMMSDotNetCore.ConsoleApp
{
    internal class AdoNetExample
    {
            private readonly SqlConnectionStringBuilder _sqlConnectionString =new SqlConnectionStringBuilder()
            {
            DataSource = "AGD-SW-523",//Server Name
            InitialCatalog = "MMMSDotNet", //Database Name
            UserID = "sa",//User Name 
            Password = "sa@123" //Password

            };
        public void Read()
        {
            ;
            
            SqlConnection connection = new SqlConnection(_sqlConnectionString.ConnectionString);
            //SqlConnection connection = new SqlConnection("Datasource:AGD-OP-1160;" +
            //  "InitialCatalog=MMMSDotNet;UserID = sa;Password = sa@123;");  //also can use like this 


            connection.Open();
            Console.WriteLine("connection opened");
            string query = "select * from tbl_Blogs";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id==>" + dr["BlogId"]);
                Console.WriteLine("Blog Title==>" + dr["BlogTitle"]);
                Console.WriteLine("Blog Author==>" + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content==>" + dr["BlogContent"]);
                Console.WriteLine("***********************");
            }

        }
        public void Create(string title,string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionString.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blogs]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,@BlogAuthor,@BlogContent)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogTitle" , title);
            command.Parameters.AddWithValue("@BlogAuthor" , author);
            command.Parameters.AddWithValue("@BlogContent" , content);
            int result= command.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Saving data successful." : "Saving Fail.";
            Console.WriteLine(message);
        }
    } 
}
