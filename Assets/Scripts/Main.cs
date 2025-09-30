using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] Hero hero;
    [SerializeField] List<Monster> monsterPrefabs;
    [SerializeField] List<Weapon> weaponPrefabs;

    [SerializeField] string[] names;

    private List<Monster> monsters;
    private List<Weapon> weapons;

    private void Start()
    {
        monsters = new List<Monster>();
        weapons = new List<Weapon>();

        hero.ShowStat();
        hero.Initialize("Johnson", 200, 20);
        hero.ShowStat();

        Vector3 spawnOrigin = hero.transform.position + new Vector3(0, 0, 7);
        Spawner spawnArea = new Spawner(spawnOrigin, new Sphere(spawnOrigin, 5));

        Weapon sword = Instantiate(weaponPrefabs[0], hero.transform);
        sword.transform.localPosition += new Vector3(0, 1, 0);
        weapons.Add(sword);

        foreach (Monster monster in monsterPrefabs)
        {
            Monster spawned = SpawnMonster(monster, spawnArea);
            string name = names[Random.Range(0, names.Length)];
            spawned.InitializeMonster($"{name} the {spawned.GetType().Name}");
            spawned.ShowStat();
            spawned.Roar();

            spawned.Attack(hero);
        }

        for (int i = 0; i < monsters.Count; i++)
        {
            Weapon spawned = Instantiate(weaponPrefabs[i], monsters[i].transform);
            spawned.transform.localPosition += new Vector3(0, 1, 0);
            weapons.Add(spawned);
        }

        weapons[0].Initialize("Sword", 10);
        hero.EquipWeapon(weapons[0]);

        weapons[1].Initialize("Mace", 5);
        monsters[0].EquipWeapon(weapons[1]);

        weapons[2].Initialize("Spear", 6);
        monsters[1].EquipWeapon(weapons[2]);

        weapons[3].Initialize("Claw", 15);
        monsters[2].EquipWeapon(weapons[3]);

        weapons[4].Initialize("Guitar", 40);
        monsters[3].EquipWeapon(weapons[4]);

        foreach (Monster monster in monsters)
        {
            monster.Attack(hero, monster.EquippedWeapon);
        }


        Monster currMonster = monsters[3];
        currMonster.Attack(hero);
        hero.ShowStat();
        hero.Attack(currMonster);
        currMonster.ShowStat();

        hero.Heal(10);
        hero.ShowStat();
        currMonster.Attack(hero, 20);
        hero.ShowStat();

        hero.Attack(currMonster, 20);
        currMonster.ShowStat();

        if (currMonster.IsDead)
        {
            hero.EarnGold(currMonster.DropReward());
        }
    }

    private Monster SpawnMonster(Monster monsterPrefab, Spawner spawner)
    {
        Monster monsterObj = spawner.SpawnRandomly(monsterPrefab);

        monsters.Add(monsterObj);

        return monsterObj;
    }
}
