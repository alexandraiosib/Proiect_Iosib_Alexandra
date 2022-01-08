namespace AprozarModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComenziClienti")]
    public partial class ComenziClienti
    {
        [Key]
        public int ComandaCId { get; set; }

        public int? ProdusId { get; set; }

        public int? ClientId { get; set; }

        [StringLength(50)]
        public string Cantitate { get; set; }

        [StringLength(50)]
        public string Total { get; set; }

        public virtual Clienti Clienti { get; set; }

        public virtual Produse Produse { get; set; }
    }
}
