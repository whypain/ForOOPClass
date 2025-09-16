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
        hero.Initialize("Johnson", 20, 10);
        hero.ShowStat();

        Spawner spawnArea = new Spawner(new Dimension(25, 1, 25), Vector3.zero);
        monsters = spawnArea.SpawnAll(monsterPrefabs);
        monsters[0].Initialize("Orc", 200, 10, 100);
        monsters[1].Initialize("Goblin", 200, 10, 100);
        monsters[2].Initialize("Dragon", 200, 10, 100);
        monsters[3].Initialize("Gigi", 200, 10, 100);

        foreach (Monster monster in monsters)
        {
            monster.ShowStat();
        }
    }
}
