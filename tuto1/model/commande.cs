namespace tuto1.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("raven.commande")]
    public partial class commande
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short IDCOMMANDE { get; set; }

        public short IDUTILISATEUR { get; set; }

        public short IDTRANSPORTEUR { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DATE { get; set; }

        public decimal? MONTANT { get; set; }
    }
}
