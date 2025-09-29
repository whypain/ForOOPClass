using UnityEngine;

public class Fox : FarmAnimal
{
    public int Fur { get; private set; }

    public override void Initialize(string name)
    {
        base.Initialize(name);
        Fur = 0;

        PreferedFood = FoodType.Meat;
    }

    public override void GetStatus()
    {
        Debug.Log($"{Name} the {GetType().Name} - Hunger: {Hunger} | Happiness: {Happiness} | Fur: {Fur}");
    }

    public override void MakeSound()
    {
        Debug.Log($"What does {Name} the {GetType().Name} say: Ding ding ding ding ding ding ding ding ding!");
    }

    public void Hunt(Chicken chicken)
    {
        if (chicken != null)
        {
            Debug.Log($"{Name} the {GetType().Name} is chasing {chicken.Name} the Chicken!");
            AdjustHappiness(5);
            chicken.AdjustHappiness(-10);
            chicken.AdjustHunger(15);
        }
        else
        {
            Debug.Log($"{Name} the {GetType().Name} found no chickens to hunt.");
            AdjustHappiness(-5);
        }
    }

    public override string Produce()
    {
        if (Happiness <= 50)
        {
            Debug.Log($"{Name} the {GetType().Name} is not feeling well enough to produce fur :(");
        }
        else if (Happiness > 50 && Happiness < 80)
        {
            Debug.Log($"{Name} the {GetType().Name} just shed 1 Fur!");
            Fur += 1;
        }
        else if (Happiness > 80)
        {
            Debug.Log($"{Name} the {GetType().Name} just shed 2 Fur!");
            Fur += 2;
        }

        return $"Total Fur: {Fur} Units";
    }
}   