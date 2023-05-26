using System;
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
    public class ClientesBLL
    {
        private Context _context;
        public ClientesBLL(Context Context)
        {
            _context = Context;
        }
        public bool Existe(int ClienteId)
        {
            return _context.Cliente.Any(s => s.ClienteId == ClienteId);
        }
        private bool Insertar(Clientes cliente)
        {
            _context.Cliente.Add(cliente);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public bool Modificar(Clientes cliente)
        {
            _context.Update(cliente);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }
        public bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))
                return Insertar(cliente);
            else
                return Modificar(cliente);
        }
        public bool Eliminar(Clientes cliente)
        {
            _context.Cliente.Remove(cliente);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }
        public Clientes? Buscar(int ClienteId)
        {
            return _context.Cliente
                .AsNoTracking()
                .FirstOrDefault(s => s.ClienteId == ClienteId);
        }
        public List<Clientes> GetList(Expression<Func<Clientes, bool>> Criterio)
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
                confirmar = _context.Cliente.Any(e => e.Nombre.ToLower() == nombre.ToLower()  && e.Rnc == Rnc );

            }
            catch (Exception)
            {
                throw;
            }

            return confirmar;
        }

    }
}

