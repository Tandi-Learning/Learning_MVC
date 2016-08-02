using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientData.Data
{
    public static class PatientDB
    {
        public static IMongoCollection<Patient> Open()
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("PatientDB");
            return db.GetCollection<Patient>("Patients");
        }
    }
}