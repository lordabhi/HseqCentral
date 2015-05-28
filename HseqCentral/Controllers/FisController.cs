using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HseqCentral.Models;

namespace HseqCentral.Controllers
{
    public class FisController : Controller
    {
        private HseqCentralContext db = new HseqCentralContext();

        // GET: Fis
        public ActionResult Index()
        {
            var hseqRecords = db.FisRecords.Include(f => f.HseqCaseFile);
            return View(hseqRecords.ToList());
        }

        // GET: Fis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fis fis = db.FisRecords.Find(id);
            if (fis == null)
            {
                return HttpNotFound();
            }
            return View(fis);
        }

        // GET: Fis/Create
        public ActionResult Create()
        {

            ViewBag.RecordType = RecordType.FIS;
            ViewBag.EnteredBy = "Test User";
            ViewBag.ReportedBy = "Test User, Sales";
            ViewBag.QualityCoordinator = "Mr. Paul Smith";
            ViewBag.Status = "Pending";
            ViewBag.HseqCaseFileID = new SelectList(db.HseqCaseFiles, "HseqCaseFileID", "HseqCaseFileID");
            
            return View();
        }

        // POST: Fis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HseqRecordID,AlfrescoNoderef,Title,Description,RecordType,EnteredBy,ReportedBy,QualityCoordinator,MainRecordId,HseqCaseFileID,Category")] Fis fis)
        {
            if (ModelState.IsValid)
            {

                int caseNo = 1;

                IList<HseqCaseFile> hseqCaseFilesList = db.HseqCaseFiles.ToList();

                if (hseqCaseFilesList != null && hseqCaseFilesList.LongCount() > 0)
                {

                    caseNo = hseqCaseFilesList.Max(p => p.CaseNo) + 1;

                }

                HseqCaseFile hseqCaseFile = new HseqCaseFile();

                hseqCaseFile.CaseNo = caseNo;

                db.HseqCaseFiles.Add(hseqCaseFile);

                fis.HseqCaseFile = hseqCaseFile;
                fis.HseqCaseFileID = hseqCaseFile.HseqCaseFileID;

                /////
                hseqCaseFile.HseqRecords.Add(fis);


                db.FisRecords.Add(fis);
                db.SaveChanges();

                //create the folder in Alfresco and return the alfresconoderef
                //Dummy for now

                int alfresconoderef = caseNo;
                hseqCaseFile.AlfrescoNoderef = caseNo;

                fis.AlfrescoNoderef = caseNo;

                db.SaveChanges();




                return RedirectToAction("Index");
            }

            ViewBag.HseqCaseFileID = new SelectList(db.HseqCaseFiles, "HseqCaseFileID", "HseqCaseFileID", fis.HseqCaseFileID);
            return View(fis);
        }

        // GET: Fis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fis fis = db.FisRecords.Find(id);
            if (fis == null)
            {
                return HttpNotFound();
            }
            ViewBag.HseqCaseFileID = new SelectList(db.HseqCaseFiles, "HseqCaseFileID", "HseqCaseFileID", fis.HseqCaseFileID);
            return View(fis);
        }

        // POST: Fis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HseqRecordID,AlfrescoNoderef,Title,Description,RecordType,EnteredBy,ReportedBy,QualityCoordinator,MainRecordId,HseqCaseFileID,Category")] Fis fis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HseqCaseFileID = new SelectList(db.HseqCaseFiles, "HseqCaseFileID", "HseqCaseFileID", fis.HseqCaseFileID);
            return View(fis);
        }

        // GET: Fis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fis fis = db.FisRecords.Find(id);
            if (fis == null)
            {
                return HttpNotFound();
            }
            return View(fis);
        }

        // POST: Fis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fis fis = db.FisRecords.Find(id);
            db.FisRecords.Remove(fis);
            db.SaveChanges();
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
