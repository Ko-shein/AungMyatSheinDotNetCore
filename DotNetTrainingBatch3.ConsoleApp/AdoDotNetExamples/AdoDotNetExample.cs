using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read() 
        {
           
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "shein@";

            //Console.WriteLine("ConnectionString => " + sqlConnectionStringBuilder.ConnectionString);

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            string query = "SELECT * FROM Blog_Tb";
            sqlConnection.Open();
            string query1 = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
              FROM [dbo].[Blog_Tb]";
            //Console.WriteLine("Connection Opened");
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();
            //Console.WriteLine("Connection Closed");
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("ID... " + dr["BlogId"]);
                Console.WriteLine("Title... " + dr["BlogTitle"]);
                Console.WriteLine("Author... " + dr["BlogAuthor"]);
                Console.WriteLine("Content... " + dr["BlogContent"]);
            }
            

          
        }

        public void Edit(int id) 
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "shein@";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            
            sqlConnection.Open();
            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
              FROM [dbo].[Blog_Tb] Where BlogId = @BlogId";
            
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No record found");
                return;
            }

            DataRow dr = dt.Rows[0];

            
                Console.WriteLine("ID... " + dr["BlogId"]);
                Console.WriteLine("Title... " + dr["BlogTitle"]);
                Console.WriteLine("Author... " + dr["BlogAuthor"]);
                Console.WriteLine("Content... " + dr["BlogContent"]);
            
        }

        public void Create(string title, string author , string content)

        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "shein@";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);


            sqlConnection.Open();
            string query = @"INSERT INTO [dbo].[Blog_Tb]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Record inserted" : "Record not inserted";

            Console.WriteLine(message);

           
        }

        public void Update(int id,string title, string author, string content)

        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "shein@";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);


            sqlConnection.Open();
            string query = @"UPDATE [dbo].[Blog_Tb]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent 
 WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Record updated" : "Record not updated";
            Console.WriteLine(message);


        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "shein@";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            string query = @"Delete From [dbo].[Blog_Tb] WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Record deleted" : "Record not deleted";
            Console.WriteLine(message);
        }
    }
}
