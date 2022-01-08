namespace AprozarModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produse")]
    public partial class Produse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produse()
        {
            ComenziClientis = new HashSet<ComenziClienti>();
            ComenziFurnizoris = new HashSet<ComenziFurnizori>();
            Furnizoris = new HashSet<Furnizori>();
        }

        [Key]
        public int ProdusId { get; set; }

        public int? CategorieId { get; set; }

        [StringLength(50)]
        public string Denumire { get; set; }

        [StringLength(50)]
        public string Pret { get; set; }

        [StringLength(50)]
        public string TaraOrigine { get; set; }

        public virtual Categorii Categorii { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComenziClienti> ComenziClientis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComenziFurnizori> ComenziFurnizoris { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Furnizori> Furnizoris { get; set; }
    }
}
