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
        hero.Initialize("Johnson", 200, 20);
        hero.ShowStat();

        Vector3 spawnOrigin = hero.transform.position + new Vector3(0, 0, 7);
        Spawner spawnArea = new Spawner(spawnOrigin, new Sphere(spawnOrigin, 5));

        SpawnMonster(MonsterType.Dragon, spawnArea);
        SpawnMonster(MonsterType.Orc, spawnArea);
        SpawnMonster(MonsterType.Goblin, spawnArea);
        SpawnMonster(MonsterType.Gigi, spawnArea);

        foreach (Monster monster in monsters)
        {
            monster.ShowStat();
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

    private void SpawnMonster(MonsterType monsterType, Spawner spawner)
    {
        Monster monsterPrefab = monsterPrefabs[(int)monsterType];
        Monster monsterObj = spawner.SpawnRandomly(monsterPrefab);
        monsterObj.InitializeByMonsterType(monsterType);

        monsters.Add(monsterObj);
    }
}
