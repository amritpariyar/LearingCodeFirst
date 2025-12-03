using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearingCodeFirst.Entitties
{
  internal class Invoice
  {
    //Primary key of the Invoice Table
    public int Id {  get; set; }
    public DateTime InvoiceDate {  get; set; }
    //Foreign Key From the Customer table
    public int CustomerId {  get; set; }
    //Foreign Key From the StockItable table
    public int StockItemId {  get; set; }
    public decimal Quantity {  get; set; }
    public decimal SellingPrice { get; set; }


    //Navigation property, only used for navigation and Referencing Table 
    //In EntityFramework, if EntityClass is a virtual property and field name above is
    //matched along with Id (here CustomerId), it automatically assumes and assigns Foreign Key
    public virtual Customer Customer { get; set; }

    //StockItem is in ICollection because in One Invoice there will me multiple StockItems
    //Customer is only one in one Invoice.
    public virtual ICollection<StockItem> StockItem { get; set; }
    
  }
}
