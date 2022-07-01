using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRateService
    {
        RateDto GetRateByCode(string code);
        RateDto Add(RateDto rate);
        RateDto Update(RateDto rate);
    }
}
