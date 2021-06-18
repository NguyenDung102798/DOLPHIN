using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DOLPHIN.Repository.Repositories
{
    /// <summary>
    /// User Repository class.
    /// </summary>
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">context.</param>
        public UserRepository(IDbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// GetUserById.
        /// </summary>
        /// <param name="userId">userId.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Users> GetUserById(string userId)
        {
            return await this.dbset.Where(x => x.Id.Equals(userId)).FirstOrDefaultAsync();
        }
    }
}
