using UnityEngine;

public class Dragon : Monster
{
    public override int LootReward { get => 20; }

    public override void InitializeMonster(string name)
    {
        Initialize(name, 100, 40);
    }

    public override void Roar()
    {
        Debug.Log("Uwahhhh");
    }

    public override void Attack(Character target)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=cyan>{Name} uses Hydro Pump at {target.Name} with {AttackPower} attack power</color>");
        target.TakeDamage(AttackPower);
    }

    public override void Attack(Character target, int bonusDamage)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=cyan>With powerful vengeance {Name} attacks {target.Name} with {bonusDamage} increased damage!</color>");
        target.TakeDamage(AttackPower + bonusDamage);
    }
}
