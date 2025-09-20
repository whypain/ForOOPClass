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
        Michael.Initialize("Michael", 30, 20);
        animals.Add(Michael);

        Henry.Initialize("Henry", 15, 35);
        animals.Add(Henry);

        Fiona.Initialize("Fiona", 40, 10);
        animals.Add(Fiona);

        foreach (FarmAnimal animal in animals)
        {
            animal.GetStatus();
            animal.MakeSound();

            switch (animal)
            {
                case Cow cow:
                    cow.Moo();
                    cow.Feed(5);
                    break;
                case Chicken chicken:
                    chicken.Sleep();
                    chicken.Feed("corns", 3);
                    break;
                case Fox fox:
                    fox.Hunt(Henry);
                    break;
            }
        }
    }
}
