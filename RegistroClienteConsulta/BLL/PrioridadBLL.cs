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
    public class PrioridadBLL
    {
        private Context _context;
        public PrioridadBLL(Context Context) { 
            _context = Context; 
        }
        public bool Existe(int PrioridadId)
        {
            return _context.Prioridad.Any(s => s.PrioridadId == PrioridadId);
        }
        private bool Insertar(Prioridades prioridad)
        {
            _context.Prioridad.Add(prioridad);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public bool Modificar(Prioridades prioridad)
        {
            _context.Update(prioridad);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }
        public bool Guardar(Prioridades prioridad)
        {
            if (!Existe(prioridad.PrioridadId))
                return Insertar(prioridad);
            else 
                return Modificar(prioridad);
        }
        public bool Eliminar(Prioridades prioridad)
        {
            _context.Prioridad.Remove(prioridad);
            int verificar = _context.SaveChanges();
            return verificar > 0;    
        }
        public Prioridades? Buscar(int PrioridadId)
        {
            return _context.Prioridad
                .AsNoTracking()
                .FirstOrDefault(s => s.PrioridadId == PrioridadId);
        }
        public List<Prioridades> GetList(Expression<Func<Prioridades, bool >> Criterio)
        {
            return _context.Prioridad
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }
        public bool Validar(string? descripcion)
        {
            bool confirmar = false;
            try
            {
                confirmar = _context.Prioridad.Any(e => e.Descripcion.ToLower() == descripcion.ToLower());
            }
            catch (Exception)
            {
                throw;
            }

            return confirmar;
        }

    }
}
