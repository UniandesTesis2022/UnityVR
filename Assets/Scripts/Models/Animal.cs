using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Animal
{
    public string name;

    public enum species{
        SPHERE, SQUARE
    }

    public species specie;
}
