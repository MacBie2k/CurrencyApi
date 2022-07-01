using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly CurrencyConverterContext _context;
        public RateRepository(CurrencyConverterContext context)
        {
            _context = context;
        }

        public Rate Add(Rate rate)
        {
            
            var createdRate = _context.Rates.Add(rate);
            _context.SaveChanges();
            return rate;
        }

        Rate IRateRepository.GetByCode(string code)
        {
            return _context.Rates.SingleOrDefault(r => r.Code == code);
        }

        public  Rate Update(Rate rate)
        {
            var existingRate = _context.Rates.SingleOrDefault(r => r.Code == rate.Code);
            var updatedRate = _context.Rates.Update(existingRate);
            _context.SaveChanges();
            return updatedRate.Entity;
        }

    }
}
