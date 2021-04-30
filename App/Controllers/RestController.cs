using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class RestController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("GetAll");
        }

        public ActionResult GetAll()
        {
            IEnumerable<M_RESTAURANT> restaurants = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44352/api/");

                var responseTask = client.GetAsync("Rest");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<M_RESTAURANT>>();
                    readTask.Wait();
                    restaurants = readTask.Result;
                }
                else
                {
                    restaurants = Enumerable.Empty<M_RESTAURANT>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(restaurants);
        }

        public ActionResult Details(int id)
        {
            M_RESTAURANT m = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44352/api/");

                var responseTask = client.GetAsync("Rest/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<M_RESTAURANT>();
                    readTask.Wait();
                    m = readTask.Result;
                }
                else
                {
                    //m = Enumerable.Empty<M_RESTAURANT>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(m);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(M_RESTAURANT m)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44352/api/");

                var postTask = client.PostAsJsonAsync<M_RESTAURANT>("Rest", m);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error!!!!");

            return View(m);
        }

        public ActionResult Edit(int id)
        {
            M_RESTAURANT m = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44352/api/");

                var resposneTask = client.GetAsync("Rest/" + id);
                resposneTask.Wait();

                var result = resposneTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<M_RESTAURANT>();
                    readTask.Wait();

                    m = readTask.Result;
                }
            }
            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(M_RESTAURANT m)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44352/api/");

                var putTask = client.PutAsJsonAsync<M_RESTAURANT>("Rest", m);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(m);
        }

        public ActionResult Delete(int id)
        {
            M_RESTAURANT m = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44352/api/");

                var resposneTask = client.GetAsync("Rest/" + id);
                resposneTask.Wait();

                var result = resposneTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<M_RESTAURANT>();
                    readTask.Wait();

                    m = readTask.Result;
                }
            }
            return View(m);
        }

        [HttpPost]
        public ActionResult Delete(M_RESTAURANT m)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44352/api/");

                int id = m.Id;
                var deleteTask = client.DeleteAsync("Rest/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}