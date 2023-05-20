﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RegistroClienteConsulta.DAL;
using RegistroClienteConsulta.Model;
using System.Diagnostics.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace RegistroClienteConsulta.BLL
{
    public class ClienteBLL
    {
        private Context _context;
        public ClienteBLL(Context Context)
        {
            _context = Context;
        }
        public bool Existe(int ClienteId)
        {
            return _context.Cliente.Any(s => s.ClienteId == ClienteId);
        }
        private bool Insertar(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public bool Modificar(Cliente cliente)
        {
            _context.Update(cliente);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }
        public bool Guardar(Cliente cliente)
        {
            if (!Existe(cliente.ClienteId))
                return Insertar(cliente);
            else
                return Modificar(cliente);
        }
        public bool Eliminar(Cliente cliente)
        {
            _context.Cliente.Remove(cliente);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }
        public Cliente? Buscar(int ClienteId)
        {
            return _context.Cliente
                .AsNoTracking()
                .FirstOrDefault(s => s.ClienteId == ClienteId);
        }
        public List<Cliente> GetList(Expression<Func<Cliente, bool>> Criterio)
        {
            return _context.Cliente
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
        public bool Validar(string? nombre, double Rnc)
        {

            bool confirmar = false;
            try
            {
                confirmar = _context.Cliente.Any(e => e.Nombre.ToLower() == nombre.ToLower() && e.Rnc == Rnc );

            }
            catch (Exception)
            {
                throw;
            }

            return confirmar;
        }

    }
}
