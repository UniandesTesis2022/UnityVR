using System;
using UnityEngine;


[System.Serializable]
public class Animal : IComparable
{
    public enum species
    {
        AVE, MARIPOSA
    }

    public string commonName;
    public string cientificName;
    public string description;

    public species specie;
    public Sprite mapLocation;
    public Sprite image;

    public Animal(species pSpecie, string pCientificName, string pCommonName){
        specie = pSpecie;
        cientificName = pCientificName;
        commonName = pCommonName;
    }

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        Animal otherAnimal = obj as Animal;
        if (otherAnimal != null)
            return this.cientificName.CompareTo(otherAnimal.cientificName);
        else
           throw new ArgumentException("Object is not an Animal");
    }
}
