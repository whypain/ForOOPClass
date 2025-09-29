using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Cow Michael;
    public Chicken Henry;
    public Fox Fiona;

    public List<FarmAnimal> animals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Welcome to the Farm!");
        animals = new List<FarmAnimal>();

        // Initialize every animals
        Michael.Initialize("Michael");
        animals.Add(Michael);

        Henry.Initialize("Henry");
        animals.Add(Henry);

        Fiona.Initialize("Fiona");
        animals.Add(Fiona);

        Debug.Log($"There are {animals.Count} animals in the farm");

        foreach (FarmAnimal animal in animals)
        {
            animal.GetStatus();
            animal.MakeSound();

            switch (animal)
            {
                case Cow cow:
                    cow.Feed(FoodType.RottenFood, 500);
                    break;
                case Chicken chicken:
                    chicken.Feed(FoodType.Grain, 1000);
                    break;
                case Fox fox:
                    fox.Hunt(Henry);
                    break;
            }
        }

        Debug.Log(Michael.Produce());
        Debug.Log(Henry.Produce());
        Debug.Log(Fiona.Produce());
        Debug.Log(Fiona.Produce());
    }
}
