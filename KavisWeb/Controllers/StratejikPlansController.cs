using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KavisWeb.DataLayer;
using KavisWeb.Enitites.DbModels;

namespace KavisWeb.Controllers
{
    public class StratejikPlansController : Controller
    {
        private StrategyDBContext db = new StrategyDBContext();

        // GET: StratejikPlans
        public async Task<ActionResult> Index()
        {
            return View(await db.StratejikPlanlar.ToListAsync());
        }

        // GET: StratejikPlans/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StratejikPlan stratejikPlan = await db.StratejikPlanlar.FindAsync(id);
            if (stratejikPlan == null)
            {
                return HttpNotFound();
            }
            return View(stratejikPlan);
        }

        // GET: StratejikPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StratejikPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,KurumKodu,KurumAdi,Baslangic,Bitis,KurumTipi")] StratejikPlan stratejikPlan)
        {
            if (ModelState.IsValid)
            {
                db.StratejikPlanlar.Add(stratejikPlan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(stratejikPlan);
        }

        // GET: StratejikPlans/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StratejikPlan stratejikPlan = await db.StratejikPlanlar.FindAsync(id);
            if (stratejikPlan == null)
            {
                return HttpNotFound();
            }
            return View(stratejikPlan);
        }

        // POST: StratejikPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,KurumKodu,KurumAdi,Baslangic,Bitis,KurumTipi")] StratejikPlan stratejikPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stratejikPlan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stratejikPlan);
        }

        // GET: StratejikPlans/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StratejikPlan stratejikPlan = await db.StratejikPlanlar.FindAsync(id);
            if (stratejikPlan == null)
            {
                return HttpNotFound();
            }
            return View(stratejikPlan);
        }

        // POST: StratejikPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StratejikPlan stratejikPlan = await db.StratejikPlanlar.FindAsync(id);
            db.StratejikPlanlar.Remove(stratejikPlan);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
