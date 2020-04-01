using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Pickem.Data;
using Pickem.Domain;


namespace PickemConsole
{
    class Program
    {
        private static PickemContext _context;

        static void Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

           var opt = new DbContextOptionsBuilder(new DbContextOptions<PickemContext>())
                .UseNpgsql(Configuration.GetConnectionString("PickemConnex"))
                       .EnableSensitiveDataLogging();
            
            _context = new PickemContext((DbContextOptions<PickemContext>)opt.Options);

            _context.Database.EnsureCreated();

            PopulateNFLData();

            Console.WriteLine("Press Any Key...");
            Console.ReadKey();
        }

        private static void PopulateNFLData()
        {
            WriteSportLeagueData("Before Add - ", GetLeagues());
            var league = AddSportLeague("NFL", true);

            WriteSportLeagueData("AfterAdd - ", GetLeagues());

        }

        private static List<SportLeague> GetLeagues()
        {
            return _context.SportLeagues
                .Include(l => l.Conferences)
                .ThenInclude(c => c.Divisions)
                .ThenInclude(d => d.Teams)
                .ToList();
        }

        
        private static SportLeague AddSportLeague(string Name, bool isEnabled)
        {
            var league = GetLeagueByName(Name);
            
            if (league == null)
            {
                league = new SportLeague { Name = Name, isEnabled = isEnabled, Conferences=new List<Conference>() };
            }
            else
            {
                league.Name = Name;
                league.isEnabled = isEnabled;
            }
            var conf = AddConference(league, "AFC", true);
            var div1 = AddDivision(conf, "North", true);
            AddTeam(div1, "Baltimore", "Ravens", true);
            AddTeam(div1, "Pittsburgh", "Steelers", true);
            AddTeam(div1, "Cleveland", "Browns", true);
            AddTeam(div1, "Cincinnati", "Bengals", true);
            var div2 = AddDivision(conf, "South", true);
            AddTeam(div2, "Houston", "Texans", true);
            AddTeam(div2, "Tennessee", "Titans", true);
            AddTeam(div2, "Indianapolis", "Colts", true);
            AddTeam(div2, "Jacksonville", "Jaguars", true);
            var div3 = AddDivision(conf, "East", true);
            AddTeam(div3, "New England", "Patriots", true);
            AddTeam(div3, "Buffalo", "Bills", true);
            AddTeam(div3, "New York", "Jets", true);
            AddTeam(div3, "Miami", "Dolphins", true);
            var div4 = AddDivision(conf, "West", true);
            AddTeam(div4, "Baltimore", "Chiefs", true);
            AddTeam(div4, "Baltimore", "Broncos", true);
            AddTeam(div4, "Los Vegas", "Raiders", true);
            AddTeam(div4, "Los Angeles", "Chargers", true);
            Conference conf2 = AddConference(league, "NFC", true);
            var div5 = AddDivision(conf2, "North", true);
            AddTeam(div5, "Chicago", "Bears", true);
            AddTeam(div5, "Green Bay", "Packers", true);
            AddTeam(div5, "Detroit", "Lions", true);
            AddTeam(div5, "Minnesota", "Vikings", true);
            var div6 = AddDivision(conf2, "South", true);
            AddTeam(div6, "New Orleans", "Saints", true);
            AddTeam(div6, "Atlanta", "Falcons", true);
            AddTeam(div6, "Tampa Bay", "Buccaneers", true);
            AddTeam(div6, "Carolina", "Panthers", true);
            var div7 = AddDivision(conf2, "East", true);
            AddTeam(div7, "Philadelphia", "Eagles", true);
            AddTeam(div7, "Dallas", "Cowboys", true);
            AddTeam(div7, "Washington", "Redskins", true);
            AddTeam(div7, "New York", "Giants", true);
            var div8 = AddDivision(conf2, "West", true);
            AddTeam(div8, "San Francisco", "49ers", true);
            AddTeam(div8, "Seattle", "Seahawks", true);
            AddTeam(div8, "Los Angeles", "Rams", true);
            AddTeam(div8, "Arizona", "Cardinals", true);
            _context.Attach(league);
            _context.SaveChanges();

            return league;
        }

        private static SportLeague GetLeagueByName(string name)
        {
            return GetLeagues().FirstOrDefault(l => l.Name == name);
        }

        private static void AddTeam(Division division, string Location, String Name, bool isActive)
        {
            Team team;
            if (!division.Teams.Exists(t => t.Name == Name && t.Location == Location))
            {
                team = new Team { Location=Location, Name = Name, isActive = isActive };
                division.Teams.Add(team);
              //  _context.Divisions.First(d => d.Id == division.Id).Teams.Add(team);
            }
            else
            {
                team = division.Teams.First(t => t.Name == Name && t.Location==Location);
                team.Name = Name;
                team.Location = Location;
                division.isActive = isActive;
            }
            //_context.SaveChanges();
        }

        private static Division AddDivision(Conference conference, String Name, bool isActive)
        {
            Division division;
            if (!conference.Divisions.Exists(d => d.Name == Name))
            {
                division = new Division { Name = Name, isActive = isActive, Teams = new List<Team>() };
                conference.Divisions.Add(division);
            }
            else
            {
                division = conference.Divisions.First(d => d.Name == Name);
                division.Name = Name;
                division.isActive = isActive;
            }
            return division;
        }

        private static Conference AddConference(SportLeague league, string Name, bool isActive)
        {
            Conference conference;
            if (!league.Conferences.Exists(c => c.Name == Name))
            {
                conference = new Conference { Name = Name, isActive = isActive, Divisions = new List<Division>() };
                league.Conferences.Add(conference);
                
            }
            else
            {
                conference = league.Conferences.First(c => c.Name == Name);
                conference.Name = Name;
                conference.isActive = isActive;
            }
            return conference;
        }

        private static void WriteSportLeagueData(string Text, List<SportLeague> leagues)
        {
            Console.WriteLine($"{Text}: League Count is {leagues.Count}");
            foreach(SportLeague l in leagues)
            {
                Console.WriteLine($"LeagueName:{l.Name}, isEnabled: {l.isEnabled}");
                foreach(Conference c in l.Conferences)
                {
                    Console.WriteLine($"League: {l.Name} - Conference: {c.Name}");
                    foreach(Division d in c.Divisions)
                    {
                        Console.WriteLine($"League: {l.Name} - Conference: {c.Name} Division: {d.Name}");
                        foreach(Team t in d.Teams)
                        {
                            Console.WriteLine($"League: {l.Name} - Conference: {c.Name} Division: {d.Name} Team: {t.Location} {t.Name}");
                        }
                    }
                }
            }
        }
    }
}
