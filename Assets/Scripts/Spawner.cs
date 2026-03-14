using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
   public struct SpawnableObject
    {
         public GameObject ObstaclePrefab;
         [Range(0f, 1f)]
         public float spawnChance;
    }

    public SpawnableObject[] objects;   

    public float minSpawnrate = 1f;
    public float maxSpawnrate = 2f; 

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnrate, maxSpawnrate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach ( var obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.ObstaclePrefab);
                obstacle.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnrate, maxSpawnrate));
    }
}
