﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROYECTO_VERIS_MVC.Models;

namespace PROYECTO_VERIS_MVC.Controllers
{
    [Authorize(Roles = "Medico, SuperAdmin")]
    public class consultasController : Controller
    {
        private ProyectoVeris_MVC_BDEntities db = new ProyectoVeris_MVC_BDEntities();

        // GET: consultas
        
        public ActionResult Index()
        {
            var consultas = db.consultas.Include(c => c.pacientes).Include(c => c.medicos);
            return View(consultas.ToList());
        }

        // GET: consultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultas consultas = db.consultas.Find(id);
            if (consultas == null)
            {
                return HttpNotFound();
            }
            return View(consultas);
        }

        // GET: consultas/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.pacientes, "IdPaciente", "IdUsuario");
            ViewBag.IdMedico = new SelectList(db.medicos, "IdMedico", "Nombre");
            return View();
        }

        // POST: consultas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdConsulta,IdMedico,IdPaciente,FechaConsulta,HI,HF,Diagnostico")] consultas consultas)
        {
            if (ModelState.IsValid)
            {
                db.consultas.Add(consultas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.pacientes, "IdPaciente", "IdUsuario", consultas.IdPaciente);
            ViewBag.IdMedico = new SelectList(db.medicos, "IdMedico", "Nombre", consultas.IdMedico);
            return View(consultas);
        }

        // GET: consultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultas consultas = db.consultas.Find(id);
            if (consultas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.pacientes, "IdPaciente", "IdUsuario", consultas.IdPaciente);
            ViewBag.IdMedico = new SelectList(db.medicos, "IdMedico", "Nombre", consultas.IdMedico);
            return View(consultas);
        }

        // POST: consultas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdConsulta,IdMedico,IdPaciente,FechaConsulta,HI,HF,Diagnostico")] consultas consultas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.pacientes, "IdPaciente", "IdUsuario", consultas.IdPaciente);
            ViewBag.IdMedico = new SelectList(db.medicos, "IdMedico", "Nombre", consultas.IdMedico);
            return View(consultas);
        }

        // GET: consultas/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultas consultas = db.consultas.Find(id);
            if (consultas == null)
            {
                return HttpNotFound();
            }
            return View(consultas);
        }

        // POST: consultas/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            consultas consultas = db.consultas.Find(id);
            db.consultas.Remove(consultas);
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
