namespace tuto1.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("produits")]
    public partial class produits
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string nom { get; set; }

        [Required]
        [StringLength(255)]
        public string prix { get; set; }

        [Required]
        [StringLength(255)]
        public string image { get; set; }
    }
}
