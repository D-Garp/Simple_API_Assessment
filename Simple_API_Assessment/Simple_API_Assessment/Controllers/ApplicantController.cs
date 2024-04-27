using Microsoft.AspNetCore.Mvc;
using Simple_API_Assessment.Data.Repository;
using Simple_API_Assessment.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Simple_API_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {

        private IApplicantRepository applicantrepo;

        public ApplicantController(IApplicantRepository applicantrepo) { this.applicantrepo = applicantrepo; }

        // GET: api/<ApplicantController>
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var applicant = applicantrepo.GetApplicants();
            if(applicant == null)
            {
                return NotFound();
            };
            return Ok(applicant);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Applicant app = applicantrepo.GetApplicantById(id);
            if (app == null)
            {
                return NotFound();
            };
            return Ok(app);
        }

        [HttpPost]
        public IActionResult Post(Applicant applicant)
        {
            int id = applicantrepo.CreateApplicant(applicant);
            if (id <= 0)
            {
                return BadRequest("Error");
            }
            else
            {
                return Ok("Applicant: " + id);
            }
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Applicant applicant)
        {
            int id = applicantrepo.UpdateApplicant(applicant);
            if (id <= 0)
            {
                return BadRequest("Error");
            }
            else
            {
                return Ok("Updated: " + id);
            }
        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int reId = applicantrepo.DeleteApplicant(id);
            if(reId <= 0)
            {
                return BadRequest("Error");
            }
            else
            {
                return Ok("Deleted: " + id);
            }

        }
    }
}
