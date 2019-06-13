namespace _06.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var splitedInput = input.Split(';');

                var command = splitedInput[0];
                var teamName = splitedInput[1];


                if (command == "Team")
                {
                    try
                    {
                        teams.Add(new Team(teamName));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                }
                else
                {
                    if (!teams.Any(x => x.Name == teamName))
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        continue;
                    }

                    var team = teams.Find(x => x.Name == teamName);

                    switch (command)
                    {
                        case "Add":
                            var playerName = splitedInput[2];
                            var endurance = int.Parse(splitedInput[3]);
                            var sprint = int.Parse(splitedInput[4]);
                            var dribble = int.Parse(splitedInput[5]);
                            var passing = int.Parse(splitedInput[6]);
                            var shooting = int.Parse(splitedInput[7]);

                            try
                            {
                                var stats = new SkillStatus(endurance, sprint, dribble, passing, shooting);
                                var player = new Player(playerName, stats);
                                team.AddPlayer(player);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            break;

                        case "Remove":

                            var nameOfPlayer = splitedInput[2];
                            
                            try
                            {
                                team.RemovePlayer(nameOfPlayer);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            break;

                        case "Rating":

                            Console.WriteLine($"{team.Name} - {team.Rating}");
                            break;
                    }
                }
            }
        }
    }
}
