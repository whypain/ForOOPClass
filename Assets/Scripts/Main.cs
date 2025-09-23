using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] Hero hero;
    [SerializeField] List<Monster> monsterPrefabs;

    private List<Monster> monsters;

    private void Start()
    {
        monsters = new List<Monster>();

        hero.ShowStat();
        hero.Initialize("Johnson", 200, 10);
        hero.ShowStat();

        Vector3 spawnOrigin = hero.transform.position + new Vector3(0, 0, 7);
        Spawner spawnArea = new Spawner(spawnOrigin, new Sphere(spawnOrigin, 5));

        monsters = spawnArea.SpawnAll(monsterPrefabs);
        monsters[0].Initialize("Orc", 200, 10, 100);
        monsters[1].Initialize("Goblin", 200, 10, 100);
        monsters[2].Initialize("Dragon", 200, 10, 100);
        monsters[3].Initialize("Gigi", 10, 10, 100);

        foreach (Monster monster in monsters)
        {
            monster.ShowStat();
        }

        Monster currMonster = monsters[3];
        currMonster.Attack(hero);
        hero.Attack(currMonster);
        currMonster.ShowStat();

        if (currMonster.IsDead)
        {
            hero.EarnGold(currMonster.DropReward());
        }

        hero.ShowStat();
        hero.Heal(10);
        hero.ShowStat();
    }
}
