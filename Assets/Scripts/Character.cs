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

    private int health;
    public int Health 
    { 
        get { return health; }
        protected set
        {
            health = Mathf.Clamp(value, 0, 100);
        }
    }

    public int AttackPower { get; protected set; }

    public virtual bool IsDead { get => Health <= 0; }

    public abstract void ShowStat();

    public virtual void Initialize(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    public void Attack(Character target)
    {
        Debug.Log($"{Name} attacks {target.Name}. {target.Name} lose {AttackPower} HP!");
        target.TakeDamage(AttackPower);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Mathf.Clamp(Health, 0, 100);
    }

}
