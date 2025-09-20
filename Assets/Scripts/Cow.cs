using UnityEngine;

public class Cow : FarmAnimal
{
    public float Milk { get; private set; }

    public override void Initialize(string name, int hunger, int happiness)
    {
        base.Initialize(name, hunger, happiness);
        Milk = 0f;
    }

    public override void GetStatus()
    {
        Debug.Log($"{Name} the {GetType().Name} - Hunger: {Hunger} | Happiness: {Happiness} | Milk: {Milk}L");
    }

    public override void MakeSound()
    {
        Debug.Log($"{Name} the {GetType().Name} says: Moo!");
    }

    public void Moo()
    {
        Debug.Log($"{Name} the {GetType().Name} is mooing loudly!");
        AdjustHappiness(10);
    }
}
