using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace _01.IntroductionToDBApps
{
    class Startup
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection(@"
                                        Server=DESKTOP-Q7IVEUU\SQLEXPRESS;
                                        Database=MinionsDB;
                                        Integrated Security=true");
            connection.Open();

            using (connection)
            {
                // 02. Get villains' names 
                GetVillainsNames(connection);

                // 03. Get minions names 
                // read input 
                //int id = int.Parse(Console.ReadLine());
                //GetMinionsNames(id, connection);

                // 04. Add minion
                // read input 
                //Console.Write("Minion: ");
                //string[] minionArgs = Console.ReadLine().Split(' ');

                //Console.Write("Villain: ");
                //string villainName = Console.ReadLine();
                //AddMinion(minionArgs, villainName, connection);

                //05. Change town names casing 
                //read input
                //string country = Console.ReadLine();
                //ChangeTownNamesCasing(country, connection);

                // 06. Remove villain
                //int idVillain = int.Parse(Console.ReadLine());
                //RemoveVillain(idVillain, connection);

                // 07. Print all minion names 
                //PrintAllMinionNames(connection);

                // 08. Increase minions age 
                //int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
                //IncreaseMinionsAge(ids, connection);

                // 09. Increase age stored procedure
                //int idMinion = int.Parse(Console.ReadLine());
                //IncreaseAgeStoredProcedure(idMinion, connection);
            }
        }

        private static void GetVillainsNames(SqlConnection connection)
        {
            SqlCommand getNamesCommand = new SqlCommand(@"
                                      SELECT v.Name, COUNT(VillainId) 
                                      FROM Villains AS v
                                      INNER JOIN Minions_Villains AS MV
                                      ON v.Id = mv.VillainId
                                      GROUP BY v.Name
                                      HAVING COUNT(VillainId) > 3", connection);

            SqlDataReader reader = getNamesCommand.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("There's no villains with number of minions more than 3!");
                return;
            }

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }
            }
        }

        private static void GetMinionsNames(int id, SqlConnection connection)
        {
            SqlCommand villainNameCommand = new SqlCommand($@"SELECT Name FROM Villains WHERE Id = {id}", connection);
            string villainName = villainNameCommand.ExecuteScalar().ToString();
            Console.WriteLine($"Villain: {villainName}");

            SqlCommand minionsCommand = new SqlCommand($@"
                                  SELECT m.Name, m.Age
                                  FROM Villains AS v
                                  INNER JOIN Minions_Villains AS mv
                                  ON v.Id = mv.VillainId
                                  INNER JOIN Minions AS m
                                  ON mv.MinionId = m.Id
                                  WHERE v.Id = {id}", connection);

            SqlDataReader minionsReader = minionsCommand.ExecuteReader();

            if (!minionsReader.HasRows)
            {
                Console.WriteLine("(no minions)");
                return;
            }

            int count = 1;
            while (minionsReader.Read())
            {
                Console.WriteLine($"{count}. {minionsReader[0]} {minionsReader[1]}");

                count++;
            }
        }

        private static void AddMinion(string[] minionArgs, string villainName,
            SqlConnection connection)
        {
            try
            {
                string minionName = minionArgs[0];
                int minionAge = int.Parse(minionArgs[1]);
                string townName = minionArgs[2];

                // check if town exists
                SqlCommand townExists = new SqlCommand($@"SELECT TownName FROM Towns WHERE TownName = '{townName}'",
                    connection);
                var town = townExists.ExecuteScalar();

                // town doesn't exists, insert it
                if (town == null)
                {
                    SqlCommand insertTown = new SqlCommand($@"INSERT INTO Towns(TownName) VALUES ('{townName}')",
                        connection);
                    int affectedRows = insertTown.ExecuteNonQuery();

                    if (affectedRows == 1)
                    {
                        Console.WriteLine($"Town {townName} was added to the database.");
                    }
                }

                // check if villain exist 
                SqlCommand villainExists = new SqlCommand(
                    $@"SELECT Name FROM Villains WHERE Name = '{villainName}'",
                    connection);
                var villain = villainExists.ExecuteScalar();

                // villain doesn't exists, insert it
                if (villain == null)
                {
                    SqlCommand insertVillain =
                        new SqlCommand($@"INSERT INTO Villains(Name) VALUES ('{villainName}')",
                            connection);
                    int affectedRows = insertVillain.ExecuteNonQuery();

                    if (affectedRows == 1)
                    {
                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }
                }

                // add minion
                SqlCommand addMinion =
                    new SqlCommand(
                        $@"INSERT INTO Minions(Name, Age, TownId) VALUES ('{minionName}', {minionAge}, 
                           (SELECT Id FROM Towns WHERE TownName = '{townName}')) ",
                        connection);
                int rows = addMinion.ExecuteNonQuery();

                if (rows == 1)
                {
                    // insert into MinionsVillains Ids
                    SqlCommand minionsVillains =
                        new SqlCommand($@"INSERT INTO Minions_Villains(MinionId, VillainId) VALUES 
                                                  ((SELECT Id FROM Minions WHERE Name = '{minionName}'), 
                                                  (SELECT Id FROM Villains WHERE Name = '{villainName}'))", connection);
                    int resultRows = minionsVillains.ExecuteNonQuery();

                    if (resultRows == 1)
                    {
                        Console.WriteLine($"Successfully added {minionName} to be minions of {villainName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred. The database will not change.");
            }
        }

        private static void ChangeTownNamesCasing(string countryName, SqlConnection connection)
        {
            SqlCommand updateTowns = new SqlCommand($@"
                                   UPDATE Towns 
                                   SET TownName = UPPER(TownName)
                                   WHERE Country = @countryName", connection);
            updateTowns.Parameters.AddWithValue("@countryName", countryName);
            int affectedRows = updateTowns.ExecuteNonQuery();

            Console.WriteLine($"{affectedRows} names were affected.");

            SqlCommand selectUpdated = new SqlCommand($@"SELECT TownName FROM Towns WHERE Country = '{countryName}'", connection);
            SqlDataReader reader = selectUpdated.ExecuteReader();
            List<string> updatedTowns = new List<string>();

            while (reader.Read())
            {
                updatedTowns.Add(reader[0].ToString());
            }

            Console.WriteLine($"[{String.Join(", ", updatedTowns)}]");
        }

        private static void RemoveVillain(int id, SqlConnection connection)
        {
            try
            {
                SqlCommand villainName = new SqlCommand($@"SELECT Name FROM Villains WHERE Id = {id}", connection);
                string villain = villainName.ExecuteScalar().ToString();
                if (villain == String.Empty)
                {
                    Console.WriteLine("No such villain was found");
                    return;
                }

                SqlCommand deleteConnectedMinions = new SqlCommand($@"DELETE FROM Minions_Villains WHERE VillainId = {id}", connection);
                int deleteConnctedMinionsAffRows = deleteConnectedMinions.ExecuteNonQuery();

                SqlCommand deleteVillain = new SqlCommand($@"DELETE FROM Villains WHERE Id = {id}", connection);
                int deleteAffRows = deleteVillain.ExecuteNonQuery();

                if (deleteAffRows == 1)
                {
                    Console.WriteLine($"{villain} was deleted");
                }
               
                Console.WriteLine($"{deleteConnctedMinionsAffRows} minions released");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred. The database will not change.\n" + ex);
            }
        }

        private static void PrintAllMinionNames(SqlConnection connection)
        {
            // add all minions in their original order in list
            SqlCommand getAllMinionNames = new SqlCommand($@"SELECT Name FROM Minions", connection);
            SqlDataReader reader = getAllMinionNames.ExecuteReader();
            List<string> namesOriginalOrder = new List<string>();

            while (reader.Read())
            {
                namesOriginalOrder.Add(reader[0].ToString());
            }
        
            while (namesOriginalOrder.Count > 0)
            {
                
                Console.WriteLine(namesOriginalOrder.First());
                namesOriginalOrder.Remove(namesOriginalOrder.First());

                if (namesOriginalOrder.Count == 0)
                {
                    break;
                }

                Console.WriteLine(namesOriginalOrder.Last());
                namesOriginalOrder.Remove(namesOriginalOrder.Last());               
            }
        }

        private static void IncreaseMinionsAge(int[] ids, SqlConnection connection)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                SqlCommand increaseAge = new SqlCommand($@"
                                       UPDATE Minions
                                       SET Age += 1 
                                       WHERE Id = {ids[i]}", connection);
                increaseAge.ExecuteNonQuery();

                SqlCommand changeName = new SqlCommand($@"
                                         UPDATE Minions
                                         SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name))
                                         WHERE Id = {ids[i]}", connection);
                changeName.ExecuteNonQuery();
            }

            SqlCommand printMinions = new SqlCommand($@"SELECT Name, Age FROM Minions", connection);
            SqlDataReader reader = printMinions.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
        }

        private static void IncreaseAgeStoredProcedure(int id, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("usp_GetOlder", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@minionId", id);
            command.ExecuteNonQuery();

            SqlCommand printMinions = new SqlCommand($@"SELECT Name, Age FROM Minions WHERE Id = {id}", connection);
            SqlDataReader reader = printMinions.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
        }
    }
}