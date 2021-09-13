namespace My_shoppping_site.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADmin")]
    public partial class ADmin
    {
        [Key]
        public int Admin_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Phone { get; set; }

        [Required]
        [StringLength(250)]
        public string Admin_Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Admin_Email { get; set; }
    }
}
