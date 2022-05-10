namespace tuto1.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("raven.collaborateur")]
    public partial class collaborateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short IDCOLLABORATEUR { get; set; }

        [Column(TypeName = "char")]
        [StringLength(255)]
        public string NOM { get; set; }

        [Column(TypeName = "char")]
        [StringLength(255)]
        public string ADRESSE { get; set; }

        [Column(TypeName = "char")]
        [StringLength(10)]
        public string TELEPHONE { get; set; }

        [Column(TypeName = "char")]
        [StringLength(255)]
        public string EMAIL { get; set; }
    }
}
