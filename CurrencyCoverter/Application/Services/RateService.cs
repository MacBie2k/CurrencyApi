using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ExtensionMethods;
using Domain.Entities;

namespace Application.Services
{
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;
        private readonly IMapper _mapper;
        public RateService(IRateRepository rateRepository, IMapper mapper)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
        }
        public RateDto GetRateByCode(string code)
        {
            var rate = _rateRepository.GetByCode(code);
            if (rate == null)
            {
                var x = CurrencyExtensionMethods.GetRateAsync($"exchangerates/rates/a/{code}/");
                x.Wait();
                if (x.Result == null)
                    return null;
                return Add(x.Result);
            }
            else if (rate.EffectiveDate != DateTime.Now.ToString("yyyy-MM-dd"))
            {

                var x = CurrencyExtensionMethods.GetRateAsync($"exchangerates/rates/a/{code}/");
                x.Wait();
                if (x.Result == null || x.Result.EffectiveDate == rate.EffectiveDate)
                    return _mapper.Map<RateDto>(rate);
                return Update(x.Result);
            }

            return _mapper.Map<RateDto>(rate);
        }

        public RateDto Add(RateDto rateDto)
        {
            if (rateDto == null)
                throw new ArgumentNullException(nameof(rateDto));
            var rate = _mapper.Map<Rate>(rateDto);
            _rateRepository.Add(rate);
            return rateDto;
        }

        public RateDto Update(RateDto rateDto)
        {
            if (rateDto == null)
                throw new ArgumentNullException(nameof(rateDto));
            var rate = _mapper.Map<Rate>(rateDto);
            _rateRepository.Update(rate);
            return rateDto;
        }
    }
}
