using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearingCodeFirst.Entitties
{
  internal class Customer
  {
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [MinLength(3)]
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNo { get; set; }
  }
}
