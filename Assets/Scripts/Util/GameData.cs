using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData{
    [System.Serializable]
    public struct AnimalDict
    {
        public Animal.species specie;
        public List<Animal> animals;
    }

    public List<AnimalDict> allAnimals;

    public void GetDictionary(Dictionary<Animal.species, List<Animal>> pDict){
        allAnimals = new List<AnimalDict>();
        foreach(KeyValuePair<Animal.species,List<Animal>> item in pDict)
        {
            AnimalDict newItem = new AnimalDict();
            newItem.specie = item.Key;
            newItem.animals = item.Value;
            allAnimals.Add(newItem);
        }
    }

    public Dictionary<Animal.species, List<Animal>> ReturnDictionary(){
        Dictionary<Animal.species, List<Animal>> newDict = new Dictionary<Animal.species, List<Animal>>();

        foreach(AnimalDict item in allAnimals)
        {
            newDict.Add(item.specie, item.animals);
        }

        return newDict;
    }

    public string ToJson(){
        Debug.Log(JsonUtility.ToJson(this));
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string jsonObject){
        JsonUtility.FromJsonOverwrite(jsonObject, this);
    }
}