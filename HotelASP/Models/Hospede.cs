using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelASP.Models
{
    [Table("Hospedes")]
    public class Hospede
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string NomeCompleto
        {
            get
            {
                return Nome + " " + Sobrenome;
            }
        }

        public virtual ICollection <Reserva> Reservas { get; set; }
    }
}