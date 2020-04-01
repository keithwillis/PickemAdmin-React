using System;
using System.Collections.Generic;

namespace Pickem.Domain
{
    public class Division
    {
        public Division()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public List<Team> Teams { get; set; }
        public int ConferenceId { get; set; }
    }
}
