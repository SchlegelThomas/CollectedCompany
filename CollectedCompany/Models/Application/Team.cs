using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectedCompany.Models.Application
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get;set; }

        public virtual ApplicationUser Captain { get; set; }

        public virtual List<ApplicationUser> Members { get; set; }

        [Required]
        [Display(Name="Team Name")]
        public String TeamName { get; set; }

        public String Location { get; set; }

        public String Bio { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Draws { get; set; }

        public virtual List<Contest> Contests { get; set; }
    }

    public class TeamWall
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual Team Team { get; set; }
    }


    public class Contest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual List<TeamEntry> Entries { get; set; }

        [Required]
        [Display(Name="Team Size")]
        public int TeamSize { get; set; }

        public String Name { get; set; }

        public String Rules { get; set; }

        public String Scoring { get; set; }

        public Decimal EntryFee { get; set; }

        public String EventLink { get; set; }

    }


    public class TeamEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual Team Team { get; set; }

        public virtual List<ApplicationUser> EnteredMembers { get; set; }

        public virtual Contest Contest { get; set; }

    }
}