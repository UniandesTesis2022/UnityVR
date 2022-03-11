using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData{
    [System.Serializable]
    public struct AnimalPhoto
    {
        public Animal.species specie;
        public string name;
        public bool takenPho;
    }

    public List<AnimalPhoto> animalPhotos = new List<AnimalPhoto>();

    public string ToJson(){
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string jsonObject){
        JsonUtility.FromJsonOverwrite(jsonObject, this);
    }
}

public interface ISaveable{
    void PopulateFromSaveData(SaveData pSaveData);
    void LoadFromSaveData(SaveData pSaveData);
    void PopulateFromGameData(GameData pGameData);
    void LoadFromGameData(GameData pGameData);
}