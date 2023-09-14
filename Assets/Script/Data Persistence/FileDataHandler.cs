using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                //Load serialized  data from file.
                // string dataToLoad = "";
                // using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                // {
                //     using (StreamReader reader = new StreamReader(stream))
                //     {
                //         dataToLoad = reader.ReadToEnd();
                //     }
                // }

                // //Deserialize the data from Json file to game data c# obj.

                // loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
               // Debug.Log("File Path = " + fullPath);
                loadedData = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(fullPath));




            }
            catch (Exception e)
            {

                Debug.LogError("Error occurred when trying to load data from file : " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);


        try
        {
            // //Create Directory the file will be written to if doesn't exist
            // Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            // //Serialize the c# game data object to Json
            // string dataToStore = JsonUtility.ToJson(data, true);

            // //Write the serialize data to the file.
            // using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            // {
            //     using (StreamWriter writer = new StreamWriter(stream))
            //     {
            //         writer.Write(dataToStore);
            //     }
            // }
            if (File.Exists(fullPath))
            {
                //                Debug.Log("Data exists. Delete Old and Writing a New One!!" + fullPath);
                File.Delete(fullPath);
            }
            else
            {
              //  Debug.Log("Writing File For the First Time!!");
            }
            using FileStream stream = File.Create(fullPath);
            stream.Close();
            File.WriteAllText(fullPath, JsonConvert.SerializeObject(data, Formatting.Indented));


        }
        catch (Exception e)
        {

            Debug.LogError("Error occurred when trying to save data to file : " + fullPath + "\n" + e);
        }
    }
    public void DeleteFile()
    {
          string fullPath = Path.Combine(dataDirPath, dataFileName);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
        else
        {
           // Debug.Log("No File Found");
        }

    }

    //    public void CreateNewGameData(GameData data,string defaultData)
    //    {
    //      string fullPath = Path.Combine(dataDirPath, dataFileName);

    //         try
    //         {
    //             // if (File.Exists(fullPath))
    //             // {
    //             //     Debug.Log("Data exists. Delete Old and Writing a New One!!" + fullPath);
    //             //     File.Delete(fullPath);
    //             // }
    //             // else
    //             // {
    //             //     Debug.Log("Writing File For the First Time!!");
    //             // }
    //             Debug.Log("Writing Default Game data");
    //             data = JsonConvert.DeserializeObject<GameData>(defaultData);
    //             using FileStream stream = File.Create(fullPath);
    //             stream.Close();
    //             File.WriteAllText(fullPath, JsonConvert.SerializeObject(data, Formatting.Indented));



    //         }
    //         catch (Exception e)
    //         {

    //             Debug.LogError("Error occurred when trying to save data to file : " + fullPath + "\n" + e);
    //         }

    //  }
}
