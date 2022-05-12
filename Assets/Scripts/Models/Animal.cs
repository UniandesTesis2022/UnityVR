using System;
using UnityEngine;


[System.Serializable]
public class Animal : IComparable
{
    public enum Order
    {
        Araneae, Coleoptera, Diptera
    }

    public string cientificName;
    public string description;

    public Order animalOrder;
    //public Sprite mapLocation;
    public Sprite image;

    public Animal(Order pOrder, string pCientificName){
        animalOrder = pOrder;
        cientificName = pCientificName;
    }

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        Animal otherAnimal = obj as Animal;
        if (otherAnimal != null)
            return this.cientificName.CompareTo(otherAnimal.cientificName);
        else
           throw new ArgumentException("Object is not an Animal");
    }

    public static string GetOrderCommonName(Order pOrder)
    {
        switch (pOrder)
        {
            case Order.Araneae:
                return "Araña";
            case Order.Coleoptera:
                return "Escarabajos";
            default:
                return "None";
        }
    }
}
