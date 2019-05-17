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
        public IEnumerable<ViewModels.DuckbillViewModel> ListDuckbills()
        {
            Duckbill[] dbDuckbills = webApplication1Context.Duckbills.ToArray();

            List<ViewModels.DuckbillViewModel> duckbills = new List<ViewModels.DuckbillViewModel>();

            foreach (Duckbill dbDuckbill in dbDuckbills)
            {
                ViewModels.DuckbillViewModel duckbill = new ViewModels.DuckbillViewModel();
                duckbill.Id = dbDuckbill.Id;
                duckbill.Name = dbDuckbill.Name;
                duckbill.Email = dbDuckbill.Email;

                DuckbillFriend[] dbDuckbillFriends = webApplication1Context.DuckbillFriends
                    .Where(dbDuckbillFriend =>
                        dbDuckbillFriend.FriendId1 == dbDuckbill.Id ||
                        dbDuckbillFriend.FriendId2 == dbDuckbill.Id)
                    .ToArray();

                Guid[] friendIds = dbDuckbillFriends
                    .SelectMany(x => new[] { x.FriendId1, x.FriendId2 })
                    .Distinct()
                    .Where(x => x != dbDuckbill.Id)
                    .ToArray();

                duckbill.Friends = dbDuckbills.Where(x => friendIds.Contains(x.Id)).ToArray();

                duckbills.Add(duckbill);
            }

            return duckbills;
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
                Duckbill dbDuckbill = webApplication1Context.Duckbills.FirstOrDefault(db => db.Id == duckbill.Id);
                dbDuckbill.Name = duckbill.Name;
                dbDuckbill.Email = duckbill.Email;
            }

            webApplication1Context.SaveChanges();
        }

        [HttpDelete("{duckbillID?}")]
        public void DeleteDuckbill([FromQuery]Guid duckbillID)
        {
            Duckbill dbDuckbill = webApplication1Context.Duckbills.FirstOrDefault(db => db.Id == duckbillID);

            webApplication1Context.Duckbills.Remove(dbDuckbill);

            webApplication1Context.SaveChanges();
        }
    }
}