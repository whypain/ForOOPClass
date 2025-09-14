using UnityEngine;

public abstract class FarmAnimal 
{
    public string Name { get; protected set; }
    public int Hunger { get; protected set; }
    public int Happiness { get; protected set; }

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

    public virtual void Feed(string food)
    {
        Debug.Log($"{Name} the {GetType().Name} is eating {food}.");
        AdjustHunger(-10);
        AdjustHappiness(5);
    }

    public virtual void GetStatus()
    {
        Debug.Log($"{Name} the {GetType().Name} - Hunger: {Hunger} | Happiness: {Happiness}");
    }
}
