using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Animal
{
    public string name;

    public species specie;
}

public enum species{
    SPHERE, SQUARE
}
