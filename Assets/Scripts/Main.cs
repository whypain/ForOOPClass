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

        SpawnArea spawnArea = new SpawnArea(new Dimension(5, 5, 5), Vector3.zero);
        monsters = spawnArea.SpawnAll(monsterPrefabs);
        monsters[0].Initialize("Orc", 200, 10, 100);
        monsters[1].Initialize("Goblin", 200, 10, 100);
        monsters[2].Initialize("Dragon", 200, 10, 100);
        monsters[3].Initialize("Gigi", 200, 10, 100);

        foreach (Monster monster in monsters)
        {
            monster.ShowStat();
        }

        //currentMonster = Instantiate(monsterPrefabs[0]);
        //currentMonster.Initialize("Orc", 200, 10, 100);
        //monsters.Add(currentMonster);

        //currentMonster = Instantiate(monsterPrefabs[1]);
        //currentMonster.Initialize("Goblin", 200, 10, 100);
        //monsters.Add(currentMonster);

        //currentMonster = Instantiate(monsterPrefabs[2]);
        //currentMonster.Initialize("Dragon", 200, 10, 100);
        //monsters.Add(currentMonster);

        //currentMonster = Instantiate(monsterPrefabs[3]);
        //currentMonster.Initialize("Gigi", 200, 10, 100);

        //monsters.Add(currentMonster);

    }
}



public class SpawnArea
{
    public Dimension SpawnDimension;
    public Vector3 Origin;

    public SpawnArea(Dimension spawnDimension, Vector3 origin)
    {
        SpawnDimension = spawnDimension;
        Origin = origin;
    }

    public T SpawnRandomly<T>(T thingToSpawn, Transform parent = null) where T : MonoBehaviour
    {
        float w = Random.Range(-SpawnDimension.Width / 2, SpawnDimension.Width / 2);
        float h = Random.Range(-SpawnDimension.Height / 2, SpawnDimension.Height / 2);
        float l = Random.Range(-SpawnDimension.Length / 2, SpawnDimension.Length / 2);

        if (parent != null)
        {
            T spawned = GameObject.Instantiate(thingToSpawn, parent);
            spawned.transform.position = new Vector3(l, h, w);

            return spawned;
        }
        else
        {
            T spawned = GameObject.Instantiate(thingToSpawn, Origin, Quaternion.identity);
            spawned.transform.position += new Vector3(l, h, w);

            return spawned;
        }
    }

    public List<T> SpawnAll<T>(List<T> thingsToSpawn, Transform parent = null, bool randomizePosition = true) where T : MonoBehaviour
    {
        List<T> spawned = new List<T>();
        foreach(T thing in thingsToSpawn)
        {
            if (randomizePosition)
            {
                T spawnedThing = SpawnRandomly(thing, parent);
                spawned.Add(spawnedThing);
            }
            else
            {
                T spawnedThing = GameObject.Instantiate(thing, Origin, Quaternion.identity);
                spawned.Add(spawnedThing);
            }
        }

        return spawned;
    }
}

public struct Dimension
{
    public float Width;
    public float Height;
    public float Length;

    public Dimension(float width, float height, float length)
    {
        Width = width;
        Height = height;
        Length = length;
    }
}
