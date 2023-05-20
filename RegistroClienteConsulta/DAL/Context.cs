﻿using Microsoft.EntityFrameworkCore;
using RegistroClienteConsulta.Model;
using System.ComponentModel.DataAnnotations;

namespace RegistroClienteConsulta.DAL
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

    }
}
