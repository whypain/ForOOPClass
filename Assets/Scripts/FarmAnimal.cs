using System.Linq;
using UnityEngine;

public abstract class FarmAnimal : MonoBehaviour
{
    public string Name { get; private set; }
    public int Hunger { get; private set; }
    public int Happiness { get; private set; }
    public FoodType PreferedFood { get; protected set; }

    protected int minHunger;
    protected int maxHunger = 100;
    protected int minHappiness;
    protected int maxHappiness = 100;


    private FoodType[] badFood = new FoodType[] {
        FoodType.RottenFood,
    };


    public abstract void MakeSound();
    public abstract string Produce();


    public virtual void Initialize(string name)
    {
        Name = name;
        Hunger = maxHunger / 2;
        Happiness = maxHappiness / 2;
    }


    public virtual void AdjustHunger(int amount)
    {
        int newVal = Mathf.Clamp(Hunger + amount, minHunger, maxHunger);

        int diff = newVal - Hunger;
        string diffString = diff > 0 ? $"<color=red>+{diff}</color>" : $"<color=green>{diff}</color>";

        Hunger = newVal;

        Debug.LogFormat($"{Name} the {GetType().Name}'s hunger is now {Hunger}({diffString})!");
    }

    public virtual void AdjustHappiness(int amount)
    {
        int newVal = Mathf.Clamp(Happiness + amount, minHappiness, maxHappiness);

        int diff = newVal - Happiness;
        string diffString = diff > 0 ? $"<color=green>+{diff}</color>" : $"<color=red>{diff}</color>";

        Happiness = newVal;

        Debug.LogFormat($"{Name} the {GetType().Name}'s happiness is now {Happiness}({diffString})!");
    }

    public virtual void Feed(int amount)
    {
        Feed(FoodType.NotSpecified, amount);
    }

    public virtual void Feed(FoodType food, int amount)
    {
        if (Hunger <= minHunger)
        {
            Debug.Log($"{Name} is too full to eat!");
            return;
        }


        if (food == FoodType.NotSpecified)
        {
            Debug.Log($"{Name} the {GetType().Name} is eating...");

            AdjustHunger(-amount);
            AdjustHappiness(amount);
            return;
        }
        else if (IsBad(food))
        {
            Debug.Log($"{Name} the {GetType().Name} is eating {amount} {food}. It's not very good for them..");

            AdjustHappiness(-20);
            return;
        }
        else if (food == PreferedFood)
        {
            Debug.Log($"{Name} the {GetType().Name} is eating {amount} {food}.");
            Debug.Log($"{Name} the {GetType().Name} gained 15 Happiness because they like {food}");

            AdjustHunger(-amount);
            AdjustHappiness(15);
            return;
        }
        else
        {
            Debug.Log($"{Name} the {GetType().Name} is eating {amount} {food}.");
            AdjustHunger(-amount);
        }

    }

    public virtual void GetStatus()
    {
        Debug.Log($"{Name} the {GetType().Name} - Hunger: {Hunger} | Happiness: {Happiness}");
    }


    private bool IsBad(FoodType food) => badFood.Contains(food);

}

public enum FoodType
{
    NotSpecified,
    Hay,
    Grain,
    Meat,
    RottenFood,
    AnimalFood
}
