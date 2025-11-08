using UnityEngine;
using UnityEngine.AI; // Required for NavMesh functionality

public class AISpawner : MonoBehaviour
{
    public int AICount = 3;
    public GameObject AIObject;

    [Header("Spawn Area")]
    public Vector3 spawnAreaMin = new Vector3(-15.15f, 0, -15.15f);
    public Vector3 spawnAreaMax = new Vector3(15.15f, 0, 15.15f);

    [Header("Safety Checks")]
    public int maxSpawnAttempts = 20; 
    public float overlapCheckSize = 1.0f;
    public LayerMask obstacleMask;

    void Start()
    {
        if (AIObject == null)
        {
            Debug.LogError("AIObject not assigned in the Inspector on " + gameObject.name);
            return;
        }

        for (int i = 0; i < AICount; i++)
        {
            Vector3 spawnPos;

            if (TryGetRandomNavMeshPosition(out spawnPos))
            {
                var ai = Instantiate(AIObject, spawnPos, Quaternion.identity);

                // 👇 Assign tag automatically
                ai.tag = "Zombie";

                Vector3 lookTarget = Vector3.zero;
                lookTarget.y = ai.transform.position.y;
                ai.transform.LookAt(lookTarget);

                Debug.Log($"Successfully spawned AI #{i + 1} at {spawnPos}");
            }
            else
            {
                Debug.LogWarning($"Failed to find a valid spawn position for AI #{i + 1} after {maxSpawnAttempts} attempts.");
            }
        }
    }

    bool TryGetRandomNavMeshPosition(out Vector3 resultPosition)
    {
        for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
        {
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
            Vector3 randomPoint = new Vector3(randomX, 5f, randomZ);

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
            {
                Vector3 navMeshPos = hit.position;

                Collider[] colliders = Physics.OverlapBox(
                    navMeshPos,
                    new Vector3(overlapCheckSize, 0.5f, overlapCheckSize),
                    Quaternion.identity,
                    obstacleMask
                );

                if (colliders.Length == 0)
                {
                    resultPosition = navMeshPos;
                    return true;
                }
            }
        }

        resultPosition = Vector3.zero;
        return false;
    }
}
