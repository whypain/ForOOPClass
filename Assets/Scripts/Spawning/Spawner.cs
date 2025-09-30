using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    public Vector3 Origin;
    public Area SpawnArea;

    public Spawner(Vector3 origin, Area area)
    {
        Origin = origin;
        SpawnArea = area;
    }

    public T SpawnRandomly<T>(T thingToSpawn, Transform parent = null) where T : MonoBehaviour
    {
        if (parent != null)
        {
            T spawned = GameObject.Instantiate(thingToSpawn, parent);
            spawned.transform.position = SpawnArea.GetRandomPointInside();

            return spawned;
        }
        else
        {
            T spawned = GameObject.Instantiate(thingToSpawn, Origin, Quaternion.identity);
            spawned.transform.position += SpawnArea.GetRandomPointInside();

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
