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
    public class TicketsBLL
    {
        private Context _context;

        public TicketsBLL(Context Context)
        {
            _context = Context;
        }

        public bool Existe(int TicketId)
        {
            return _context.Tickets.Any(s => s.TicketId == TicketId);
        }

        private bool Insertar(Tickets tickets)
        {
            _context.Tickets.Add(tickets);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public bool Modificar(Tickets tickets)
        {
            _context.Update(tickets);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public bool Guardar(Tickets tickets)
        {
            if (!Existe(tickets.TicketId))
                return Insertar(tickets);
            else
                return Modificar(tickets);
        }

        public bool Eliminar(Tickets tickets)
        {
            _context.Tickets.Remove(tickets);
            int verificar = _context.SaveChanges();
            return verificar > 0;
        }

        public Tickets? Buscar(int TicketId)
        {
            return _context.Tickets
                .AsNoTracking()
                .FirstOrDefault(s => s.TicketId == TicketId);
        }

        public List<Tickets> GetList(Expression<Func<Tickets, bool>> Criterio)
        {
            return _context.Tickets
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }

        public bool Validar(int ticketId)
        {

            bool confirmar = false;
            try
            {
                confirmar = _context.Tickets.Any(e => e.TicketId == ticketId );
            }
            catch (Exception)
            {
                throw;
            }
            return confirmar;
        }
    }
}