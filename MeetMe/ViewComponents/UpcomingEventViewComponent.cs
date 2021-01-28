using MeetMe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.ViewComponents
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-5.0
    public class UpcomingEventViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public UpcomingEventViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var meeting = await db.Meetings.Where(x => x.MeetingTime > DateTime.Now).OrderBy(x => x.MeetingTime).FirstOrDefaultAsync();
            return View(meeting);
        }
    }
}
