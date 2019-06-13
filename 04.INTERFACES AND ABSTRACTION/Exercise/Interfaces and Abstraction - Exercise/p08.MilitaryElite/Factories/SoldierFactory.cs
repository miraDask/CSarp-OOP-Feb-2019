namespace p08.MilitaryElite.Factories
{
    using p08.MilitaryElite.Interfaces;
    using p08.MilitaryElite.Soldiers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoldierFactory
    {
        public ISoldier CreateSoldier(string[] input, Army army)
        {
            string soldierType = input[0];
            string id = input[1];
            string firstName = input[2];
            string lastName = input[3];
            string corps = string.Empty;
            decimal salary = 0;

            switch (soldierType.ToLower())
            {
                case "private":

                    salary = decimal.Parse(input[4]);

                    return new Private(id, firstName, lastName, salary);

                case "lieutenantgeneral":

                    salary = decimal.Parse(input[4]);
                    string[] privateIds = input.Skip(5).ToArray();
                    List<Private> privates = new List<Private>();

                    foreach (var item in privateIds)
                    {
                        ISoldier @private = army.GetPrivate(item);
                        privates.Add((Private)@private);
                    }

                    return new LieutenantGeneral(id, firstName, lastName, salary, privates);

                case "engineer":

                    salary = decimal.Parse(input[4]);
                    corps = input[5];

                    try
                    {
                        string[] repairsData = input.Skip(6).ToArray();
                        List<Repair> repairs = new List<Repair>();

                        for (int i = 0; i < repairsData.Length; i += 2)
                        {
                            string partName = repairsData[i];
                            int workingHours = int.Parse(repairsData[i + 1]);
                            Repair repair = new Repair(partName, workingHours);
                            repairs.Add(repair);
                        }

                        return new Engineer(id, firstName, lastName, salary, corps, repairs);
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }

                case "spy":

                    int codeNumber = int.Parse(input[4]);
                    return new Spy(id, firstName, lastName, codeNumber);

                case "commando":

                    salary = decimal.Parse(input[4]);
                    corps = input[5];
                    string[] missionData = input.Skip(6).ToArray();
                    List<Mission> missions = new List<Mission>();

                    for (int i = 0; i < missionData.Length; i += 2)
                    {
                        string code = missionData[i];
                        string state = missionData[i + 1];

                        try
                        {
                            Mission mission = new Mission(code, state);
                            missions.Add(mission);
                        }
                        catch (ArgumentException)
                        {
                            continue;
                        }
                    }

                    try
                    {
                        Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                        return commando;
                    }
                    catch (ArgumentException)
                    {
                        return null;
                    }

                default:
                    return null;
            }
        }
    }
}
