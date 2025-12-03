using LearingCodeFirst.Entitties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearingCodeFirst.Database
{
  //DbContext must inherit
  internal class BillingDb : DbContext
  {
    //this is the constructor, where we will pass our connection string on Constructor of DbContext
    //DESKTOP-GC73I0B is my MSSQL Server's Name
    //BillingDB is database name that will create by command
    //Trusted_Connection=True is for windows authentication
    //if we use username password instead of windows authentication, connectionstring will include username and password
    public BillingDb()
      : base(@"Server=DESKTOP-GC73I0B;Database=BillingDB;Trusted_Connection=True;")
    {

    }

    //For each table Entity we define DbSet type of that Entity class.
    public DbSet<StockItem> StockItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
  }
}
