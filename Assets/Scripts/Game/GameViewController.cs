using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameViewController : MonoBehaviour, ISaveable {
    
    private Dictionary<Animal.species, List<Animal>> allAnimals;

    private List<SaveData.AnimalPhoto> animalPhotos;

    public static GameViewController instance;

    public bool isPlaying;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }

        GenerateGameData();
        ScreenshotHandler.DeletePhotos();
        //LoadFromGameData();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        GenerateGameData();
        ScreenshotHandler.DeletePhotos();
    }


    public void GenerateGameData(){
        allAnimals = new Dictionary<Animal.species, List<Animal>>();
        foreach(Animal.species specie in Enum.GetValues(typeof(Animal.species)))
        {
            allAnimals.Add(specie, new List<Animal>());
        }

        AnimalObject[] animalsObjects = FindObjectsOfType<AnimalObject>();
        List<string> animalNames = new List<string>();

        foreach (AnimalObject item in animalsObjects)
        {
            allAnimals.TryGetValue(item.animal.specie, out List<Animal> currentList);
            if(currentList != null && !animalNames.Contains(item.animal.name)){
                currentList.Add(item.animal);
                allAnimals[item.animal.specie] = currentList;
                animalNames.Add(item.animal.name);
            }
        }

        SaveGameData();
    }

    public static List<Animal> GetAnimalsBySpecie(Animal.species pSpecie){
        
        if(instance != null && instance.allAnimals.TryGetValue(pSpecie, out List<Animal> returnList)){
            return returnList;
        }else{
            return new List<Animal>();
        }
        
    }

    public static List<Animal> GetAllAnimals()
    {
        List<Animal> returnList = new List<Animal>();

        foreach (KeyValuePair<Animal.species, List<Animal>> animalList in instance.allAnimals)
        {
            returnList.AddRange(animalList.Value);
        }

        return returnList;
    }

    public static void SaveJsonData(){
        SaveData sd = new SaveData();
        instance.PopulateFromSaveData(sd);

        if(FileManager.WriteToFile("SaveData.dat", sd.ToJson() )){
            Debug.Log("Save successful");
        }
    }

    public static void SaveGameData(){
        GameData gd = new GameData();
        instance.PopulateFromGameData(gd);

        if(FileManager.WriteGameDataToFile("Animals.dat", gd.ToJson() )){
            Debug.Log("Save successful");
        }
    }
    
    public void PopulateFromSaveData(SaveData pSaveData){
        pSaveData.animalPhotos = animalPhotos;
    }

    public void PopulateFromGameData(GameData pGameData){
        pGameData.GetDictionary(allAnimals);
    }

    public static void LoadFromJsonData(){
        if(FileManager.LoadFromFile("SaveData.dat", out string json)){
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            instance.LoadFromSaveData(sd);
            Debug.Log("Load complete");
        }
    }

    public static void LoadFromGameData(){
        if(FileManager.LoadGameDataToFile("Animals.dat", out string json)){
            GameData gd = new GameData();
            gd.LoadFromJson(json);

            instance.LoadFromGameData(gd);
            Debug.Log("Load complete");
        }
    }

    public void LoadFromSaveData(SaveData pSaveData){
        animalPhotos = pSaveData.animalPhotos;
    }

    public void LoadFromGameData(GameData pGameData){
        allAnimals = pGameData.ReturnDictionary();
    }
}