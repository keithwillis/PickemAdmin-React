using System;
using System.Collections.Generic;

namespace Pickem.Domain
{
    public class Schedule
    {
        public int Id { get; set; }
        public int SportLeagueId { get; set; }
        public SportLeague SportLeague { get; set; }
        public List<Game> Games { get; set; }
    }
}
