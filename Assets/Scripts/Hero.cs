using UnityEngine;

public class Hero : Character 
{
    private int gold;
    public int Gold 
    { 
        get { return gold; } 
        private set
        {
            gold = Mathf.Clamp(value, 0, 999);
        }
    }

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
    }
}
