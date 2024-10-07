using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int? UnitsInStock { get; set; }

        public virtual Category? Category { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
