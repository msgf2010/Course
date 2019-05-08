using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Class61Homework.Data;

namespace Class61Homework.Web.Models
{
    public class CandidateModelView
    {
        public IEnumerable<Person> People { get; set; }
    }
}
