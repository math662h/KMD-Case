using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CaseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://valutakurser.azurewebsites.net/"); // Base Uri

            var response = client.GetAsync("valutakurs").Result; //endpoint

            string data = response.Content.ReadAsStringAsync().Result;

            System.Console.WriteLine(data);


            Rootobject r = JsonConvert.DeserializeObject<Rootobject>(data); //deserialize json 

            //Console.WriteLine(r.updatedAt);

           // Task.Run(async () => {
            //    await UpdateXYZ(r);
            //});

        }
        public static async Task UpdateXYZ(Rootobject r)
        {
            
            using (var conn = new SqlConnection("Server=20.50.138.228;Database= Mathias;User Id= Mathias;Password=TestCase;")) 
            using (var cmd = new SqlCommand("SELECT * FROM ValutaKurser", conn))


            {

                try
                {
                    Console.WriteLine("Openning Connection ...");


                    conn.Open();

                    Console.WriteLine("Connection successful!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

                Console.Read();

                // cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                
                cmd.CommandText = "GET * FROM ValutaKurser ";
               // cmd.CommandText = "Update ValutaKurser" +
                 //   "SET FromCurrency = 1, @ToCurrency = 1, @Rate = 25, 15";

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine(reader.HasRows);
                }

                // Console.WriteLine(rows);
               
            }

        }
        }
    }

    
