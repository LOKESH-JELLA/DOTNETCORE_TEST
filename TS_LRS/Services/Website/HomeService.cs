using TS_LRS.Repositories.Website.Interfaces;
using TS_LRS.Services.Website.Interfaces;

namespace TS_LRS.Services.Website
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepo _homeReposi;

        public HomeService(IHomeRepo homeReposi)
        {
            _homeReposi = homeReposi;
        }
    }
}
