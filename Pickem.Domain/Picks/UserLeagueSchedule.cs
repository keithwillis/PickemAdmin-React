using System;
namespace Pickem.Domain
{
    public class UserLeagueSchedule
    {
        public UserLeagueSchedule()
        {
        }

        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
