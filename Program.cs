using PrePass.Models;
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
            //           client.BaseAddress = new Uri("http://localhost:14504/");

            client.BaseAddress = new Uri("https://prepass.azurewebsites.net/");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/apireports");


            if (response.IsSuccessStatusCode)
            {
                Report reports = await response.Content.ReadAsAsync<Report>();
                Report empty = new Report();


                Console.WriteLine(reports.ToString());

                //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]

                
                foreach (ReportItem r in reports.Incomes)
                {
                    Console.WriteLine(r.Item.ToString() + " " + r.Count.ToString());
                }

                foreach (ReportItem r in reports.Children)
                {
                    Console.WriteLine(r.Item.ToString() + " " + r.Count.ToString());
                }

                foreach (ReportItem r in reports.Ethnicities)
                {
                    Console.WriteLine(r.Item.ToString() + " " + r.Count.ToString());
                }

                foreach (ReportItem r in reports.Genders)
                {
                    Console.WriteLine(r.Item.ToString() + " " + r.Count.ToString());
                }

                foreach (ReportItem r in reports.Households)
                {
                    Console.WriteLine(r.Item.ToString() + " " + r.Count.ToString());
                }

                foreach (ReportItem r in reports.Reasons)
                {
                    Console.WriteLine(r.Item.ToString() + " " + r.Count.ToString());
                }

                foreach (ReportItem r in reports.Statuses)
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