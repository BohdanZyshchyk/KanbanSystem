using KanbanSystemDAL.Model;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KanbanSystemDAL.AdditionalClasses.EntityInteraction
{
    public class LoginDataInteraction : EntityInteractionBase<LoginData>
    {
        public LoginDataInteraction(KanbanSystemContext _context) : base(_context)
        {

        }
        public async Task<bool> Register(LoginData loginData)
        {
            return await AddEntityAsync(loginData);
        }
        public async Task<User> Login(DbSet<User> set, LoginData loginData)
        {
            return await set.FirstOrDefaultAsync(x => x.LoginData.CompareTo(loginData).Equals(0));
        }
    }
}
