using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DotNetTrainingBatch3.ConsoleApp.Models;

namespace DotNetTrainingBatch3.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "shein@"
        };
        public void Read()
        {
            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
              FROM [dbo].[Blog_Tb]";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst=db.Query<BlogModel>(query).ToList();
            foreach (BlogModel item in lst)
            {
                Console.WriteLine("ID... " + item.BlogId);
                Console.WriteLine("Title... " + item.BlogTitle);
                Console.WriteLine("Author... " + item.BlogAuthor);
                Console.WriteLine("Content... " + item.BlogContent);
            }



        }

        public void Edit(int id)
        {

           
            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
              FROM [dbo].[Blog_Tb] Where BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new { BlogID = id }).FirstOrDefault();
            if (item is null) { 
               Console.WriteLine("Record not found");
                return;
            }
            Console.WriteLine("ID... " + item.BlogId);
            Console.WriteLine("Title... " + item.BlogTitle);
            Console.WriteLine("Author... " + item.BlogAuthor);
            Console.WriteLine("Content... " + item.BlogContent);
         
            
            

        }

        public void Create(string title, string author, string content)

        {
           
            string query = @"INSERT INTO [dbo].[Blog_Tb]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blogModel);
            string message = result > 0 ? "Record inserted" : "Record not inserted";
            Console.WriteLine(message);


        }

        public void Update(int id, string title, string author, string content)

        {
            

            string query = @"UPDATE [dbo].[Blog_Tb]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent 
 WHERE BlogId = @BlogId";

            BlogModel blogModel = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blogModel);
            string message = result > 0 ? "Record updated" : "Record not updated";
            Console.WriteLine(message);


        }

        public void Delete(int id)
        {
           

            string query = @"Delete From [dbo].[Blog_Tb] WHERE BlogId = @BlogId";

            BlogModel blogModel = new BlogModel()
            {
                BlogId = id
            };
            
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blogModel);
            string message = result > 0 ? "Record deleted" : "Record not deleted";
            Console.WriteLine(message);
        }
    }
}
