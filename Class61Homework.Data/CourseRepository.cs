using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Class61Homework.Data
{
    public class CourseRepository
    {
        private string _connectionString;

        public CourseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int GetCountOfPendingCandidates()
        {
            using (var context = new CourseContext(_connectionString))
            {
                return context.People.Where(p => p.Confirmed == null).Count();
            }
        }

        public int GetCountOfConfirmedCandidates()
        {
            using (var context = new CourseContext(_connectionString))
            {
                return context.People.Where(p => p.Confirmed == true).Count();
            }
        }

        public int GetCountOfDeclinedCandidates()
        {
            using (var context = new CourseContext(_connectionString))
            {
                return context.People.Where(p => p.Confirmed == false).Count();
            }
        }

        public IEnumerable<Person> GetPendingCandidates()
        {
            using (var context = new CourseContext(_connectionString))
            {
                return context.People.Where(p => p.Confirmed == null).ToList();
            }
        }

        public IEnumerable<Person> GetConfirmedCandidates()
        {
            using (var context = new CourseContext(_connectionString))
            {
                return context.People.Where(p => p.Confirmed == true).ToList();
            }
        }

        public IEnumerable<Person> GetDeclinedCandidates()
        {
            using (var context = new CourseContext(_connectionString))
            {
                return context.People.Where(p => p.Confirmed == false).ToList();
            }
        }

        public void AddPerson(Person person)
        {
            using (var context = new CourseContext(_connectionString))
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }

        public void UpdatePersonStatus(Person person)
        {
            using (var context = new CourseContext(_connectionString))
            {
                context.Database.ExecuteSqlCommand(
                    "UPDATE People SET Confirmed = @confirmed WHERE Id = @id",
                    new SqlParameter("@confirmed", person.Confirmed),
                    new SqlParameter("@id", person.Id));
            }
        }
    }
}
