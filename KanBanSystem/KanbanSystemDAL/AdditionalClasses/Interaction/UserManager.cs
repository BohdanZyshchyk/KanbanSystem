using KanbanSystemDAL.AdditionalClasses.Helpers;
using KanbanSystemDAL.Model;
using System.Data.Entity;
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
        public async void Register(User user)
        {
            var foundUser = await FindHelper<User>.FindEntityAsync(context.Users, user);
            foundUser = CheckNullHelper<User>.CheckNullable(foundUser, "User with such login data is already in DB", true);
            context.Users.Add(user);
        }
        public async Task<User> Login(LoginData loginData)
        {
            var foundUser = await context.Users.FirstOrDefaultAsync(x => x.LoginData.CompareTo(loginData).Equals(0));
            return CheckNullHelper<User>.CheckNullable(foundUser, "User with such login data not found", false);
        }
    }
}
