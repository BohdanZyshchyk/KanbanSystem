using KanbanSystemDAL.AdditionalClasses.Helpers;
using KanbanSystemDAL.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.Interaction
{
    public class UserManager
    {
        KanbanSystemContext context;
        public UserManager(KanbanSystemContext _context)
        {
            context = _context;
        }
        public async Task RegisterAsync(User user)
        {
            try
            {
                var foundUser = await FindUserAndCheckAsync(user, "User with such login data is already in DB", true);
                context.Users.Add(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> LoginAsync(User user)
        {
            try
            {
                var foundUser = await FindUserAndCheckLoginAsync(user, "User with such login data not found", false);
                return foundUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async Task<User> FindUserAndCheckAsync(User user, string msg, bool mustBeNull)
        {
            var users = await context.Users.ToListAsync();
            var foundUser = users.FirstOrDefault(x => x.CompareTo(user).Equals(0));
            foundUser = FindAndCheckNullabilityHelper<User>.CheckNullable(foundUser, msg, mustBeNull);
            return foundUser;
        }
        private async Task<User> FindUserAndCheckLoginAsync(User user, string msg, bool mustBeNull)
        {
            var users = await context.Users.ToListAsync();
            var foundUser = users.FirstOrDefault(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password));
            foundUser = FindAndCheckNullabilityHelper<User>.CheckNullable(foundUser, msg, mustBeNull);
            return foundUser;
        }
    }
}
