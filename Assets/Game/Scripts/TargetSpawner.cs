using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public LimbTarget targetPrefab = default;
    public Transform[] Targets = default;

    int currentTarget = 1;
    GameplayManager gameManager = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(GameplayManager manager)
    {
        gameManager = manager;
    }

    public void SpawnNextTarget()
    {
        if (!gameManager.LevelTrack.IsDone())
        {
            Transform t = Targets[currentTarget++];
            LimbTarget l = Instantiate(targetPrefab);
            l.transform.position = t.position;
            l.Activate(gameManager);
            if (currentTarget == Targets.Length)
            {
                currentTarget = 1;
            }
        }
    }
}
