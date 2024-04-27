using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Simple_API_Assessment.Models
{
    public class Applicant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [MaxLength(3)]
        public List<Skill> skills { get; set; }
    }
}
