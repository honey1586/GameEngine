using DigitalRuby.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < 100; i++)
        {
            GameObject obj = SpawningPool.CreateFromCache("Zombie_0");
            if(obj == null)
            {
                Debug.LogErrorFormat("Unable to find object for key: {0}", "Zombie_0");
            }

            Vector3 pos = Random.onUnitSphere;
            obj.transform.position = pos * UnityEngine.Random.Range(-5.0f, 5.0f);
            obj.transform.rotation = Random.rotation;

            obj.transform.SetParent(transform);
        }
    }
}
