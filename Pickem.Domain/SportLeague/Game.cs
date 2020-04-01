using System;
namespace Pickem.Domain
{
    public class Game
    {
        public Game()
        {
        }

        public int Id { get; set; }
        public Team Visitor { get; set; }
        public Team Home { get; set; }
        public DateTime GameTime { get; set; }
        public int HomeScore { get; set; }
        public int VisitorScore { get; set; }
        public int GameGroupId { get; set; }
        public GameGroup GameGroup { get; set; }
    }
}
