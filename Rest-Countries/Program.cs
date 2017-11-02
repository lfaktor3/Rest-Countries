using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Rest_Countries
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader oSr = new StreamReader("Countries.json");
            string sJson = "";
            using (oSr)
            {
                sJson = oSr.ReadToEnd();
            }
            JObject oJson = JObject.Parse(sJson);
            var oCountries = oJson["countries"].ToList();
            List<Countries> lCountries = new List<Countries>();
            for (int i = 0; i< oCountries.Count; i++)
            {
                lCountries.Add(new Countries
                {
                    sName = (string)oCountries[i]["name"],
                    sCapital = (string)oCountries[i]["capital"],
                    sCode = (string)oCountries[i]["alpha2Code"],
                    sCode2 = (string)oCountries[i]["alpha3Code"],
                    fArea = (long)oCountries[i]["area"],
                    nPopulation = (int)oCountries[i]["population"]
                });
            }
            for (int i = 0; i < lCountries.Count; i++)
            {
                Console.WriteLine("----------------------------------------\nDrzava: " + lCountries[i].sName + "\nglavni grad: " + lCountries[i].sCapital + "\nPopulacija: " + lCountries[i].nPopulation + "\nPodrucje: " + lCountries[i].fArea + "\nOznaka drzave: " + lCountries[i].sCode + "\\" + lCountries[i].sCode2 +  "\n----------------------------------------");
            }
            var OrderByQuery = from c in lCountries.OrderBy(o => o.nPopulation) select c;
            List<Countries> lSortedCountries = OrderByQuery.ToList();
            for (int i = 0; i < lSortedCountries.Count; i++)
            {
                
                Console.WriteLine("----------------------------------------\nDrzava: " + lSortedCountries[i].sName + "\nglavni grad: " + lSortedCountries[i].sCapital + "\nPopulacija: " + lSortedCountries[i].nPopulation + "\nPodrucje: " + lSortedCountries[i].fArea + "\nOznaka drzave: " + lSortedCountries[i].sCode + "\\" + lSortedCountries[i].sCode2 + "\n----------------------------------------");
            }
            Console.ReadKey();
        }
    }
}