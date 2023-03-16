using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorWalut2
{
     
    public class ExchangeRateProcessor
    {
        public static async Task<List<Rate>> LoadData()
        {
            string url = $"http://api.nbp.pl/api/exchangerates/tables/a/?format=json";
            //Root data;

            using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {


                    var json = await ApiHelper.apiClient.GetStringAsync(url);
                   var data = JsonConvert.DeserializeObject<List<Table>>(json);

                    return data[0].rates;
                        
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }


            
        }
    }
}
