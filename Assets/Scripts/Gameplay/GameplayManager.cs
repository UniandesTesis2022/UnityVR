using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    private Dictionary<Animal.Order, List<Animal>> allAnimals;

    public bool isPlaying;

    public MenuUI menuUI;

    public int total;
    public int pictures;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        GenerateGameData();
        ScreenshotHandler.DeletePhotos();

        pictures = 0;
        total = GetAllAnimals().Count;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GenerateGameData();
        ScreenshotHandler.DeletePhotos();
    }

    public void GenerateGameData()
    {
        allAnimals = new Dictionary<Animal.Order, List<Animal>>();
        foreach (Animal.Order specie in Enum.GetValues(typeof(Animal.Order)))
        {
            allAnimals.Add(specie, new List<Animal>());
        }

        AnimalObject[] animalsObjects = FindObjectsOfType<AnimalObject>();
        List<string> animalNames = new List<string>();

        foreach (AnimalObject item in animalsObjects)
        {
            allAnimals.TryGetValue(item.animal.animalOrder, out List<Animal> currentList);
            if (currentList != null && !animalNames.Contains(item.animal.cientificName))
            {
                currentList.Add(item.animal);
                allAnimals[item.animal.animalOrder] = currentList;
                animalNames.Add(item.animal.cientificName);
            }
        }

    }
    public static List<Animal> GetAllAnimals()
    {
        List<Animal> returnList = new List<Animal>();

        foreach (KeyValuePair<Animal.Order, List<Animal>> animalList in instance.allAnimals)
        {
            returnList.AddRange(animalList.Value);
        }

        return returnList;
    }
    public static List<Animal> GetAnimalsBySpecie(Animal.Order pSpecie)
    {

        if (instance != null)
        {
            switch (pSpecie)
            {
                case Animal.Order.Others:
                    List<Animal> otherList2 = new List<Animal>();
                    foreach (var otherSpecie in new Animal.Order[] { Animal.Order.Hymenoptera1, Animal.Order.Hymenoptera2, Animal.Order.Diptera })
                    {
                        if (instance.allAnimals.TryGetValue(otherSpecie, out List<Animal> returnList1))
                        {
                            otherList2.AddRange(returnList1);
                        }
                    }
                    return otherList2;
                default:
                    if (instance.allAnimals.TryGetValue(pSpecie, out List<Animal> returnList2))
                    {
                        return returnList2;
                    }
                    break;
            }
        }
        return new List<Animal>();
    }

    public void AddPicture()
    {
        pictures++;
        Debug.Log("Nueva " + pictures);
        if(pictures >= total)
        {
            FinishGame();
        }
    }

    public void FinishGame()
    {
        menuUI.gameObject.SetActive(true);
        menuUI.FinishGame(pictures, total);
    }
}
