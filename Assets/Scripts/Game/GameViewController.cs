using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameViewController : MonoBehaviour, ISaveable {
    
    private List<SaveData.AnimalPhoto> animalPhotos;

    private static GameViewController instance;

    private void Awake() {
        instance = this;
    }

    public static void SaveJsonData(){
        SaveData sd = new SaveData();
        instance.PopulateFromSaveData(sd);

        if(FileManager.WriteToFile("SaveData.dat", sd.ToJson() )){
            Debug.Log("Save successful");
        }
    }
    
    public void PopulateFromSaveData(SaveData pSaveData){
        pSaveData.animalPhotos = animalPhotos;
    }

    public static void LoadFromJsonData(){
        if(FileManager.LoadFromFile("SaveData.dat", out var json)){
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            instance.LoadFromSaveData(sd);
            Debug.Log("Load complete");
        }
    }

    public void LoadFromSaveData(SaveData pSaveData){
        animalPhotos = pSaveData.animalPhotos;
    }
    
}