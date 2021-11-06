using DTP.Entity;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Threading.Tasks;

namespace DigitalTravelPlatform
{
    public class DTPProcessor
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly DTPDBContext _contextDTP;


        public DTPProcessor(DTPDBContext contextDTP)
        {
            _contextDTP = contextDTP;
        }

        public async Task<bool> Login(string login, string pass)
        {
            var result = await _contextDTP.Users.AnyAsync(x => x.Login == login && x.Password == pass);

            return result;
        }
    }
}
