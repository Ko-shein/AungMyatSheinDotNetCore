// See https://aka.ms/new-console-template for more information
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;
using DotNetTrainingBatch3.ConsoleApp.EFCoreExamples;
using System.Data;
using System.Data.SqlClient;



//AdoDotNetExample
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
////adoDotNetExample.Edit(1);
////adoDotNetExample.Edit(11);
////adoDotNetExample.Create(t itle:"test title",author:"test author",content:"test content");
////adoDotNetExample.Update(id: 7,title: "test title update", author: "test author update", content: "test content update");
//adoDotNetExample.Delete(7);
//Console.ReadKey();

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(1);
//dapperExample.Edit(11);
//dapperExample.Create(title: "test title", author: "test author", content: "test content");
//dapperExample.Update(id: 7, title: "test title update", author: "test author update", content: "test content update");
//dapperExample.Delete(7);

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Read();
eFCoreExample.Edit(1);
eFCoreExample.Edit(11);
eFCoreExample.Create(title: "test title", author: "test author", content: "test content");
eFCoreExample.Update(id: 7, title: "test title update", author: "test author update", content: "test content update");
eFCoreExample.Delete(7);
Console.ReadKey();