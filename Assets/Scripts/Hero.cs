using UnityEngine;

public class Hero : Character 
{
    public int Gold { get; private set; }

    public override void Initialize(string name, int health, int attackPower)
    {
        base.Initialize(name, health, attackPower);
        Gold = 0;
    }

    public override void ShowStat()
    {
        Debug.Log($"{Name} -> {Health} HP | {Gold} Gold");
    }

    public void EarnGold(int gold)
    {
        Gold += gold;
        Gold = Mathf.Clamp(Gold, 0, 999);
    }

    public void Heal(int healAmount)
    {
        Health += healAmount;
        Health = Mathf.Clamp(Health, 0, maxHealth);
        Debug.Log($"{Name} healed {healAmount} HP!");
    }
}
