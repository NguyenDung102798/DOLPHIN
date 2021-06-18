using System;
using System.Collections.Generic;
using System.Text;

namespace DOLPHIN.Model
{
    public class Roles : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RoleUser> RoleUsers { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
