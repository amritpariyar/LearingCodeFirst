using System;
using System.Collections.Generic;
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
      using (var context = new BillingDb())
      {
        //insert one customer
        var customer = new Customer
        {
          Name = "Hari Sharma",
          Address = "Bharatpur",
          ContactNo = "9841000000"
        };
        context.Customers.Add(customer);
        context.SaveChanges();

        //insert three stockitem
        var stockItem1 = new StockItem
        {
          Name = "Laptop",
          Description = "Dell Inspiron 15 3000",
          Price = 599.99m
        };

        var stockItem2 = new StockItem
        {
          Name = "Mouse",
          Description = "Wireless Optical Mouse",
          Price = 25.50m
        };

        var stockItem3 = new StockItem
        {
          Name = "Keyboard",
          Description = "Mechanical Gaming Keyboard",
          Price = 89.99m
        };

        context.StockItems.Add(stockItem1);
        context.StockItems.Add(stockItem2);
        context.StockItems.Add(stockItem3);
        context.SaveChanges();

        //insert one invoice with created one customer and two stockItems
        var invoice1 = new Invoice
        {
          InvoiceDate = DateTime.Now,
          CustomerId = customer.Id,
          StockItemId = stockItem1.Id, // Using the first stock item
          Quantity = 1,
          SellingPrice = stockItem1.Price
        };

        var invoice2 = new Invoice
        {
          InvoiceDate = DateTime.Now,
          CustomerId = customer.Id,
          StockItemId = stockItem2.Id, // Using the second stock item
          Quantity = 2,
          SellingPrice = stockItem2.Price
        };

        context.Invoices.Add(invoice1);
        context.Invoices.Add(invoice2);
        context.SaveChanges();

        Console.WriteLine("Data inserted successfully!");
        Console.WriteLine($"Customer: {customer.Name}");
        Console.WriteLine($"Stock Items: {stockItem1.Name}, {stockItem2.Name}, {stockItem3.Name}");
        Console.WriteLine($"Invoices created for {customer.Name} with {stockItem1.Name} and {stockItem2.Name}");
        Console.ReadLine();
      }
    }
  }
}
