using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

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
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //Deserialize the data from Json file to game data c# obj.

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad); 
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
            //Create Directory the file will be written to if doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            //Serialize the c# game data object to Json
            string dataToStore = JsonUtility.ToJson(data, true);

            //Write the serialize data to the file.
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {

            Debug.LogError("Error occurred when trying to save data to file : " + fullPath + "\n" + e);
        }
    }
}
