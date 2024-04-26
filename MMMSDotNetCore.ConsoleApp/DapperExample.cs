using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMMSDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public void run()
        {
            read();
            edit(1);
            edit(200);
            create( "Hi", "HIII", "Heee");
            update(5, "HLA HlA", "Come Back", "Waiting For You");

            delete (5);
        }
        private void read()
        {
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> lst = db.Query<BlogDto>("Select * from Tbl_Blogs").ToList();

            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.Blogid);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("--------------------------");
            }
        }

        private void edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("Select * from Tbl_Blogs where Blogid=@Blogid", new BlogDto { Blogid = id }).FirstOrDefault();


            if (item is null)
            {
                Console.WriteLine("No Data Found!!! ");
                return;
            }


            Console.WriteLine(item.Blogid);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("--------------------------");

        }

        private void create( string title, string author, string content)
        {
            var item = new BlogDto
            {
                //Blogid = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            string query = @"INSERT INTO [dbo].[Tbl_Blogs]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
           VALUES
           (@BlogTitle,@BlogAuthor,@BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? " Data inserting successful" : "Inserted fail";
            Console.WriteLine(message);

        }

        private void update(int id , string title, string author, string content)
        {
            var item = new BlogDto
            {
                Blogid = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            string query = @"UPDATE  [dbo].[Tbl_Blogs] SET
           [BlogTitle] =@BlogTitle,
           [BlogAuthor]=@BlogAuthor,
           [BlogContent]=@BlogContent
           Where BlogID=@Blogid";
          

            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? " Data updating  successful" : "updated fail";
            Console.WriteLine(message);

        }

        private void delete (int id)
        {
            var item = new BlogDto
            {
                Blogid = id
            };
            string query = @"DELETE FROM [dbo].[Tbl_Blogs]
            WHERE BlogId=@BlogId";


            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string message = result > 0 ? " Data delete  successful" : "deleted fail";
            Console.WriteLine(message);

        }
    }

}