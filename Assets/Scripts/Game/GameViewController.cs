using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameViewController : MonoBehaviour, ISaveable {
    
    private List<SaveData.AnimalPhoto> animalPhotos;

    public static void SaveJsonData(GameViewController controller){
        SaveData sd = new SaveData();
        controller.PopulateFromSaveData(sd);

        if(FileManager.WriteToFile("SaveData.dat", sd.ToJson() )){
            Debug.Log("Save successful");
        }
    }
    
    public void PopulateFromSaveData(SaveData pSaveData){
        pSaveData.animalPhotos = animalPhotos;
    }

    public static void LoadFromJsonData(GameViewController controller){
        if(FileManager.LoadFromFile("SaveData.dat", out var json)){
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            controller.LoadFromSaveData(sd);
            Debug.Log("Load complete");
        }
    }

    public void LoadFromSaveData(SaveData pSaveData){
        animalPhotos = pSaveData.animalPhotos;
    }
    
}