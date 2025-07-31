using System.Collections;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public LevelTrackController LevelTrack = default;
    public LimbController Limbs = default;
    public TargetSpawner TargetSpawn = default;
    public GameUIController UIControl = default;

    int targetsHit = 0;
    int targetsRequired = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LevelTrack.Activate(this);
        Limbs.Activate(this);
        TargetSpawn.Activate(this);
        UIControl.SetCounter(targetsHit, targetsRequired);
        StartCoroutine(DoPlayGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DoPlayGame()
    {
        LevelTrack.BeginLevel();
        yield return null;
    }

    public void ReportHit(float distance)
    {
		UIControl.SetCounter(targetsHit++, targetsRequired);
        LevelTrack.OKToContinue = targetsHit >= targetsRequired;
	}

    public void ReportLimbCollision()
    {
        Limbs.StunCurrentLimb();
    }

    public void SpawnTargets()
    {
        TargetSpawn.SpawnNextTarget();
    }
}
