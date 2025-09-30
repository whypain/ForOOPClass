using UnityEngine;

public class Goblin : Monster
{
    public override int LootReward { get => 5; }

    public override void InitializeMonster(string name)
    {
        Initialize(name, 50, 20);
    }

    public override void Roar()
    {
        Debug.Log("Grrrr");
    }

    public override void Attack(Character target)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=green>{Name} hit {target.Name} with {AttackPower} attack power</color>");
        target.TakeDamage(AttackPower);
    }

    public override void Attack(Character target, int bonusDamage)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=orange>With powerful vengeance {Name} attacks {target.Name} with {bonusDamage} increased damage!</color>");
        target.TakeDamage(AttackPower + bonusDamage);
    }

    public override void Attack(Character target, Weapon weapon)
    {
        if (IsDead) return;

        Debug.LogFormat($"<color=orange>{Name} equipped the {weapon.name} and attacks {target.Name} with {weapon.BonusDamage} increased damage!</color>");
        target.TakeDamage(AttackPower + weapon.BonusDamage);
    }
}
