using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSenorialModels.Senorial
{
    [Table("conteo_dinero", Schema = "Ventas")]
    public class ConteoDinero
    {
        [Key]
        [Column("id_conteo")]
        public int IdConteo { get; set; }

        [ForeignKey("AperturaCaja")]
        [Column("id_apertura")]
        public int IdApertura { get; set; }

        [Column("denominacion", TypeName = "decimal(10, 2)")]
        public decimal Denominacion { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [NotMapped]
        public decimal Subtotal => Denominacion * Cantidad;

        [InverseProperty("Conteos")]
        public virtual AperturaCaja AperturaCaja { get; set; }
    }
}
