using UnityEngine;

public class Chicken : FarmAnimal
{
    public int Eggs { get; private set; }

    public Chicken(string name, int hunger, int happiness)
    {
        Name = name;
        Eggs = 1;
        AdjustHunger(hunger);
        AdjustHappiness(happiness);
    }

    public override void GetStatus()
    {
        Debug.Log($"{Name} the {GetType().Name} - Hunger: {Hunger} | Happiness: {Happiness} | Eggs: {Eggs}");
    }

    public override void MakeSound()
    {
        Debug.Log($"{Name} the {GetType().Name} says: Cluck!");
    }

    public void Sleep()
    {
        Debug.Log($"{Name} the {GetType().Name} is sleeping.");
        AdjustHunger(5);
        AdjustHappiness(10);
    }
}
