using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CollectedCompany.Models
{
    
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MinLength(10), MaxLength(10)]
        public String DciNumber { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public Boolean? Premium { get; set; }

        public UserType UserType { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Draws { get; set; }

        [NotMapped]
        public IList<IdentityRole> AssignedRoles { get; set; } 

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var isAdmin = (Boolean) (UserType == UserType.Admin);
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim(ClaimKeys.FirstName.ToString(), FirstName ?? String.Empty));
            userIdentity.AddClaim(new Claim(ClaimKeys.LastName.ToString(), LastName ?? String.Empty));
            userIdentity.AddClaim(new Claim(ClaimKeys.IsPremiumMember.ToString(), Premium.GetValueOrDefault(false).ToString()));
            userIdentity.AddClaim(new Claim(ClaimKeys.Admin.ToString(), isAdmin.ToString()));

            // Add custom user claims here
            if (manager.IsInRole(Id, UserType.Admin.ToString()))
            {
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, UserType.Admin.ToString()));
            }
            
            return userIdentity;
        }
    }

    public enum UserType
    {
        ContentProducer,
        Member,
        Premium,
        Admin,
        Sales
    }
}