using HUB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HUB.Controllers
{
    public class DogController : Controller
    {
        // GET: Index for random dog image
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://dog.ceo/api/breeds/image/random";
            DogResponse dogResponse;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dogResponse = JsonConvert.DeserializeObject<DogResponse>(result);

                    var uri = new Uri(dogResponse.Message);
                    var segments = uri.Segments;
                    if (segments.Length > 2)
                    {
                        dogResponse.Breed = segments[2].TrimEnd('/');
                    }
                }
                else
                {
                    dogResponse = new DogResponse { Message = "Error retrieving dog image", Status = "error" };
                }
            }

            return View(dogResponse);
        }

        // GET: BreedsList
        public async Task<ActionResult> BreedsList()
        {
            string apiUrl = "https://dog.ceo/api/breeds/list/all";
            BreedListResponse breedListResponse;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    breedListResponse = JsonConvert.DeserializeObject<BreedListResponse>(result);
                }
                else
                {
                    breedListResponse = new BreedListResponse { Message = new Dictionary<string, string[]>(), Status = "error" };
                }
            }

            return View(breedListResponse);
        }
        // GET: BreedImage
        public async Task<ActionResult> BreedImage(string breed)
        {
            string apiUrl = $"https://dog.ceo/api/breed/{breed}/images/random";
            DogResponse dogResponse;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dogResponse = JsonConvert.DeserializeObject<DogResponse>(result);
                }
                else
                {
                    dogResponse = new DogResponse { Message = "Error retrieving dog image", Status = "error" };
                }
            }

            return View("Index", dogResponse);
        }
        
    }
}
