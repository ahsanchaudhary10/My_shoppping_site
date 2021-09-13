namespace My_shoppping_site.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Order_Detail = new HashSet<Order_Detail>();
        }

        [Key]
        public int Order_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Person_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Person_Phone { get; set; }

        [StringLength(50)]
        public string Person_Email { get; set; }

        [Required]
        [StringLength(250)]
        public string Person_Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Payment_Method { get; set; }

        public DateTime Order_Datetime { get; set; }

        [Required]
        [StringLength(50)]
        public string Order_Status { get; set; }

        [Required]
        [StringLength(50)]
        public string Order_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }
    }
}
