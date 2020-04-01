const teams = [
  {
    id: 1,
    name: "Ravens",
    location: "Baltimore",
    isActive: true,
    divisionId: 1
  },
  {
    id: 2,
    name: "Seahawks",
    location: "Seattle",
    isActive: true,
    divisionId: 8
  },
  {
    id: 3,
    name: "49ers",
    location: "San Francisco",
    isActive: true,
    divisionId: 8
  },
  {
    id: 4,
    name: "Giants",
    location: "New York",
    isActive: true,
    divisionId: 7
  },
  {
    id: 5,
    name: "Redskins",
    location: "Washington",
    isActive: true,
    divisionId: 7
  },
  {
    id: 6,
    name: "Cowboys",
    location: "Dallas",
    isActive: true,
    divisionId: 7
  },
  {
    id: 7,
    name: "Eagles",
    location: "Philadelphia",
    isActive: true,
    divisionId: 7
  },
  {
    id: 8,
    name: "Panthers",
    location: "Carolina",
    isActive: true,
    divisionId: 6
  },
  {
    id: 9,
    name: "Buccaneers",
    location: "Tampa Bay",
    isActive: true,
    divisionId: 6
  },
  {
    id: 10,
    name: "Falcons",
    location: "Atlanta",
    isActive: true,
    divisionId: 6
  },
  {
    id: 11,
    name: "Saints",
    location: "New Orleans",
    isActive: true,
    divisionId: 6
  },
  {
    id: 12,
    name: "Vikings",
    location: "Minnesota",
    isActive: true,
    divisionId: 5
  },
  {
    id: 13,
    name: "Lions",
    location: "Detroit",
    isActive: true,
    divisionId: 5
  },
  {
    id: 14,
    name: "Packers",
    location: "Green Bay",
    isActive: true,
    divisionId: 5
  },
  {
    id: 15,
    name: "Bears",
    location: "Chicago",
    isActive: true,
    divisionId: 5
  },
  {
    id: 16,
    name: "Chargers",
    location: "Los Angeles",
    isActive: true,
    divisionId: 4
  },
  {
    id: 17,
    name: "Raiders",
    location: "Los Vegas",
    isActive: true,
    divisionId: 4
  },
  {
    id: 18,
    name: "Broncos",
    location: "Baltimore",
    isActive: true,
    divisionId: 4
  },
  {
    id: 19,
    name: "Chiefs",
    location: "Baltimore",
    isActive: true,
    divisionId: 4
  },
  {
    id: 20,
    name: "Dolphins",
    location: "Miami",
    isActive: true,
    divisionId: 3
  },
  {
    id: 21,
    name: "Jets",
    location: "New York",
    isActive: true,
    divisionId: 3
  },
  {
    id: 22,
    name: "Bills",
    location: "Buffalo",
    isActive: true,
    divisionId: 3
  },
  {
    id: 23,
    name: "Patriots",
    location: "New England",
    isActive: true,
    divisionId: 3
  },
  {
    id: 24,
    name: "Jaguars",
    location: "Jacksonville",
    isActive: true,
    divisionId: 2
  },
  {
    id: 25,
    name: "Colts",
    location: "Indianapolis",
    isActive: true,
    divisionId: 2
  },
  {
    id: 26,
    name: "Titans",
    location: "Tennessee",
    isActive: true,
    divisionId: 2
  },
  {
    id: 27,
    name: "Texans",
    location: "Houston",
    isActive: true,
    divisionId: 2
  },
  {
    id: 28,
    name: "Bengals",
    location: "Cincinnati",
    isActive: true,
    divisionId: 1
  },
  {
    id: 29,
    name: "Browns",
    location: "Cleveland",
    isActive: true,
    divisionId: 1
  },
  {
    id: 30,
    name: "Steelers",
    location: "Pittsburgh",
    isActive: true,
    divisionId: 1
  },
  {
    id: 31,
    name: "Rams",
    location: "Los Angeles",
    isActive: true,
    divisionId: 8
  },
  {
    id: 32,
    name: "Cardinals",
    location: "Arizona",
    isActive: true,
    divisionId: 8
  }
];

const sportLeagues = [
  {
    id: 1,
    name: "NFL",
    isEnabled: true
  },
  {
    id: 2,
    name: "NBA",
    isEnabled: false
  },
  {
    id: 3,
    name: "NHL",
    isEnabled: false
  },
  {
    id: 4,
    name: "MLB",
    isEnabled: false
  },
  {
    id: 5,
    name: "XFL",
    isEnabled: false
  },
  {
    id: 6,
    name: "MLS",
    isEnabled: false
  }
];

const conferences = [
  {
    id: 1,
    divisions: null,
    sportLeagueId: 1,
    name: "AFC",
    isActive: true
  },
  {
    id: 2,
    divisions: null,
    sportLeagueId: 1,
    name: "NFC",
    isActive: true
  }
];

const divisions = [
  {
    id: 1,
    name: "North",
    isActive: true,
    teams: null,
    conferenceId: 1
  },
  {
    id: 2,
    name: "South",
    isActive: true,
    teams: null,
    conferenceId: 1
  },
  {
    id: 3,
    name: "East",
    isActive: true,
    teams: null,
    conferenceId: 1
  },
  {
    id: 4,
    name: "West",
    isActive: true,
    teams: null,
    conferenceId: 1
  },
  {
    id: 5,
    name: "North",
    isActive: true,
    teams: null,
    conferenceId: 2
  },
  {
    id: 6,
    name: "South",
    isActive: true,
    teams: null,
    conferenceId: 2
  },
  {
    id: 7,
    name: "East",
    isActive: true,
    teams: null,
    conferenceId: 2
  },
  {
    id: 8,
    name: "West",
    isActive: true,
    teams: null,
    conferenceId: 2
  }
];

module.exports = {
  sportLeagues,
  teams,
  conferences,
  divisions
};
