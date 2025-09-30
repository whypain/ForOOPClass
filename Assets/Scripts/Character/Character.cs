using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private new string name;
    public string Name 
    { 
        get { return name; }
        protected set
        {
            if (string.IsNullOrEmpty(value))
            {
                name = "Unknown";
                return;
            }
            name = value;
        }
    }

    public int Health { get; protected set; }
    public int AttackPower { get; protected set; }
    public Weapon EquippedWeapon { get; private set; }

    public virtual bool IsDead { get => Health <= 0; }


    protected int maxHealth;


    public abstract void ShowStat();

    public void Initialize(string name, int health, int attackPower)
    {
        Name = name;
        maxHealth = health;
        Health = maxHealth;
        AttackPower = attackPower;
    }

    public abstract void OnDefeated();
    public abstract void Attack(Character target);
    public abstract void Attack(Character target, int bonusDamage);


    public virtual void Attack(Character target, Weapon weapon)
    {
        if (IsDead) return;
        if (weapon == null) throw new System.ArgumentNullException("weapon can't be null");

        Debug.LogFormat($"<color=magenta>{Name} equipped the {weapon.name} and attacks {target.Name} with {weapon.BonusDamage} increased damage!</color>");
        target.TakeDamage(AttackPower + weapon.BonusDamage);

    }

    public virtual void TakeDamage(int damage)
    {
        int oldHealth = Health;
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, maxHealth);

        Debug.Log($"{Name} lose {oldHealth - Health} HP!");

        if (IsDead) OnDefeated();
    }

    public void EquipWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon;
    }
}
