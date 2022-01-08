namespace AprozarModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Furnizori")]
    public partial class Furnizori
    {
        [Key]
        public int FurnizorId { get; set; }

        [StringLength(50)]
        public string Nume { get; set; }

        [StringLength(50)]
        public string Adresa { get; set; }

        public int? ProdusId { get; set; }

        [StringLength(50)]
        public string Cantitate { get; set; }

        public virtual Produse Produse { get; set; }

    /*    public static implicit operator Furnizori(Furnizori v)
        {
            throw new NotImplementedException();
        }
    */
    }
}
