// See https://aka.ms/new-console-template for more information
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using System.Data;
using System.Data.SqlClient;




AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(1);
//adoDotNetExample.Edit(11);
//adoDotNetExample.Create(title:"test title",author:"test author",content:"test content");
//adoDotNetExample.Update(id: 7,title: "test title update", author: "test author update", content: "test content update");
adoDotNetExample.Delete(7);
Console.ReadKey();