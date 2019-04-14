using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Duckbill> GetDuckbills()
        {
            return duckbills.ToArray();
        }

        [HttpGet("{duckbillID?}")]
        public Duckbill GetDuckbill([FromQuery]Guid? duckbillID)
        {
            return duckbills.FirstOrDefault(duckbill => duckbill.Id == duckbillID);
        }

        [HttpPost]
        public void SaveDuckbill([FromBody]Duckbill duckbill)
        {
            if (duckbill.Id == Guid.Empty)
                duckbill.Id = Guid.NewGuid();

            duckbills.Add(duckbill);
        }
    }


    //[Route("api/[controller]")]
    //public class DuckbillsController : Controller
    //{
    //    private static List<Duckbill> duckbills = new List<Duckbill>()
    //    {
    //        new Duckbill() { Id = Guid.NewGuid(), Name = "Perry" },
    //        new Duckbill() { Id = Guid.NewGuid(), Name = "Stanley" },
    //    };

    //    // GET: api/Duckbills
    //    [HttpGet("action")]
    //    public Duckbill[] GetDuckbill()
    //    {
    //        return duckbills.ToArray();
    //    }

    //    // GET: api/Duckbills/5
    //    [HttpGet("{id}")]
    //    public Duckbill GetDuckbill(Guid id)
    //    {
    //        Duckbill duckbill = duckbills.FirstOrDefault(db => db.Id == id);

    //        return duckbill;
    //    }

    //    // PUT: api/Duckbills
    //    [HttpPut]
    //    public IActionResult PutDuckbill([FromBody] Duckbill duckbill)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        Duckbill dbDuckbill = duckbills.FirstOrDefault(db => db.Id == duckbill.Id);
    //        dbDuckbill.Name = duckbill.Name;

    //        return Ok();
    //    }

    //    // POST: api/Duckbills
    //    [HttpPost]
    //    public IActionResult PostDuckbill([FromBody] Duckbill duckbill)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        duckbill.Id = Guid.NewGuid();
    //        duckbills.Add(duckbill);

    //        return Ok();
    //    }

    //    // DELETE: api/Duckbills/5
    //    [HttpDelete("{id}")]
    //    public IActionResult DeleteDuckbill([FromRoute] Guid id)
    //    {
    //        Duckbill duckbill = duckbills.FirstOrDefault(db => db.Id == id);

    //        duckbills.Remove(duckbill);

    //        return Ok();
    //    }
    //}
}