using HotelASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HotelASP.DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base("HotelASP")
        {
        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Hospede> Hospedes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Quarto> Quartos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}