using TS_LRS.Repositories.DbConnections.Interfaces;
using TS_LRS.Repositories.Website.Interfaces;

namespace TS_LRS.Repositories.Website
{
    public class HomeRepo : IHomeRepo
    {
        private readonly IDapperContext _context;
        public HomeRepo(IDapperContext context)
        {
            _context = context;
        }

    }
}
