using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string WeaponName {  get; private set; }
    public int BonusDamage { get; private set; }

    public void Initialize(string weaponName, int damage)
    {
        WeaponName = weaponName;
        BonusDamage = damage;
    }
}
