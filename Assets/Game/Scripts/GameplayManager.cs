using DG.Tweening.Core.Easing;
using System.Collections;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public LevelTrackController LevelTrack = default;
    public LimbController Limbs = default;
    public TargetSpawner TargetSpawn = default;
    public GameUIController UIControl = default;
    public GlobalSound Sound = default;
    public TokenSpawner Tokens = default;

    public int targetsHit = 0;
    public int targetsRequired = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LevelTrack.Activate(this);
        Limbs.Activate(this);
        Limbs.DeactivateAllLimbs();
        TargetSpawn.Activate(this);
        Tokens.Activate(this);
        UIControl.SetCounter(targetsHit, targetsRequired);
        //StartCoroutine(DoPlayGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DoPlayGame()
    {
		//BeatBounceSync.SetBPM(90f);
		//Limbs.ActivateLimb(0);
		yield return new WaitForSeconds(3);
		LevelTrack.BeginLevel();
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
        TargetSpawn.SpawnNextTargetSet();
    }

    public void SpawnToken0()
    {
        if (!LevelTrack.IsDone() && 0 == Limbs.currentLimb)
        {
            Tokens.SpawnNextToken();
        }
    }
	public void SpawnToken1()
	{
		if (!LevelTrack.IsDone() && 1 == Limbs.currentLimb)
		{
			Tokens.SpawnNextToken();
		}
	}
	public void SpawnToken2()
	{
		if (!LevelTrack.IsDone() && 2 == Limbs.currentLimb)
		{
			Tokens.SpawnNextToken();
		}
	}
	public void SpawnToken3()
	{
		if (!LevelTrack.IsDone() && 3 == Limbs.currentLimb)
		{
			Tokens.SpawnNextToken();
		}
	}
}
