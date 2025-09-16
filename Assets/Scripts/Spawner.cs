using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    public Dimension SpawnDimension;
    public Vector3 Origin;

    public Spawner(Dimension spawnDimension, Vector3 origin)
    {
        SpawnDimension = spawnDimension;
        Origin = origin;
    }

    public T SpawnRandomly<T>(T thingToSpawn, Transform parent = null) where T : MonoBehaviour
    {
        // Move this logic into the dimension class
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


// TODO: Make this a base class instead
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
