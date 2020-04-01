using System;
using System.Collections.Generic;

namespace Pickem.Domain
{
    public class League
    {
        public League()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string JoinCode { get; set; }
        public List<UserLeague> UserLeague { get; set; }
    }
}
