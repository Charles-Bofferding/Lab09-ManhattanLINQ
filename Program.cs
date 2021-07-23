using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab09_ManhattanLINQ
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            List<Feature> featureList = LoadJson();
            //Console.WriteLine(neighborhoods);
            Console.WriteLine("Hello World2!");

            Console.WriteLine("Output all of the neighborhoods in this data list (Final Total: 147 neighborhoods)");
            var filter1 = new List<Feature>();
            foreach (var item in featureList)
            {
                filter1.Add(item.properties.neighborhood);
            }
            Console.WriteLine(filter1);

            Console.WriteLine("Filter out all the neighborhoods that do not have any names(Final Total: 143)");
            var filter2 = new List<Feature>();
            foreach (var item in filter1)
            {
                if (item != null)
                {
                    filter2.Add(item);
                }
            }
            Console.WriteLine(filter2);

            Console.WriteLine("Remove the duplicates (Final Total: 39 neighborhoods)");
            var filter3 = new List<Feature>();
            foreach (var item in filter2)
            {
                if(!filter3.Contains(item))
                {
                    filter3.Add(item);
                }
            }
            Console.WriteLine(filter3);



        }

        //This came from an answer at stack overflow mostly
        //https://stackoverflow.com/questions/13297563/read-and-parse-a-json-file-in-c-sharp
        //Funnily enough it doesn't seem to work
        public static List<Feature> LoadJson()
        {
            using (StreamReader r = new StreamReader("../../../data.json"))
            {
                string json = r.ReadToEnd();
                List<Feature> items = JsonConvert.DeserializeObject<List<Feature>>(json);
                return items;
            }
        }

        //setup object
        public class Feature
        {
            public string type;
            public Geometry geometry;
            public Properties properties;
        }

        public class Geometry
        {
            public string type;
            public string[] coordinates;
        }
        
        public class Properties
        {
            public string zip;
            public string city;
            public string state;
            public string address;
            public string borough;
            public string neighborhood;
            public string county;
        }
        /*
             {
      "type": "Feature",
      "geometry": {
        "type": "Point",
        "coordinates": [
          -74.013854,
          40.70387
        ]
      },
      "properties": {
        "zip": "10004",
        "city": "New York",
        "state": "NY",
        "address": "",
        "borough": "Manhattan",
        "neighborhood": "Financial District",
        "county": "New York County"
      }
    }, 
         */

        //create array of those objects

        //filter the stuff


        /* 
         
         */

        //Sample from https://www.newtonsoft.com/json/help/html/DeserializeObject.htm
        /*
        public class Account
        {
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedDate { get; set; }
            public IList<string> Roles { get; set; }
        }

        Account account = JsonConvert.DeserializeObject<Account>(json);

        Console.WriteLine(account.Email);
        */

    }
}
