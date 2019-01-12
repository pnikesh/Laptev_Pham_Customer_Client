using Laptev_Pham_Customer_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Text;

namespace Laptev_Pham_Customer_Client.Controllers
{
    public class HomeController : Controller
    {



        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Getting all flights
        /// <returns> flights
        /// 
        // GETTING ALL FLIGHTS BETWEEN CITIES   
        public async Task<ActionResult> AllFlightsAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://laptevphamproject-prod.us-east-1.elasticbeanstalk.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Flight> flights = null;

            try
            {
                string json;
                Flight flight;
                HttpContent content;
                HttpResponseMessage response;

                // get all flights
                response = await client.GetAsync("/api/Flights");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    flights = JsonConvert.DeserializeObject<IEnumerable<Flight>>(json);

                    foreach (Flight f in flights)
                    {
                        Console.WriteLine(f);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            return View(flights);
        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Getting all flights from specific cit
        /// <returns>flights

        // GETTING ALL FLIGHTS FROM SPECIFIC CITY  - REDIRECT TO CHOOSE CITY PAGE  
        public ActionResult AllFlightsFromSpecificCity()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ShowAllFlightsFromCityAsync(string DepartureCity)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://laptevphamproject-prod.us-east-1.elasticbeanstalk.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Flight> flights = null;

            try
            {
                string json;
                Flight flight;
                HttpContent content;
                HttpResponseMessage response;

                // get all chapters
                response = await client.GetAsync("/api/Flights/GetLFlightsByDepartureCity?departCity=" + DepartureCity);

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    flights = JsonConvert.DeserializeObject<IEnumerable<Flight>>(json);
                    //CheckDisposed();
                    //json = await response.Content.ReadAsAsync<T>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //var flightsFromCity = flights.Where(x => x.DepartureCity == DepartureCity);

            ViewBag.DepartureCity = DepartureCity;


            return View(flights);

        }


        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Getting all flights from chosen cities
        /// <returns>flights

        // GETTING ALL FLIGHTS FROM CHOSEN CITIES   
        // REDIRECT TO CHOOSE CITIES PAGE
        public ActionResult AllFlightsFromCities()
        {


            return View();
        }

        // CALLING API CONTROLLER
        public async Task<ActionResult> FlightsBetweenCitiesAsync(string DepartureCity, string ArrivalCity, bool direct)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://laptevphamproject-prod.us-east-1.elasticbeanstalk.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Flight> flights = null;

            try
            {
                string json;
                Flight flight;
                HttpContent content;
                HttpResponseMessage response;

                string uri;

                if (direct) uri = "/api/Flights/GetDirectFlights?departCity=" + DepartureCity + "&arrCity=" + ArrivalCity + "&direct=true";
                else uri = "/api/Flights/GetFlightsByCities?departCity=" + DepartureCity + "&arrCity=" + ArrivalCity;
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    flights = JsonConvert.DeserializeObject<IEnumerable<Flight>>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return View(flights);
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Getting all flights from chosen cities with price limitations
        /// <returns></returns>

        // GETTING ALL FLIGHTS FROM SPECIFIC CITY WITH PRICE 
        public ActionResult AllFlightsWithPriceLimit()
        {


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ShowAllFlightsWithPriceLimit(string DepartureCity, string ArrivalCity, int price)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://laptevphamproject-prod.us-east-1.elasticbeanstalk.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Flight> flights = null;

            try
            {
                string json;
                Flight flight;
                HttpContent content;
                HttpResponseMessage response;

                // get all chapters
                response = await client.GetAsync("/api/Flights/GetFlightsByCitiesAndPrice?departCity=" + DepartureCity +
                    "&arrCity=" + ArrivalCity + "&maxPrice=" + price);

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    flights = JsonConvert.DeserializeObject<IEnumerable<Flight>>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View(flights);
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Getting all DIRECT flights from chosen cities 
        /// <returns></returns>

        [HttpPost]
        public void ShowAllFlights(string DepartureCity, string ArrivalCity, bool direct)
        {


        }



        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ADDING FLIGHTS CONTROLLERS//////////
        /// <returns></returns>   


        // REDIRECT TO ADD FLIGHT PAGE
        public ActionResult AddFlight()
        {
            return  View(); 
        }

        // CALLING API CONTROLLER 
        [HttpPost]
        public async Task<ActionResult> AddFlightAsync(Flight flight)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://laptevphamproject-prod.us-east-1.elasticbeanstalk.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
           // IEnumerable<Flight> flights = null;
            try
            {
                string json;
                HttpContent content;
                HttpResponseMessage response;

                //add a new flight
                //flight = new Flight();
                json = JsonConvert.SerializeObject(flight);
                content = new StringContent(json, Encoding.UTF8, "application/json");
                //response = await client.PostAsync("/api/Flights", content);
                response = await client.PostAsJsonAsync("/api/Flights", flight);
                Console.WriteLine($"status from POST {response.StatusCode}");
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"added resource at {response.Headers.Location}");
                json = await response.Content.ReadAsStringAsync();

                Console.WriteLine("The flight has been inserted " + json);
                //return RedirectToAction("AllFlightsAsync");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View(flight);
            // return RedirectToAction("AllFlightsAsync");
        }


        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // UPDATING FLIGHT CONTROLLERS//////////
        /// <returns></returns>   
        // REDIRECT TO UPDATE FLIGHT PAGE
        public async Task<ActionResult> UpdateFlight()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://laptevphamproject-prod.us-east-1.elasticbeanstalk.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Flight> flights = null;

            try
            {
                string json;
                Flight flight;
                HttpContent content;
                HttpResponseMessage response;

                // get all flights
                response = await client.GetAsync("/api/Flights");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();

                    flights = JsonConvert.DeserializeObject<IEnumerable<Flight>>(json);

                    foreach (Flight f in flights)
                    {
                        Console.WriteLine(f);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return View(flights);
            
        }


        [HttpPost]
        public ActionResult ShowFlightDetailsToUpdate(int id, string flightName, string DepartureCity, string ArrivalCity, string DepartureTime, string ArrivalTime, bool? Direct, int TicketPrice)
        {
            var flight = new Flight();
            flight.ID = id;
            flight.FlightName = flightName;
            flight.DepartureCity = DepartureCity;
            flight.ArrivalCity = ArrivalCity;
            flight.DepartureTime = DepartureTime;
            flight.ArrivalTime = ArrivalTime;
            //flight.Direct = Direct;
            flight.TicketPrice = TicketPrice;

            return View(flight);
        }



        // CALLING API CONTROLLER 
        [HttpPost]
        public async Task<ActionResult> UpdateFlightAsync(Flight flight)

        {            

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://laptevphamproject-prod.us-east-1.elasticbeanstalk.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //IEnumerable<Flight> flights = null;
            try
            {
                string json;
                HttpContent content;
                HttpResponseMessage response;
              
                //update flight
                json = JsonConvert.SerializeObject(flight);
                content = new StringContent(json, Encoding.UTF8, "application/json");
                //response = await client.PutAsync("/api/Flights/}", content);
                response = await client.PutAsJsonAsync("/api/Flights/" + flight.ID, flight);


                Console.WriteLine($"status from PUT {response.StatusCode}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View(flight);
            //return RedirectToAction("AllFlightsAsync");

        }


        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // DELETING FLIGHT CONTROLLERS//////////
        /// <returns></returns>   
        // REDIRECT TO DELETE FLIGHT PAGE
        public ActionResult DeleteFlight(int id, string flightName, string DepartureCity, string ArrivalCity, string DepartureTime, string ArrivalTime, bool? Direct, int TicketPrice)
        {
            var flight = new Flight();
            flight.ID = id;
            flight.FlightName = flightName;
            flight.DepartureCity = DepartureCity;
            flight.ArrivalCity = ArrivalCity;
            flight.DepartureTime = DepartureTime;
            flight.ArrivalTime = ArrivalTime;
            //flight.Direct = Direct;
            flight.TicketPrice = TicketPrice;

            return View(flight);
        }
        // CALLING API CONTROLLER 
        [HttpPost]
        public async Task<ActionResult> DeleteFlightAsync(int? id)
        {
           

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://laptevphamproject-prod.us-east-1.elasticbeanstalk.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            IEnumerable<Flight> flights = null;
            try
            {
                HttpResponseMessage response;
              ;
                //delete a flight
                response = await client.DeleteAsync("/api/Flights/" + id);
                Console.WriteLine($"status from DELETE {response.StatusCode}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return View(flights);
            //return RedirectToAction("AllFlightsAsync");

        }
    }
}