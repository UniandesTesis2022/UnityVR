using System;
using System.IO;
using UnityEngine;

public class FileManager {
    public static bool WriteToFile(string pFileName, string pFileContent){
        var fullPath = Path.Combine(Application.persistentDataPath, pFileName);

        try {
            File.WriteAllText(fullPath, pFileContent);
            return true;
        }
        catch(Exception e){
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
        }

        return false;
    }
    public static bool LoadFromFile(string pFileName, out string result){
        var fullPath = Path.Combine(Application.persistentDataPath, pFileName);

        try {
            result = File.ReadAllText(fullPath);
            return true;
        }
        catch(Exception e){
            Debug.LogError($"Failed to read from {fullPath} with exception {e}");
            result = "";
        }

        return false;
    }
}