namespace Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dettaglio")]
    public partial class Dettaglio
    {
        public int Id { get; set; }

        public int OrdineId { get; set; }

        public int ArticoloId { get; set; }

        public int Quantità { get; set; }

        public virtual Articolo Articolo { get; set; }

        public virtual Ordinazione Ordinazione { get; set; }
    }
}
