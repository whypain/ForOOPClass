using UnityEngine;

public class Hero : MonoBehaviour 
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Gold { get; private set; }
    public int AttackPower { get; private set; }

    public void Initialize(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    public void ShowStat()
    {
        Debug.Log($"{Name} -> {Health} HP | {Gold} Gold");
    }
}
