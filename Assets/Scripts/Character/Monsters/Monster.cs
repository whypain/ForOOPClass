using UnityEngine;

public abstract class Monster : Character
{
    public abstract int LootReward { get; }


    public abstract void InitializeMonster(string name);
    public abstract void Roar();


    public override void ShowStat()
    {
        Debug.Log($"{Name} -> {Health} HP | {AttackPower} AttackPower | {LootReward} LootReward");
    }



    public override void OnDefeated()
    {
        Debug.Log($"<color=orange>{Name} has been defeated and thus dropped {LootReward} golds</color>");
    }

    public int DropReward()
    {
        return LootReward;
    }
}
