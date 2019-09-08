using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopee.Model.Models
{
    [Table("OrderDetails")]
   public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [Key]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
