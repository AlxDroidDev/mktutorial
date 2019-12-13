using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace CaseConversion.Web.Pages.healthz
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public class IndexModel : PageModel
    {

        private APIClient apiClient = new APIClient(new System.Net.Http.HttpClient());

        private const string OK = "OK";

        public IActionResult OnGet()
        {
            var response = apiClient.HealthAsync().Result;

            try
            {
                if (OK.Equals(response))
                {
                    ContentResult result = new ContentResult();
                    result.Content = OK;
                    Response.Headers.Add("LivenessStatus", OK);
                    return result;
                }
            } catch
            {  }
            return new StatusCodeResult(503);

            //Response.Clear();
            //Response.StatusCode = 200;
            //Response.Headers.Add("LivenessStatus", "Ok");
            //Response.ContentType = "text/plain; charset=UTF-8";

            //WriteToBody(Response.Body, "OK\n0\n\n");
            //WriteToBody(Response.Body, "TESTE");

            //var text = "OK\n";
            //byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
            //Response.Body.Write(data, 0, data.Length);
            //Response.Body.Write(null, 0, 0);

            //Response.Body.Close();





        }


        private void WriteToBody(Stream body, string text)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
            body.Write(data, 0, data.Length);

        }


    }



}
