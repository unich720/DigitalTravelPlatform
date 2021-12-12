using DigitalTravelPlatform.Model;
using DTP.Entity;
using DTP.Entity.Models;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Profile> GetProfile(string login)
        {
            var result = await _contextDTP.Users.Select(x =>
                new Profile
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    City = x.City,
                    Login = x.Login
                }).FirstOrDefaultAsync(x => x.Login == login);

            return result;
        }

        public async Task<bool> ChangePassword(string login, string pass)
        {
            var user = await _contextDTP.Users.FirstOrDefaultAsync(x => x.Login == login);

            if (string.IsNullOrEmpty(pass))
            {
                user.Password = pass;
                await _contextDTP.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> ChangeProfile(Profile cProfile)
        {
            var user = await _contextDTP.Users.FirstOrDefaultAsync(x => x.Id == cProfile.Id);

            if (string.IsNullOrEmpty(cProfile.FirstName) && string.IsNullOrEmpty(cProfile.LastName)
               && string.IsNullOrEmpty(cProfile.Login) && string.IsNullOrEmpty(cProfile.City))
            {
                user.FirstName = cProfile.FirstName;
                user.LastName = cProfile.LastName;
                user.Login = cProfile.Login;
                user.City = cProfile.City;
                await _contextDTP.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Route>> GetRoutes()
        {
            var result = await _contextDTP.Routes.ToListAsync();

            return result;
        }

        public async Task<List<Place>> GetPlaces(short routeId)
        {
            var result = await _contextDTP.RoutePlaces.Where(x => x.RouteId == routeId).Select(x => x.Place).ToListAsync();

            return result;
        }

        public async Task<List<string>> GetPlacesForUser(short userId)
        {
            var result = await _contextDTP.MovementHistories.Where(x => x.UserId == userId).Select(x => x.Place.Place1).ToListAsync();

            return result;
        }

        public async Task<bool> GivePointsUser(UserPoints userPoints)
        {
            var user = await _contextDTP.Users.FirstOrDefaultAsync(x => x.Id == userPoints.UserId);

            if (user != default)
            {
                user.Points += userPoints.Points;
                await _contextDTP.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Question> GetQuestion(short pollId)
        {
            var result = await _contextDTP.Polls.Where(x => x.Id == pollId).Select(x => x.Questions.FirstOrDefault()).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<Answer>> GetAnswer(short pollId)
        {
            var result = await _contextDTP.Polls.Where(x => x.Id == pollId).Select(x => x.Questions.FirstOrDefault().Answers.ToList()).FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> PullAnswer(short answerId)
        {
            var answer = await _contextDTP.Answers.FirstOrDefaultAsync(x => x.Id == answerId);

            if (answer != default)
            {
                answer.Count++;
                await _contextDTP.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
