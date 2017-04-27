using HotelASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelASP.DAL
{
    public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Contexto>
    {
        protected override void Seed(Contexto context)
        {
            var hospedes = new List<Hospede>
            {
            new Hospede{Nome="Junior",Sobrenome="Machado",CPF="059.271.559-01",Email="junior@up.com.br",Endereco="Rua Atilio Borio, 51 Ap 703"},
            new Hospede{Nome="Carlos",Sobrenome="Fonseca",CPF="034.441.009-18",Email="carlos@up.com.br",Endereco="Rua dos bobos n0"},
            };

            hospedes.ForEach(s => context.Hospedes.Add(s));
            context.SaveChanges();
            var quartos = new List<Quarto>
            {
            new Quarto{QuartoID=104,Nome="Apartamento 104",Descricao="Apartamento Standard com 2 camas de solteiro",ValorDiaria=150.00,Tipo=Tipo.Standard},
            new Quarto{QuartoID=214,Nome="Suite 214",Descricao="Suite com 1 cama de Super King",ValorDiaria=250.00,Tipo=Tipo.Master},
            };
            quartos.ForEach(s => context.Quartos.Add(s));
            context.SaveChanges();
            var reservas = new List<Reserva>
            {
            new Reserva{HospedeID=1,QuartoID=214,CheckIn=DateTime.Parse("2017-04-25"),CheckOut=DateTime.Parse("2017-05-01")},
            new Reserva{HospedeID=2,QuartoID=104,CheckIn=DateTime.Parse("2017-05-15"),CheckOut=DateTime.Parse("2017-05-30")},
            };
            reservas.ForEach(s => context.Reservas.Add(s));
            context.SaveChanges();
            var Hotel = new Hotel { CNPJ = "000000001/19", RazaoSocial = "ASP.NET hotelaria e eventos LTDA", Nome = "Hotel ASP", Endereco = "Rua Americo Goncalves 1534, Centro, Curitiba - Parana _ Brazil" };
            context.Hotel.Add(Hotel);
            context.SaveChanges();
        }
    }
}