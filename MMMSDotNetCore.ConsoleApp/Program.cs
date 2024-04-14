
using MMMSDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoNetExample adoNetExample = new AdoNetExample();
//adoNetExample.Read();
//adoNetExample.Create("Title","Author","Content");
//adoNetExample.Update(19, "Here I am","Louis Voultan","One more step");
//adoNetExample.Delete(18);
//adoNetExample.Edit(18);
adoNetExample.Edit(1);
Console.ReadKey();
