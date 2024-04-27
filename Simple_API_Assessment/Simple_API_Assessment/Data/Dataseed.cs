using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data
{
    public static class Dataseed
    {
        public static void seedData(this IHost host)
        {
            using var dataScope = host.Services.CreateScope();
            using var context = dataScope.ServiceProvider.GetRequiredService<DataContext>();

            context.Database.EnsureCreated();
            Addseed(context);
        }

        private static void Addseed(DataContext context)
        {
            var applicantData = context.applicant.FirstOrDefault();

            if (applicantData != null) return;

            context.applicant.Add(new Applicant
            {
                Name = "Vhuthilo",
                skills = new List<Skill>
                {
                    new Skill{ Name = ".NET API"},
                    new Skill{ Name = "Postgresql"},
                    new Skill{ Name = "Database Queries"}
                }
            });

            context.SaveChanges();
        }
    }
}
