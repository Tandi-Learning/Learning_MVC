using MongoDB.Bson;
using MongoDB.Driver;
using PatientData.Data;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PatientData.Controllers
{
    [EnableCors("*", "*", "GET")]
    public class PatientsController : ApiController
    {
        IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDB.Open();
        }

        public IEnumerable<Patient> Get()
        {
            var patients = (from p in _patients.AsQueryable()
                            select p).ToList();
            return patients;
        }

        public IHttpActionResult Get(string id)
        {
            var patient = (from p in _patients.AsQueryable()
                           where p.Id == id
                           select p).First();
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [Route("api/patients/{id}/medications")]
        public IHttpActionResult GetMedications(string id)
        {
            var patient = (from p in _patients.AsQueryable()
                           where p.Id == id
                           select p).First();
            if (patient == null)
                return NotFound();

            return Ok(patient.Medications);
        }
    }
}
