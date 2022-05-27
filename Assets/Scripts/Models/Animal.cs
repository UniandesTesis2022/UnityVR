using System;
using UnityEngine;


[System.Serializable]
public class Animal : IComparable
{
    public enum Order
    {
        Araneae, Coleoptera, Hymenoptera1, Hymenoptera2, Odonata, Lepidoptera, Diptera, Others, Hymenoptera, 
        Odonata1, Odonata2
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
                return "Escarabajo";
            case Order.Diptera:
                return "Mosca";
            case Order.Hymenoptera1:
                return "Avispa";
            case Order.Hymenoptera2:
                return "Hormiga";
            case Order.Odonata:
                return "Odonata";
            case Order.Odonata1:
                return "Libelula";
            case Order.Odonata2:
                return "Zigóptero";
            case Order.Lepidoptera:
                return "Mariposa";
            default:
                return "Otros";
        }
    }

    public static string GetOrderName(Order pOrder)
    {
        switch (pOrder)
        {
            case Order.Odonata1:
            case Order.Odonata2:
                return "Odonata";
            case Order.Hymenoptera1:
            case Order.Hymenoptera2:
                return "Hymenoptera";
            default:
                return pOrder.ToString();
        }
    }
}
