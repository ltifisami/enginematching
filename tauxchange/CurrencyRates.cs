using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace tauxchange
{
    public class CurrencyRates
    {
        public string Disclaimer { get; set; }
        public string License { get; set; }
        public int TimeStamp { get; set; }
        public string Base { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
        public DateTime FomatTimeStamp()
        {
            System.DateTime date = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            date = date.AddSeconds(TimeStamp);
            return date;
        }

     public   class OpenExchange
        {
            private T _download_serialized_json_data<T>(string url) where T : new()
            {
                using (var w = new WebClient())
                {
                   
                    var json_data = string.Empty;
                    // attempt to download JSON data as a string
                   
                    try
                    {
                        json_data = w.DownloadString(url);
                    }
                    catch (Exception) { }

                    // if string with JSON data is not empty, deserialize it to class and return its instance

                    return !string.IsNullOrEmpty(json_data) ?
                    JsonConvert.DeserializeObject<T>(json_data) : new T();
                }
            }
            public CurrencyRates getCurrencyRates()
            {            // pour les derniers taux
                var url = "https://openexchangerates.org/api/latest.json?app_id=id=598f07044ff143f19feebcdf138206cc";
                Console.WriteLine("url est ...... "+url);
                var currencyRates = _download_serialized_json_data<CurrencyRates>(url);

                return currencyRates;
               
            }
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                //ExcelOperation excel = new ExcelOperation();
                OpenExchange openExchange = new OpenExchange();
                var currencyRates = openExchange.getCurrencyRates();
                //excel.wirteToExcel(currencyRates, "Devises");

                Console.WriteLine(currencyRates.ToString());
            }


        }
    }
}
