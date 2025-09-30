using UnityEngine;

public class Hero : Character 
{
    public int Gold { get; private set; }

    public void Initialize(string name, int health, int attackPower)
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
        int oldGold = Gold;
        Gold += gold;
        Gold = Mathf.Clamp(Gold, 0, 999);

        Debug.Log($"<color=yellow><b>{Name} Earned {Gold - oldGold} gold!</color><b>");
    }

    public override void Attack(Character target)
    {
        if (IsDead) return;
        Debug.Log($"<color=cyan>{Name} uses Iron Tail! It was super effective with {AttackPower} attack power!</color>");
    }

    public override void Attack(Character target, int bonusDamage)
    {
        if (IsDead) return;
        Debug.Log($"<color=cyan>{Name} wield the power of friendship and attack {target.Name} with {bonusDamage} increased damage!</color>");
        target.TakeDamage(AttackPower + bonusDamage);
    }

    public override void OnDefeated()
    {
        Debug.Log($"<color=red>Game Over! {Name} is dead.</color>");
    }

    public void Heal(int healAmount)
    {
        Health += healAmount;
        Health = Mathf.Clamp(Health, 0, maxHealth);
        Debug.Log($"{Name} healed {healAmount} HP!");
    }
}
