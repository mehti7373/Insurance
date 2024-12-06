using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Core.Entities;

namespace Insurance.Core.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByUsernameAsync(string username);
    Task AddAsync(User user);
}
