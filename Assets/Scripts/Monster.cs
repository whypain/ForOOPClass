using UnityEngine;

public class Monster : MonoBehaviour
{
    private new string name;
    public string Name 
    { 
        get { return name; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                name = "Unknown Monster";
                return;
            }
            name = value;
        }
    }

    private int health;
    public int Health 
    { 
        get { return health; }
        private set
        {
            if (health < 0)
            {
                health = 0;
                return;
            }
            else if (health > 100)
            {
                health = 100;
                return;
            }

            health = value;
        }
    }

    public int AttackPower;
    public int LootReward;

    public void Initialize(string name, int health, int attackPower, int lootReward)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        LootReward = lootReward;
    }

    public void ShowStat()
    {
        Debug.Log($"{Name} -> {Health} HP | {AttackPower} AttackPower | {LootReward} LootReward");
    }
}