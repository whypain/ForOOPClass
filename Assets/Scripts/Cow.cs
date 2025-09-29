using UnityEngine;

public class Cow : FarmAnimal
{
    public float Milk { get; private set; }

    public override void Initialize(string name)
    {
        base.Initialize(name);
        Milk = 0f;

        PreferedFood = FoodType.Hay;
    }

    public void Moo()
    {
        Debug.Log($"{Name} the {GetType().Name} is mooing loudly!");
        AdjustHappiness(10);
    }

    public override void GetStatus()
    {
        Debug.Log($"{Name} the {GetType().Name} - Hunger: {Hunger} | Happiness: {Happiness} | Milk: {Milk}");
    }

    public override void MakeSound()
    {
        Debug.Log($"{Name} the {GetType().Name} says: Moo!");
    }

    public override string Produce()
    {
        if (Happiness <= 70)
        {
            Debug.Log($"{Name} the {GetType().Name} is not feeling well enough to produce milk.");
            return $"Total Milk: {Milk} Units";
        }

        Milk += Happiness/10;
        Debug.Log($"{Name} the {GetType().Name} just produced {Happiness/10} milk!");

        return $"Total Milk: {Milk} Units";
    }
}
