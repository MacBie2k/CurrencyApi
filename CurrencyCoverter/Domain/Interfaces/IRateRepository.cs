using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRateRepository
    {
        Rate GetByCode(string code);
        Rate Add(Rate rate);
        Rate Update(Rate rate);
    }
}
