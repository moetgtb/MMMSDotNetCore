
using MMMSDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoNetExample adoNetExample = new AdoNetExample();
//adoNetExample.Read();
adoNetExample.Create("I love You","Moh Moh","How are you");
Console.ReadKey();
