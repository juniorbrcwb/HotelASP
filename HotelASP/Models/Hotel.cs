using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelASP.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        [DisplayName("Razao Social")]
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }

    }
}