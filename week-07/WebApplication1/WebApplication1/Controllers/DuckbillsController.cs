using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DuckbillsController : Controller
    {
        private static List<Duckbill> duckbills = new List<Duckbill>()
        {
            new Duckbill() { Id = Guid.NewGuid(), Name = "Perry" },
            new Duckbill() { Id = Guid.NewGuid(), Name = "Stanley" },
        };

        [HttpGet]
        public IEnumerable<Duckbill> ListDuckbills()
        {
            return duckbills.ToArray();
        }

        [HttpGet("{duckbillID?}")]
        public Duckbill DetailDuckbill([FromQuery]Guid? duckbillID)
        {
            return duckbills.FirstOrDefault(duckbill => duckbill.Id == duckbillID);
        }

        [HttpPost]
        public void SaveDuckbill([FromBody]Duckbill duckbill)
        {
            if (duckbill.Id == Guid.Empty)
            {
                duckbill.Id = Guid.NewGuid();

                duckbills.Add(duckbill);
            }
            else
            {
                Duckbill dbDuckbill = duckbills.FirstOrDefault(db => db.Id == duckbill.Id);
                dbDuckbill.Name = duckbill.Name;
                dbDuckbill.Email = duckbill.Email;
            }
        }

        [HttpDelete("{duckbillID?}")]
        public void DeleteDuckbill([FromQuery]Guid duckbillID)
        {
            Duckbill dbDuckbill = duckbills.FirstOrDefault(db => db.Id == duckbillID);

            duckbills.Remove(dbDuckbill);
        }
    }
}