using System;
using System.Collections.Generic;

namespace Pickem.Domain
{
    public class Conference
    {
        public Conference()
        {
        }

        public int Id { get; set; }
        public List<Division> Divisions { get; set; }
        public int SportLeagueId { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
