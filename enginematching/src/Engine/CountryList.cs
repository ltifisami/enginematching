using System;
using System.Collections.Generic;
using System.Globalization;

namespace Engine
{
    public class CountryList
    {
        public CountryList()
        {
        }
        public static List<string> GetCountryList() 
        {
            // Create liste
            List<string> CultureListe = new List<string>();
            // getting the specific CultureInfo from CultureInfo class of RegionInfo class
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                // creating the object of RegionInfo class
                RegionInfo GetRegionInfo = new RegionInfo(getCulture.LCID);

                // adding each country Name into the arrayList
                if(!(CultureListe.Contains(GetRegionInfo.EnglishName)))
                {

                   
                    CultureListe.Add(GetRegionInfo.EnglishName);

                }

            }
            // trier le tableau avec la méthode Sort()
            CultureListe.Sort();
            //retourner la liste de country

            return CultureListe;
        }


    }
}
