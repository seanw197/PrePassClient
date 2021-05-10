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

    //public static class ListDisplayName
    //{
    //    // get the display name for a given enum value
    //    public static string GetDisplayName(this IList Value)
    //    {
    //        return Value.GetType().GetMember(Value.ToString())
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

            //Sean's
            client.BaseAddress = new Uri("https://prepass.azurewebsites.net/");

            //Niamh's
            //client.BaseAddress = new Uri("https://prepass20210501170450.azurewebsites.net/");


            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/apireports");


            if (response.IsSuccessStatusCode)
            {
                Report reports = await response.Content.ReadAsAsync<Report>();
                Report empty = new Report();


                Console.WriteLine(reports.ToString());

                //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]

                Console.WriteLine("\nGENDER DISTRIBUTION\n");
                foreach (ReportItem r in reports.Genders)
                {
                    Console.WriteLine(r.Item.ToString() + ": " + r.Count.ToString());
                }

                Console.WriteLine();

                Console.WriteLine("ETHNIC DISTRIBUTION\n");

                foreach (ReportItem r in reports.Ethnicities)
                {
                    Console.WriteLine(r.Item.ToString() + ": " + r.Count.ToString());
                }

                Console.WriteLine();

                Console.WriteLine("REASON FOR HOMELESSNESS\n");
                foreach (ReportItem r in reports.Reasons)
                {
                    Console.WriteLine(r.Item.ToString() + ": " + r.Count.ToString());
                }

                Console.WriteLine();

                Console.WriteLine("HOUSEHOLD TYPE\n");

                foreach (ReportItem r in reports.Households)
                {
                    Console.WriteLine(r.Item.ToString() + ": " + r.Count.ToString());
                }

                Console.WriteLine();

                Console.WriteLine("DISTRICT\n");

                foreach (ReportItem r in reports.Districts)
                {
                    Console.WriteLine(r.Item.ToString() + ": " + r.Count.ToString());
                }

                Console.WriteLine();

                Console.WriteLine("CHILDREN\n");

                foreach (ReportItem r in reports.Children)
                {
                    Console.WriteLine(r.Item.ToString() + ": " + r.Count.ToString());
                }

                Console.WriteLine();

                Console.WriteLine("INCOME STATUS\n");
                foreach (ReportItem r in reports.Incomes)
                {
                    Console.WriteLine(r.Item.ToString() + ": " + r.Count.ToString());
                }

                Console.WriteLine();

                Console.WriteLine("ADDICTION STATUS\n");

                foreach (ReportItem r in reports.Addictions)
                {
                    Console.WriteLine(r.Item.ToString() + ": " + r.Count.ToString());
                }

                Console.WriteLine();

                Console.WriteLine("ASSESSMENT STATUS\n");

                foreach (ReportItem r in reports.Statuses)
                {
                    Console.WriteLine(r.Item.ToString() + ": " + r.Count.ToString());
                }

                Console.WriteLine();

            }

            else
            {
                Console.WriteLine(response.StatusCode + " Reason Phrase: " + response.ReasonPhrase);
            }
        }
    }
}