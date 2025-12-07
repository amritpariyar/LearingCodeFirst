using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearingCodeFirst.Entitties
{
  internal class Invoice
  {
    //Primary key of the Invoice Table
    public int Id {  get; set; }
    
    [Required]
    public int InvoiceNumber {  get; set; }
    
    public DateTime InvoiceDate {  get; set; }
    
    //Foreign Key From the Customer table
    [Required]
    public int CustomerId {  get; set; }
    
    //Foreign Key From the StockItem table
    [Required]
    public int StockItemId {  get; set; }
    
    public decimal Quantity {  get; set; }
    public decimal SellingPrice { get; set; }


    //Navigation property, only used for navigation and Referencing Table 
    //In EntityFramework, if EntityClass is a virtual property and field name above is
    //matched along with Id (here CustomerId), it automatically assumes and assigns Foreign Key
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; }

    //Navigation property for StockItem
    [ForeignKey("StockItemId")]
    public virtual StockItem StockItem { get; set; }
    
  }
}
