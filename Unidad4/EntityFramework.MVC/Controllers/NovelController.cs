using EntityFramework.MVC.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EntityFramework.MVC.Controllers
{
    public class NovelController : Controller
    {
        // GET: Novel
        public async Task<ActionResult> Novel()
        {
            var httpClient = new HttpClient();           
            var json = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            List<Novel> novelsList = JsonConvert.DeserializeObject<List<Novel>>(json);
                
            return View(novelsList);
        }
    }
}