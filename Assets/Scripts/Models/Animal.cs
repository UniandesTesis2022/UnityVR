using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Animal : IComparable
{
    public string name;

    public enum species{
        SPHERE, SQUARE, BIRD, BUTTERFLY
    }

    public species specie;

    public Animal(species pSpecie, string pName){
        specie = pSpecie;
        name = pName;
    }

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        Animal otherAnimal = obj as Animal;
        if (otherAnimal != null)
            return this.name.CompareTo(otherAnimal.name);
        else
           throw new ArgumentException("Object is not an Animal");
    }
}
