using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Class61Homework.Web.Models;
using Class61Homework.Data;
using Microsoft.Extensions.Configuration;


namespace Class61Homework.Web.Controllers
{
    public class CandidatesController : Controller
    {
        private string _connectionString;

        public CandidatesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        public IActionResult Pending()
        {
            var repo = new CourseRepository(_connectionString);
            CandidateModelView mv = new CandidateModelView();
            mv.People = repo.GetPendingCandidates();

            return View(mv);
        }

        public IActionResult Confirmed()
        {
            var repo = new CourseRepository(_connectionString);
            CandidateModelView mv = new CandidateModelView();
            mv.People = repo.GetConfirmedCandidates();

            return View(mv);
        }

        public IActionResult Declined()
        {
            var repo = new CourseRepository(_connectionString);
            CandidateModelView mv = new CandidateModelView();
            mv.People = repo.GetDeclinedCandidates();

            return View(mv);
        }

        public IActionResult CandidatesStatus()
        {
            var repo = new CourseRepository(_connectionString);

            return Json(new
            {
                pendingPpl = repo.GetCountOfPendingCandidates(),
                confirmedPpl = repo.GetCountOfConfirmedCandidates(),
                declinedPpl = repo.GetCountOfDeclinedCandidates()
            });
        }

        public IActionResult ConfirmPerson(Person person)
        {
            var repo = new CourseRepository(_connectionString);
            person.Confirmed = true;
            repo.UpdatePersonStatus(person);
            IEnumerable<Person> people = repo.GetPendingCandidates();

            return Json(people);
        }

        public IActionResult DeclinePerson(Person person)
        {
            var repo = new CourseRepository(_connectionString);
            person.Confirmed = false;
            repo.UpdatePersonStatus(person);
            IEnumerable<Person> people = repo.GetPendingCandidates();

            return Json(people);
        }
    }
}
