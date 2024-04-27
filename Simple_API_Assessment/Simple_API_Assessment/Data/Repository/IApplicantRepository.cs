using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data.Repository
{
    public interface IApplicantRepository
    {
        IEnumerable<Applicant> GetApplicants();
        Applicant GetApplicantById(int Id);
        int CreateApplicant(Applicant applicant);
        int UpdateApplicant(Applicant applicant);
        int DeleteApplicant(int id);
    }
}
