namespace Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordinazione")]
    public partial class Ordinazione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordinazione()
        {
            Dettaglio = new HashSet<Dettaglio>();
        }
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Indirizzo { get; set; }

        [Required]
        public string Note { get; set; }

        [Column(TypeName = "money")]
        public decimal Totale { get; set; }

        public bool Evaso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dettaglio> Dettaglio { get; set; }

        public virtual User User { get; set; }
    }
}
