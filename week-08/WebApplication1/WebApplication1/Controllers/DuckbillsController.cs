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

        private readonly Data.WebApplication1Context webApplication1Context;

        public DuckbillsController(Data.WebApplication1Context webApplication1Context)
        {
            this.webApplication1Context = webApplication1Context;
        }

        [HttpGet]
        public IEnumerable<Duckbill> ListDuckbills()
        {
            return webApplication1Context.Duckbills.ToArray();
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
                webApplication1Context.Duckbills.Add(duckbill);
            }
            else
            {
                Duckbill dbDuckbill = webApplication1Context.Duckbills.FirstOrDefault(x => x.Id == duckbill.Id);

                dbDuckbill.Name = duckbill.Name;
                dbDuckbill.Email = duckbill.Email;
            }

            webApplication1Context.SaveChanges();
        }

        [HttpDelete("{duckbillID?}")]
        public void DeleteDuckbill([FromQuery]Guid duckbillID)
        {
            Duckbill dbDuckbill = duckbills.FirstOrDefault(db => db.Id == duckbillID);

            duckbills.Remove(dbDuckbill);
        }
    }
}