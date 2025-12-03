using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearingCodeFirst.Entitties
{
  internal class StockItem
  {
    //for the primary key, we must give field name as Id or ClassNameId.
    //if we name Id, or StockItemId
    //EntityFramerwork automatically recognize and assign them as Primary Key.
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
  }
}
