namespace My_shoppping_site.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order_Detail = new HashSet<Order_Detail>();
        }

        public int pid;
        [Key]
        public int Product_id { get;  set; }

        [Required]
        [StringLength(50)]
        public string Product_Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Product_Price { get; set; }

        [Required]
        [StringLength(200)]
        public string Product_Description { get; set; }

       
        public string Product_Picture { get; set; }

        [StringLength(50)]
        public string Product_Status { get; set; }

        public int Category_Fid { get; set; }
        [NotMapped]
        public int quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Product_Purchase_Price { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }
    }
}
