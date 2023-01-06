using proiect.Data;
using proiect.Models;

namespace proiect.Helpers.Seeders
{
    public class AdminSeeder
    {
        public readonly ProjectContext _projectContext;

        public AdminSeeder(ProjectContext projectContext )
        {
            _projectContext = projectContext;
        }

        public void SeedInitialAdmin()
        {
            if (!_projectContext.Users.Any())
            {
                var user = new User
                {
                    
                };
            }    
        }
    }
}
