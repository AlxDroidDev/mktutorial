using CaseConversion.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net;
using System.Net.Sockets;

namespace CaseConversion.Web.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {

        private APIClient apiClient = new APIClient(new System.Net.Http.HttpClient());



        [BindProperty]
        public ConvertRequest ConvertRequest { get; set; }


        [BindProperty]
        public ConvertResponse ConvertResponse { get; set; }

        public EnvConfig config = EnvConfig.Instance;

        public string LocalIPAddress
        {
            get => GetLocalIPAddress();
        }

        public string RemoteClientAddress
        {
            get => GetRemoteIpAdress();
        }

        public void OnGet()
        {
            System.Diagnostics.Debug.WriteLine("Host: " + config.host + "      Port: " + config.port);
            this.ConvertRequest = new ConvertRequest();
            this.ConvertRequest.CaseType = ConversionCaseType.FATORIAL;
            this.ConvertRequest.Sentence = "Exemplo de SentEnCa a TER sua CASE altErAdA";
        }


        public async void OnPost()
        {
            System.Diagnostics.Debug.WriteLine("Request: " + ConvertRequest.ToString());
            ConvertResponse response = apiClient.ConvertCaseAsync(ConvertRequest).Result;
            
            if (response != null)
            {
                System.Diagnostics.Debug.WriteLine("Response: " + response.ToString());
                this.ConvertResponse = response;
            }

        }


        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private string GetRemoteIpAdress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        /*

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

        }


    */

    }
}
