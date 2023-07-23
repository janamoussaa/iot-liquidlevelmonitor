using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDataSerialPort
{
    class CallApiGetRequest
    {
        public static async void MakeHttpRequest(string sensorsReadings)
        {
            string AllLink = "http://localhost:56111/iot_sensors_readings/postSensorReading?" + sensorsReadings;
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(AllLink);
                if (Res.IsSuccessStatusCode)
                    Console.WriteLine( Res.Content.ReadAsStringAsync().Result);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
