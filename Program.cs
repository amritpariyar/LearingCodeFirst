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
          // Test basic functionality
          var customerCount = context.Customers.Count();
          var stockItemCount = context.StockItems.Count();
          var invoiceCount = context.Invoices.Count();
          
          Console.WriteLine($"Current data in database:");
          Console.WriteLine($"Customers: {customerCount}");
          Console.WriteLine($"Stock Items: {stockItemCount}");
          Console.WriteLine($"Invoices: {invoiceCount}");

          //get customers
          //get stock items          
          var customers = context.Customers.ToList();
          var stockItems = context.StockItems.ToList();

          //insert invoice with existing customer and stock item
          //assuming at least one customer and two stock item exist
          //in invoice number we will put random number
          int invoiceNumber = new Random().Next(1000, 9999);

          //create two invoice items with same invoice number
          var invoiceItem1 = new Invoice
          {
            InvoiceNumber = invoiceNumber, //same invoice number
            CustomerId = customers.First().Id,
            StockItemId = stockItems.First().Id,
            Quantity = 2,
            SellingPrice = 19.99m,
            InvoiceDate = DateTime.Now
          };
          var invoiceItem2 = new Invoice
          {
            InvoiceNumber = invoiceNumber, //same invoice number
            CustomerId = customers.First().Id,
            StockItemId = stockItems.Last().Id,
            Quantity = 1, //added quantity for the second invoice
            SellingPrice = 9.99m,
            InvoiceDate = DateTime.Now
          };

          //add invoices
          context.Invoices.Add(invoiceItem1);
          context.Invoices.Add(invoiceItem2);
          //save changes
          context.SaveChanges();
          Console.WriteLine("Invoices successfully added to the database."); //added confirmation message
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
