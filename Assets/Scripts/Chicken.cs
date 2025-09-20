using UnityEngine;

public class Chicken : FarmAnimal
{
    public int Eggs { get; private set; }

    public override void Initialize(string name, int hunger, int happiness)
    {
        base.Initialize(name, hunger, happiness);
        Eggs = 0;
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
