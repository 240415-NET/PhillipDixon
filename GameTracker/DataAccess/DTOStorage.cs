using GameTracker.Models;
using System.Text.Json;

namespace GameTracker.Data;

public class DTOStorage
{
    public static string filePath = "Games.json";

    public static List<Game> DeserializeGame()
    {
        List<Game?> existingGameList = new List<Game>();
        try
        {
            if (File.Exists(filePath))
            {
                string existingDTOJson = File.ReadAllText(filePath);

                GamesDTO existingDTO = JsonSerializer.Deserialize<GamesDTO>(existingDTOJson);

                if (existingDTO.Games == null)
                    return existingGameList;
                else
                    existingGameList = existingDTO.Games.ToList();
            }
            else if (!File.Exists(filePath))
            {
                GamesDTO existingDTO = new();
                string existingDTOJson = JsonSerializer.Serialize(existingDTO);
                File.WriteAllText(filePath, existingDTOJson);
            }
        }
        catch (Exception e) { }

        return existingGameList;
    }
     public static void SerializeGame(List<Game> existingGameList)
    {
        
        //GamesDTO existingDTO = new GamesDTO(existingGameList);
        string existingDTOJson = File.ReadAllText(filePath);

        GamesDTO existingDTO = JsonSerializer.Deserialize<GamesDTO>(existingDTOJson);

        existingDTO.Games = existingGameList;

        existingDTOJson = JsonSerializer.Serialize(existingDTO);

        File.WriteAllText(filePath, existingDTOJson);
    }
    //*****************used for WIP Remove Games functionality******************************
        public static GamesDTO DeserializeAllGames()
    {
        GamesDTO allGames = new();

         if (File.Exists(filePath))
        {
            string allGamesJSONFilePath = File.ReadAllText(filePath);

            allGames = JsonSerializer.Deserialize<GamesDTO>(allGamesJSONFilePath);

            return allGames;
        }
        else
        {
            return allGames;
        }
    }
    public static void SerializeAllGames(GamesDTO passedListOfGames)
    {
        string refreshListOfGames = JsonSerializer.Serialize(passedListOfGames);
        File.WriteAllText(filePath, refreshListOfGames);
    }
    //*/ 
}