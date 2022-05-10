namespace tuto1.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("raven.utilisateurs")]
    public partial class utilisateurs
    {
        [Key]
        public short IDUTILISATEUR { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(32)]
        public string PSEUDO { get; set; }

        [Column(TypeName = "char")]
        [StringLength(255)]
        public string MOTDEPASSE { get; set; }

        [Column(TypeName = "char")]
        [StringLength(50)]
        public string EMAIL { get; set; }

        public short? DROIT { get; set; }

        [Column(TypeName = "char")]
        [StringLength(255)]
        public string ADRESSE { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string CP { get; set; }

        [Column(TypeName = "char")]
        [StringLength(100)]
        public string VILLE { get; set; }
    }
}
