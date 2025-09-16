using UnityEngine;

public class Monster : Character
{
    private int lootReward;
    public int LootReward
    {
        get { return lootReward; }
        set { lootReward = Mathf.Max(0, value); }
    }

    public void Initialize(string name, int health, int attackPower, int lootReward)
    {
        base.Initialize(name, health, attackPower);
        LootReward = lootReward;
    }

    public override void ShowStat()
    {
        Debug.Log($"{Name} -> {Health} HP | {AttackPower} AttackPower | {LootReward} LootReward");
    }

    public int DropReward()
    {
        return lootReward;
    }
}