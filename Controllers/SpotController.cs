using HUB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HUB.Controllers
{
    public class SpotController : Controller
    {
        // GET: SpotifyController
        public async Task<ActionResult> Index()
        {
            //call api
            string apiURl = "https://localhost:7019/api/song";
            List<Song> songs = new List<Song>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiURl);

                var result = await response.Content.ReadAsStringAsync();
                songs = JsonConvert.DeserializeObject<List<Song>>(result);
            }


            return View(songs);
        }

        // GET: SpotifyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpotifyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpotifyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Song songs)
        {
            string apiURL = "https://localhost:7019/api/song";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(songs),
                    Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiURL,content);
                
                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Create));
                }

            return View(songs);
            }
        }


        // done with work for the code




        // GET: SpotifyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpotifyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SpotifyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpotifyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
