using System;
using System.Collections.Generic;

namespace Pickem.Domain
{
    public class SportLeague
    {
        public SportLeague()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isEnabled { get; set; }
        public List<Conference> Conferences { get; set; }
    }
}
