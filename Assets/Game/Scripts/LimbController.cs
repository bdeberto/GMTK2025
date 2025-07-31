using System.Collections;
using UnityEngine;

public class LimbController : MonoBehaviour
{
    public ConstrainedCursorFollow[] LimbTargets = default;
    public LimbCollision[] LimbColliders = default;
    public MotionRecorder[] Recorders = default;

    int currentLimb = 3;
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
        foreach (LimbCollision c in LimbColliders)
        {
            c.Activate(manager);
        }
    }

    public void StunCurrentLimb()
    {
        StartCoroutine(DoCurrentLimbStun());
    }

    IEnumerator DoCurrentLimbStun()
    {
        Rigidbody2D rb = LimbTargets[currentLimb].GetComponentInChildren<Rigidbody2D>();
        SpriteRenderer sr = null;
        Color c = Color.white;
		if (rb != null)
        {
            sr = rb.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                c = sr.color;
                sr.color = Color.red;
            }
        }
        LimbColliders[currentLimb].Deactivate();
        LimbTargets[currentLimb].enabled = false;
        yield return new WaitForSeconds(1f);
		LimbColliders[currentLimb].DoCollisions();
        LimbTargets[currentLimb].enabled = true;
        if (sr != null)
        {
            sr.color = c;
        }
    }

    public void ActivateLimb(int index)
    {
		for (int i = 0; i < LimbTargets.Length; ++i)
		{
			LimbTargets[i].enabled = i == index;
            if (i == index)
            {
                LimbColliders[i].DoCollisions();
                currentLimb = i;
                Recorders[i].Stop();
            }
            else
            {
				LimbColliders[i].DetectCollisions();
			}
		}
	}

    public void DeactivateAllLimbs()
    {
        for (int i = 0; i < LimbTargets.Length; ++i)
        {
            LimbTargets[i].enabled = false;
            LimbColliders[i].Deactivate();
        }
    }

    public void StopAllPlayback()
    {
        foreach (MotionRecorder r in Recorders)
        {
            r.FullStop();
        }
    }

    public void StartRecording(int index)
    {
        for (int i = 0; i < Recorders.Length; ++i)
        {
            if (i == index)
            {
                Recorders[i].StartRecording();
            }
            else
            {
                Recorders[i].Stop();
            }
        }
    }

    public void StartPlayback(int index, bool looping = false)
    {
		for (int i = 0; i < Recorders.Length; ++i)
		{
			if (i == index)
			{
				Recorders[i].StartPlayback(looping);
			}
		}
	}
}
