using DOLPHIN.Model;
using DOLPHIN.Repository.Common;
using DOLPHIN.Repository.Interfaces;
using DOLPHIN.Repository.Repositories;
using DOLPHIN.Repository.UnitOfWorks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.Repository.UnitOfWorks
{
    public class UserUnitOfWork : UnitOfWorkBase, IUserUnitOfWork
    {
        private IUserRepository userRepository;
        private IRoleUserRepository roleUserRepository;
        private IRolePermissionRepository rolePermissionRepository;

        public UserUnitOfWork(IDbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Gets User Repository.
        /// </summary>
        public IUserRepository UserRepository => this.userRepository ??= new UserRepository(this.dbContext);

        /// <inheritdoc/>
        public IRoleUserRepository RoleUserRepository => this.roleUserRepository ??= new RoleUserRepository(this.dbContext);

        /// <inheritdoc/>
        public IRolePermissionRepository RolePermissionRepository => this.rolePermissionRepository ??= new RolePermissionRepository(this.dbContext);
    }
}
