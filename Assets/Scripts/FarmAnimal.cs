using UnityEngine;

public abstract class FarmAnimal : MonoBehaviour
{
    public string Name { get; protected set; }
    public int Hunger { get; private set; }
    public int Happiness { get; private set; }


    public virtual void Initialize(string name, int hunger = 25, int happiness = 25)
    {
        Name = name;
        Hunger = Mathf.Clamp(hunger, 0, 50);
        Happiness = Mathf.Clamp(happiness, 0, 50);
    }

    public abstract void MakeSound();

    public virtual void AdjustHunger(int amount)
    {
        int newVal = Mathf.Clamp(Hunger + amount, 0, 50);

        int diff = newVal - Hunger;
        string diffString = diff > 0 ? $"<color=red>+{diff}</color>" : $"<color=green>{diff}</color>";

        Hunger = newVal;

        Debug.LogFormat($"{Name} the {GetType().Name}'s hunger is now {Hunger}({diffString})!");
    }

    public virtual void AdjustHappiness(int amount)
    {
        int newVal = Mathf.Clamp(Happiness + amount, 0, 50);

        int diff = newVal - Happiness;
        string diffString = diff > 0 ? $"<color=green>+{diff}</color>" : $"<color=red>{diff}</color>";

        Happiness = newVal;

        Debug.LogFormat($"{Name} the {GetType().Name}'s happiness is now {Happiness}({diffString})!");
    }

    public virtual void Feed(int amount)
    {
        Debug.Log($"{Name} the {GetType().Name} is eating {amount} units of food.");
        AdjustHunger(-amount);
        AdjustHappiness(2 * amount);
    }

    public virtual void Feed(string food, int amount)
    {
        Debug.Log($"{Name} the {GetType().Name} is eating {amount} {food}.");
        AdjustHunger(-amount);
        AdjustHappiness(2 * amount);
    }

    public virtual void GetStatus()
    {
        Debug.Log($"{Name} the {GetType().Name} - Hunger: {Hunger} | Happiness: {Happiness}");
    }
}
