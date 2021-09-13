namespace My_shoppping_site.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Detail
    {
        [Key]
        public int Od_id { get; set; }

        public int product_fid { get; set; }

        public int Orde_fid { get; set; }

        public int quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Sale_price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal purchase_price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
