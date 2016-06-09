using System;
using System.Collections.Generic;
using System.Linq;
using CollectedCompany.Models;
using CollectedCompany.Models.Application;
using CollectedCompany.ServiceLayer.Integrations.Site.Bindings;
using CollectedCompany.ServiceLayer.Integrations.Site.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using WebGrease.Css.Extensions;

namespace CollectedCompany.ServiceLayer.Integrations.Site.Impl
{
    public class UserManagement: IUserManagement
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserRoles[] _userRoles;
        private readonly StaffRoles[] _staffRoles;

        public UserManagement(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _userRoles = (UserRoles[])Enum.GetValues(typeof(UserRoles));
            _staffRoles = (StaffRoles[])Enum.GetValues(typeof(StaffRoles));
        }

        public void UpdateRoles(Permissions permissions)
        {
            var staffLookup = _applicationDbContext.StaffMembers.FirstOrDefault(x => x.UserAccount.Id == permissions.User.Id);

            if (staffLookup != null)
            {
                UpdateStaffRoles(staffLookup, permissions.StaffRoles);
            }

            UpdateUserRoles(permissions.User, permissions.UserRoles);
        }

        public Permissions GetPermission(ApplicationUser user)
        {
            List<StaffPermission> staffPermissions = new List<StaffPermission>();
            List<UserPermission> userPermissions = new List<UserPermission>();
            _staffRoles.ForEach(x =>
            {
                var userRole = _applicationDbContext.Roles.FirstOrDefault(role => role.Name == x.ToString());
                staffPermissions.Add(user.Roles.Any(y => y.RoleId == userRole.Id)
                    ? new StaffPermission {IsInRole = true, UserRole = x}
                    : new StaffPermission {IsInRole = false, UserRole = x});
            });

            _userRoles.ForEach(x =>
            {
                var userRole = _applicationDbContext.Roles.FirstOrDefault(role => role.Name == x.ToString());
                userPermissions.Add(user.Roles.Any(y => y.RoleId == userRole.Id)
                    ? new UserPermission { IsInRole = true, UserRole = x }
                    : new UserPermission { IsInRole = false, UserRole = x });
            });

            Permissions permissions = new Permissions
            {
                User = user,
                StaffRoles = staffPermissions,
                UserRoles = userPermissions
            };

            return permissions;
        }

        private void UpdateUserRoles(ApplicationUser applicationUser, List<UserPermission> list)
        {
            foreach (var role in list)
            {
                var userRole = _applicationDbContext.Roles.FirstOrDefault(x => x.Name == role.ToString());
                if (role.IsInRole)
                {

                    if (applicationUser.Roles.All(x => x.RoleId != userRole.Id))
                    {
                        AddRole(userRole, applicationUser);
                    }
                }
                else
                {
                    if (applicationUser.Roles.Any(x => x.RoleId == userRole.Id))
                    {
                        RemoveRole(userRole, applicationUser);
                    }
                }
            }
        }

        private void UpdateStaffRoles(Staff staffLookup, List<StaffPermission> list)
        {

            foreach (var role in list)
            {
                var userRole = _applicationDbContext.Roles.FirstOrDefault(x => x.Name == role.ToString());
                if (role.IsInRole)
                {
                    
                    if (staffLookup.UserAccount.Roles.All(x => x.RoleId != userRole.Id))
                    {
                        AddRole(userRole, staffLookup.UserAccount);
                    }
                }
                else
                {
                    if (staffLookup.UserAccount.Roles.Any(x => x.RoleId == userRole.Id))
                    {
                        RemoveRole(userRole, staffLookup.UserAccount);
                    }
                }
            }
        }


        void AddRole(IdentityRole role, ApplicationUser user)
        {
            _applicationDbContext.UserRoles.Add(new IdentityUserRole
            {
                RoleId = role.Id,
                UserId = user.Id
            });
        }

        void RemoveRole(IdentityRole role, ApplicationUser user)
        {
            var userRole = _applicationDbContext.UserRoles.First(x => x.RoleId == role.Id && x.UserId == user.Id);
            _applicationDbContext.UserRoles.Remove(userRole);
        }
    }
}