using System;
using System.IO;
using UnityEngine;

public class FileManager {

    public static bool WriteToFile(string pFolder, string pFileName, Texture2D pFileContent){
        var fullPath = Path.Combine(Application.persistentDataPath, pFolder);
        if(!Directory.Exists(fullPath)) {
            Directory.CreateDirectory(fullPath);
        }
        fullPath = Path.Combine(fullPath, pFileName) + ".jpg";
        
        try {
            File.WriteAllBytes(fullPath, pFileContent.EncodeToJPG());
            return true;
        }
        catch(Exception e){
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
        }

        return false;
    }

    public static void DeleteFilesInFolder(string path)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, path);
        if (Directory.Exists(fullPath)) { Directory.Delete(fullPath, true); }
        Directory.CreateDirectory(fullPath);
    }

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

    public static bool WriteGameDataToFile(string pFileName, string pFileContent){
        Debug.Log(Application.streamingAssetsPath);
        Debug.Log(pFileContent);
        var fullPath = Path.Combine(Application.streamingAssetsPath, "Gamedata", pFileName);
        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
        }
        try {
            File.WriteAllText(fullPath, pFileContent);
            return true;
        }
        catch(Exception e){
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
        }

        return false;
    }

    public static bool FileExists(string pFolder, string pFileName)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, pFolder, pFileName) + ".jpg";
        return File.Exists(fullPath);
    }

    public static bool LoadFromFile(string pFileName, out Texture2D result){
        var fullPath = Path.Combine(Application.persistentDataPath, pFileName);

        result = null;

        Texture2D Tex2D;
        byte[] FileData;
        
        try {
            if (File.Exists(fullPath)){
                FileData = File.ReadAllBytes(fullPath);
                Tex2D = new Texture2D(2, 2);    
                
                if(Tex2D.LoadImage(FileData)){
                    result = Tex2D;
                    return true;
                }  
            }
             
        }
        catch(Exception e){
            Debug.LogError($"Failed to read from {fullPath} with exception {e}");
            return false;
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

    public static bool LoadGameDataToFile(string pFileName, out string result){
        var fullPath = Path.Combine(Application.streamingAssetsPath, "Gamedata", pFileName);

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