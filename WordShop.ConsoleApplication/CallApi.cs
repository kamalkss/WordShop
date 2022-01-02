using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WordShop.ConsoleApplication
{
    public class CallApi
    {
        private static readonly HttpClient Client = new HttpClient();
        private static readonly Uri uri = new Uri("http://localhost:5013/api/PostCode");
        public CallApi()
        {
            
            Client.BaseAddress = uri;
            Client.Timeout = TimeSpan.MaxValue;
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
        public static async Task DownloadData()
        {
            try
            {
                var response =  await Client.GetAsync(uri);
                if (!response.IsSuccessStatusCode)
                {
                     Console.WriteLine("There was an error on Download or Extract the data");
                }

                Console.WriteLine("Download and import was Successful ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // Function to get PostCode details

        public static async Task GetPostCodeDetails(string postcode)
        {
            var SendJustPostCode = new PostClass { postcode = postcode };
            var testUri = string.Format($"/postcode?postcode={postcode}");
            var RequestUri = new Uri(uri + testUri);
            GetFunction(RequestUri);
        }

        //Function to Get PostCodes with Radius Range

        public static async Task GetPostCodesWithRanges(string postcode, int range)
        {
            var SendJustPostCode = new PostClass { postcode = postcode };
            var testUri = string.Format($"/postcoderange?postcode={postcode}&range={range}");
            var RequestUri = new Uri(uri + testUri);
            GetFunction(RequestUri);
        }

        //Function to Get PostCodes with Coordinate

        public static async Task GetPostCodesWithCoordinate(double lat, double lng)
        {
            var testUri = string.Format($"/coordinate?lat={lat}&lng={lng}");
            var RequestUri = new Uri(uri + testUri);
            GetFunction(RequestUri);
        }

        //Function to Get PostCodes with Coordinate and range

        public static async Task GetPostCodesWithCoordinateAndRange(double lat, double lng,int range)
        {
            var testUri = string.Format($"/coordinate?lat={lat}&lng={lng}&range={range}");
            var RequestUri = new Uri(uri + testUri);
            GetFunction(RequestUri);
        }



        public static async Task GetFunctionAsyncForJson(PostClass SendJustPostCode,Uri uri)
        {
            try
            {
                var jsonSendJustPostCode = JsonConvert.SerializeObject(SendJustPostCode);
                var httpContent = new StringContent(jsonSendJustPostCode, Encoding.UTF8, MediaTypeNames.Application.Json);

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                    Content = httpContent
                };

                var GetDetails = await Client.SendAsync(request).ConfigureAwait(false);

                if (GetDetails.Content != null)
                {
                    var responseContent = await GetDetails.Content.ReadAsStringAsync();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
                    var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
                    Console.WriteLine(f);
                }
                else
                {
                    Console.WriteLine("There was no Data to show");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }


        public static void GetFunction(Uri uri)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri
                };
                var getDetails = Client.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
                if (getDetails.Content != null)
                {
                    var responseContent = getDetails.Content.ReadAsStringAsync().Result;
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
                    var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
                    Console.WriteLine(f);
                }
                else
                {
                    Console.WriteLine("There was no Data to show");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
        }
    }
}
