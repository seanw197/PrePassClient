﻿using PrePassClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrePassClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllReports().Wait();
        }

        public static async Task GetAllReports()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:14504/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/apireports");


            if (response.IsSuccessStatusCode)
            {
                IEnumerable<ReportItem> reports = await response.Content.ReadAsAsync<IEnumerable<ReportItem>>();


                foreach (ReportItem r in reports)
                {
                    Console.WriteLine(r.ToString());
                }
            }
            //if (response.IsSuccessStatusCode)
            //{
            //    IEnumerable<Report> reports = await response.Content.ReadAsAsync<IEnumerable<Report>>();

            //    foreach (Report r in reports)
            //    {
            //        Console.WriteLine(r);
            //    }
            //}
            else
                {
                Console.WriteLine(response.StatusCode + " Reason Phrase: " + response.ReasonPhrase);
            }
        }
    }
}
