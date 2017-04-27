using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelASP.Models
{
    [Table("Reservas")]
    public class Reserva
    {
        [DisplayName("#Reservar")]
        public int ReservaID { get; set; }

        [DisplayName("Quarto")]
        public int QuartoID { get; set; }

        [DisplayName("Hospede")]
        public int HospedeID { get; set; }

        [DisplayName("Check-In")]
        public DateTime CheckIn { get; set; }

        [DisplayName("Check-Out")]
        public DateTime CheckOut { get; set; }

        public virtual Quarto Quarto { get; set; }
        public virtual Hospede Hospede { get; set; }
    }
}