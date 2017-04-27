using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelASP.Models
{
    public enum Tipo
    {
        Standard, Luxo, Master, Presidential
    }

    [Table("Quartos")]
    public class Quarto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Numero do AP")]
        public int QuartoID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Tipo Tipo { get; set; }
        [DisplayName("R$ Diaria")]
        public double ValorDiaria { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}