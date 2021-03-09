using Business_Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SonarQube;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace SonarAPI.Controllers
{
    [Route("[controller]/[action]")]
    public class ComponentController : Controller
    {
        // GET: ComponentController
        public ActionResult Index()
        {
            return View();
        }

        public string GetAll(string team)
        {
            var bu = new ConsumeRest();
            bool cent = true;
            int page = 1;
            List<Component> cr = new List<Component>();
            while (cent)
            {
                var r = bu.HTTP_GET("http://devops/sonar/api/components/search?ps=500&qualifiers=TRK&p=", page, "5694ea7bf005d1bb38e98f9234f8b80c08853144");

                var resp = JsonConvert.DeserializeObject<ComponentResponse>(r.Result);
                cr.AddRange(resp.components.Where(w => w.project.Contains(team)));
                if ((resp.paging.pageIndex * resp.paging.pageSize) < resp.paging.total)
                {
                    page++;
                }
                else
                { 
                    cent = false;
                }
            }
            return cr.Count().ToString() + " " + cr.Where(w => w.project.Contains("-web")).Count();
        }

        // GET: ComponentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComponentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComponentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ComponentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComponentController/Edit/5
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

        // GET: ComponentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComponentController/Delete/5
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
