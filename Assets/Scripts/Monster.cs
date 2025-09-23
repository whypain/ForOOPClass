using UnityEngine;

public enum MonsterType
{
    Dragon,
    Goblin,
    Orc,
    Gigi
}

public class Monster : Character
{
    public MonsterType Type;

    private int lootReward;
    public int LootReward
    {
        get { return lootReward; }
        set { lootReward = Mathf.Max(0, value); }
    }

    public override void ShowStat()
    {
        Debug.Log($"{Name} -> {Health} HP | {AttackPower} AttackPower | {LootReward} LootReward");
    }

    public override void Attack(Character target)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=orange>{Name} uses Hydro Pump! It was not very effective with {AttackPower} attack power</color>");
        target.TakeDamage(AttackPower);
    }

    public override void Attack(Character target, int bonusDamage)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=orange>With powerful vengeance {Name} attacks {target.Name} with {bonusDamage} increased damage!</color>");
        target.TakeDamage(AttackPower + bonusDamage);
    }

    public override void OnDefeated()
    {
        Debug.Log($"<color=orange>{Name} has been defeated and thus dropped {lootReward} golds</color>");
    }

    public int DropReward()
    {
        return lootReward;
    }


    public void InitializeByMonsterType(MonsterType type)
    {
        switch (type)
        {
            case MonsterType.Dragon:
                Initialize("Dragon", 200, 10);
                lootReward = 100;
                break; 
            case MonsterType.Goblin:
                Initialize("Goblin", 15, 10);
                lootReward = 2;
                break;
            case MonsterType.Orc:
                Initialize("Orc", 30, 10);
                lootReward = 5;
                break;
            case MonsterType.Gigi:
                Initialize("Gigi", 50, 10);
                lootReward = 50;
                break;
        }

        Type = type;
    }
}