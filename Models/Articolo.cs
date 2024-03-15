namespace Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Articolo")]
    public partial class Articolo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articolo()
        {
            Dettaglio = new HashSet<Dettaglio>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Url immagine")]
        public string Foto { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Prezzo { get; set; }

        [Required]
        [Display(Name = "Tempo di Consegna")]
        public int TempoConsegna { get; set; }

        [Required]
        public string Ingredienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dettaglio> Dettaglio { get; set; }
    }
}
