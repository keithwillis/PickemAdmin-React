using System;
namespace Pickem.Domain
{
    public class UserLeague
    {
        public UserLeague()
        {
        }

        public int UserId { get; set; }
        public int LeagueId { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public League League { get; set; }

    }
}
