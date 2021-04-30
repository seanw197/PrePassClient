using PrePassClient.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace PrePassClient
{

    //public static class EnumDisplayName
    //{
    //    // get the display name for a given enum value
    //    public static string GetDisplayName(this Enum enumValue)
    //    {
    //        return enumValue.GetType().GetMember(enumValue.ToString())
    //                       .First()
    //                       .GetCustomAttribute<DisplayAttribute>()
    //                       .GetName();
    //    }
    //}
    class Program 
    {
        static void Main(string[] args)
        {
            GetAllReports().Wait();
        }

        private static async Task GetAllReports()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:14504/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/apireports");


            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Report> reports = await response.Content.ReadAsAsync<IEnumerable<Report>>();

                foreach (ReportItem r in reports.Reasons)
                {
                    Console.WriteLine(r.Item.ToString() + " " + r.Count.ToString());
                }

                foreach (Report r in reports)
                {
                    Console.WriteLine(r.Item.ToString() + " " + r.Count.ToString());
                }
            }
          
            else
                {
                Console.WriteLine(response.StatusCode + " Reason Phrase: " + response.ReasonPhrase);
            }
        }
    }
}
