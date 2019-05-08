using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Class61Homework.Web.Models;
using Class61Homework.Data;

namespace Class61Homework.Web
{
    public class LayoutPageAttribute : ActionFilterAttribute
    {
        private string _connectionString;

        public LayoutPageAttribute(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var repo = new CourseRepository(_connectionString);

            var controller = (Controller)context.Controller;
            controller.ViewBag.Pending = repo.GetCountOfPendingCandidates();
            controller.ViewBag.Confirmed = repo.GetCountOfConfirmedCandidates();
            controller.ViewBag.Declined = repo.GetCountOfDeclinedCandidates();

            base.OnActionExecuted(context);
        }
    }
}
