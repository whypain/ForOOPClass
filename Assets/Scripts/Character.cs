using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

    public virtual bool IsDead { get => Health <= 0; }


    protected int maxHealth;


    public abstract void ShowStat();

    public virtual void Initialize(string name, int health, int attackPower)
    {
        Name = name;
        maxHealth = health;
        Health = maxHealth;
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
        Health = Mathf.Clamp(Health, 0, maxHealth);
    }
}
