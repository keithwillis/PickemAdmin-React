using System;
using System.Collections.Generic;

namespace Pickem.Domain
{
    public class User
    {
        public User()
        {
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<League> Leagues { get; set; }
    }
}
