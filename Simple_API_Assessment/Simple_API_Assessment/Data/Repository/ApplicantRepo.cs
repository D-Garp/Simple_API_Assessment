using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public class ApplicantRepo : IApplicantRepository
    {
        private readonly DataContext dataContext;

        public ApplicantRepo(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public int CreateApplicant(Applicant applicant)
        {
            int rt = -1;
            if(applicant == null) { rt = 0; }
            else 
            {
                dataContext.applicant.Add(applicant);
                dataContext.SaveChanges();
                rt = applicant.Id;
            }
            return rt;
        }

        public int DeleteApplicant(int id)
        {
            var applicant = dataContext.applicant.Where(x => x.Id == id).FirstOrDefault() ?? null;
            if (applicant != null)
            {
                dataContext.applicant.Remove(applicant);
                dataContext.SaveChanges();
                return applicant.Id;
            };
            return -1;
        }

        public Applicant GetApplicantById(int Id)
        {
            var applicant = dataContext.applicant.Where(x => x.Id == Id).FirstOrDefault()?? null;
            return applicant;
        }

        public IEnumerable<Applicant> GetApplicants()
        {
            var list = dataContext.applicant.Include(x => x.skills).Select(m => new Applicant 
            {
                Id = m.Id,
                Name = m.Name,
                skills = m.skills
            }).ToList();

            return list;
        }

        public int UpdateApplicant(Applicant applicant)
        {
            var ap = dataContext.applicant.Where(x => x.Id == applicant.Id).FirstOrDefault() ?? null; 
            if(ap != null)
            {
                ap.Id = applicant.Id;
                ap.Name = applicant.Name;
                ap.skills = applicant.skills;
                dataContext.SaveChanges();
                return ap.Id;
            }
            
            return -1;
        }
    }
}
