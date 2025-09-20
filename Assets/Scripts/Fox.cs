using UnityEngine;

public class Fox : FarmAnimal
{
    public override void GetStatus()
    {
        Debug.Log($"{Name} the {GetType().Name} - Hunger: {Hunger} | Happiness: {Happiness}");
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
}   