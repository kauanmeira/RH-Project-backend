using System;
using System.Collections.Generic;
using System.Linq;
using RH_Project.Models;
using RH_Project.Data;
using RH_Project.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace RH_Project.Services
{
    public class HoleriteService
    {
        private readonly Contexto _context;

        public HoleriteService(Contexto context)
        {
            _context = context;
        }

        public List<Holerite> GetAllHolerites()
        {
            return _context.Holerite
                .Include(h => h.Colaborador) // Certifique-se de incluir os dados do colaborador
                .ToList();
        }


        public Holerite GetHoleriteById(int id)
        {
            return _context.Holerite.Find(id);
        }

        public void InsertHolerite(Holerite holerite)
        {
            _context.Holerite.Add(holerite);
            _context.SaveChanges(); // Salva as alterações no banco
        }

        public void UpdateHolerite(Holerite holerite)
        {
            _context.Update(holerite);
            _context.SaveChanges();
        }

        public void DeleteHolerite(int id)
        {
            var holerite = _context.Holerite.Find(id);
            if (holerite == null)
            {
                throw new NotFoundException("Holerite not found");
            }

            _context.Holerite.Remove(holerite);
            _context.SaveChanges();
        }
    }
}