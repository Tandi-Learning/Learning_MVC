using PatientData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using PatientData.Models;

namespace PatientData.App_Start
{
    public static class MongoConfig
    {
        public static void Seed()
        {
            var patients = PatientDB.Open();

            if (!patients.AsQueryable().Any(p => p.Name == "John"))
            {
                var data = new List<Patient>
                {
                    new Patient
                    {
                        Name = "John",
                        Ailments = new List<Ailment> { new Ailment { Name = "John Ailment 1" }, new Ailment { Name = "John Ailment 2" } },
                        Medications = new List<Medication> { new Medication { Name = "John Medication 1" }, new Medication { Name = "John Medication 2" } },
                    },
                    new Patient
                    {
                        Name = "Paul",
                        Ailments = new List<Ailment> { new Ailment { Name = "Paul Ailment 1" }, new Ailment { Name = "Paul Ailment 2" } },
                        Medications = new List<Medication> { new Medication { Name = "Paul Medication 1" }, new Medication { Name = "Paul Medication 2" } },
                    },
                    new Patient
                    {
                        Name = "George",
                        Ailments = new List<Ailment> { new Ailment { Name = "George Ailment 1" }, new Ailment { Name = "George Ailment 2" } },
                        Medications = new List<Medication> { new Medication { Name = "George Medication 1" }, new Medication { Name = "George Medication 2" } },
                    },
                    new Patient
                    {
                        Name = "Ringo",
                        Ailments = new List<Ailment> { new Ailment { Name = "Ringo Ailment 1" }, new Ailment { Name = "Ringo Ailment 2" } },
                        Medications = new List<Medication> { new Medication { Name = "Ringo Medication 1" }, new Medication { Name = "Ringo Medication 2" } },
                    },
                };

                patients.InsertManyAsync(data);
            }
        }
    }
}