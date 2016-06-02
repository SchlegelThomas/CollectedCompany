using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CollectedCompany.Models.Application;
using CollectedCompany.ServiceLayer.Integrations.Site.Bindings;

namespace CollectedCompany.Controllers
{
    public class ArticlesController : BaseController
    {
        public ArticlesController(IWebsiteResources websiteResources) : base(websiteResources) { }

        // GET: Articles
        public ActionResult Index()
        {
            return View(WebsiteResources.ApplicationResources.Articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = WebsiteResources.ApplicationResources.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreatedById,Content,CreatedOn,PublishOn,TagCloud")] Article article)
        {
            if (ModelState.IsValid)
            {
                WebsiteResources.ApplicationResources.Articles.Add(article);
                WebsiteResources.ApplicationResources.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = WebsiteResources.ApplicationResources.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreatedById,Content,CreatedOn,PublishOn,TagCloud")] Article article)
        {
            if (ModelState.IsValid)
            {
                WebsiteResources.ApplicationResources.Entry(article).State = EntityState.Modified;
                WebsiteResources.ApplicationResources.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = WebsiteResources.ApplicationResources.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = WebsiteResources.ApplicationResources.Articles.Find(id);
            WebsiteResources.ApplicationResources.Articles.Remove(article);
            WebsiteResources.ApplicationResources.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                WebsiteResources.ApplicationResources.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
