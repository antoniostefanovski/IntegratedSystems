﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository;
using IntegratedSystems.Service.Interface;
using IntegratedSystems.Domain.DTOs;

namespace IntegratedSystems.Web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService patientService;

        public PatientsController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        // GET: Patients
        public IActionResult Index()
        {
            return View(patientService.GetPatients());
        }

        // GET: Patients/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Embg,FirstName,LastName,PhoneNumber,Email,Id")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.Id = Guid.NewGuid();
                patientService.CreateNewPatient(patient);
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Embg,FirstName,LastName,PhoneNumber,Email,Id")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            patientService.UpdatePatient(patient);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = patientService.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            patientService.DeletePatient(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult VaccinatePatient(Guid? centerId)
        {
            if (centerId == null)
            {
                return NotFound();
            }

            var model = new VaccinationDTO
            {
                CenterId = centerId.Value,
                Manufacturers = new List<string> { "Vaccine1Man", "Vac2" },
                Patients = patientService.GetPatients()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult VaccinatePatient(VaccinationDTO model)
        {
            patientService.VaccinatePatient(model);
            return RedirectToAction("Details", "VaccinationCenters", new { id = model.CenterId });
        }

        private bool PatientExists(Guid id)
        {
            return patientService.GetPatientById(id) is not null;
        }
    }
}
