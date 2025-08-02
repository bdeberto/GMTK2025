using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public TokenTarget targetPrefab = default;
    public Transform[] Targets = default;

    int currentTarget = 1;
    GameplayManager gameManager = default;
    List<TokenTarget> spawnedTargets = new List<TokenTarget>();

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

    public void SpawnNextTargetSet()
    {
        for (int i = 1; i < Targets.Length; ++i)
        { 
            Transform t = Targets[i];
            TokenTarget l = Instantiate(targetPrefab);
            l.transform.position = t.position;
            l.Activate(gameManager);
            if (currentTarget == Targets.Length)
            {
                currentTarget = 1;
            }
            spawnedTargets.Add(l);
        }
    }

    public void WipeTargets()
    {
		foreach (TokenTarget t in spawnedTargets)
		{
			t.ResetTargets();
		}
	}

    public void ClearTargets()
    {
		foreach (TokenTarget t in spawnedTargets)
		{
            Destroy(t.gameObject);
		}
        spawnedTargets.Clear();
	}
}
