using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.ExtensionMethods
{
    public static class CurrencyExtensionMethods
    {
        public static async Task<RateDto> GetRateAsync(string path)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.nbp.pl/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(path);

                if (response.IsSuccessStatusCode)
                {
                    var responseRate = await response.Content.ReadAsAsync<NbpResponseDto>();
                    var rate = new RateDto { Code = responseRate.Code,
                        EffectiveDate = responseRate.Rates.First<NbpResponseRatesDto>().EffectiveDate, Mid = responseRate.Rates.First<NbpResponseRatesDto>().Mid
                    };
                    return rate;
                }
                return null;
            }
            
        }
    }
}
