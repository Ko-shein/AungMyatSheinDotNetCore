// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//Console.Readline();

# region Read
SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(); 
sqlConnectionStringBuilder.DataSource = ".";
sqlConnectionStringBuilder.InitialCatalog = "TestDb";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "shein@";
SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

string query = "SELECT * FROM Blog_Tb";
sqlConnection.Open();
SqlCommand cmd = new SqlCommand(query, sqlConnection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);
sqlConnection.Close();
foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
}
#endregion

Console.ReadKey();