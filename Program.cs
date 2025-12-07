using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearingCodeFirst.Database;
using LearingCodeFirst.Entitties;

namespace LearingCodeFirst
{
  internal class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Console.WriteLine("Attempting to connect to database...");
        
        using (var context = new BillingDb())
        {
          // This will trigger the migration if needed
          context.Database.Initialize(force: false);
          
          Console.WriteLine("Database connection successful!");
          
          // Test basic functionality
          var customerCount = context.Customers.Count();
          var stockItemCount = context.StockItems.Count();
          var invoiceCount = context.Invoices.Count();
          
          Console.WriteLine($"Current data in database:");
          Console.WriteLine($"Customers: {customerCount}");
          Console.WriteLine($"Stock Items: {stockItemCount}");
          Console.WriteLine($"Invoices: {invoiceCount}");
          
          // Test if InvoiceNumber column exists by trying to query with it
          var sampleInvoice = context.Invoices.FirstOrDefault();
          if (sampleInvoice != null)
          {
            Console.WriteLine($"Sample Invoice - ID: {sampleInvoice.Id}, Number: {sampleInvoice.InvoiceNumber}");
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
        if (ex.InnerException != null)
        {
          Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
        }
      }
      
      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
    }
  }
}
