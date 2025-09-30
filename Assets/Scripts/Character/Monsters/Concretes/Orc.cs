using UnityEngine;

public class Orc : Monster
{
    public override int LootReward { get => 7; }

    public override void InitializeMonster(string name)
    {
        Initialize(name, 50, 25);
    }

    public override void Roar()
    {
        Debug.Log("Rraahh");
    }

    public override void Attack(Character target)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=grey>{Name} bonk {target.Name} with {AttackPower} attack power</color>");
        target.TakeDamage(AttackPower);
    }

    public override void Attack(Character target, int bonusDamage)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=orange>With powerful vengeance {Name} attacks {target.Name} with {bonusDamage} increased damage!</color>");
        target.TakeDamage(AttackPower + bonusDamage);
    }
}
