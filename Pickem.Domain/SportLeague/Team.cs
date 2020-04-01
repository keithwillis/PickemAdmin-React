using System;
namespace Pickem.Domain
{
    public class Team
    {
        public Team()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool isActive { get; set; }
        public int DivisionId { get; set; }
    }
}
