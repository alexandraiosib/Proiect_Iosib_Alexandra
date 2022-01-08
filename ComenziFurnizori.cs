namespace AprozarModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComenziFurnizori")]
    public partial class ComenziFurnizori
    {
        [Key]
        public int ComandaFId { get; set; }

        public int? ProdusId { get; set; }

        public int? FurnizorId { get; set; }

        public string Cantitate { get; set; }

        [StringLength(50)]
        public string Total { get; set; }

        public virtual Produse Produse { get; set; }
    }
}
