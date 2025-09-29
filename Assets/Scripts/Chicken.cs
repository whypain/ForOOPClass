using UnityEngine;

public class Chicken : FarmAnimal
{
    public int Eggs { get; private set; }

    public override void Initialize(string name)
    {
        base.Initialize(name);
        Eggs = 0;

        PreferedFood = FoodType.Grain;
    }

    public override void GetStatus()
    {
        Debug.Log($"{Name} the {GetType().Name} - Hunger: {Hunger} | Happiness: {Happiness} | Eggs: {Eggs}");
    }

    public override void MakeSound()
    {
        Debug.Log($"{Name} the {GetType().Name} says: Cluck!");
    }

    public override string Produce()
    {
        if (Happiness <= 50)
        {
            Debug.Log($"{Name} the {GetType().Name} is not feeling well enough to produce eggs :(");
        }
        else if (Happiness > 50 && Happiness < 80)
        {
            Debug.Log($"{Name} the {GetType().Name} just laid 2 Eggs!");
            Eggs += 2;
        }
        else if (Happiness > 80)
        {
            Debug.Log($"{Name} the {GetType().Name} just laid 3 Eggs!");
            Eggs += 3;
        }

        return $"Total Eggs: {Eggs} Units";
    }

    public void Sleep()
    {
        Debug.Log($"{Name} the {GetType().Name} is sleeping.");
        AdjustHunger(5);
        AdjustHappiness(10);
    }
}
