using System.Collections;
using UnityEngine;

public class LimbController : MonoBehaviour
{
    public ConstrainedCursorFollow[] LimbFollows = default;
    public LimbCollision[] LimbColliders = default;
    public MotionRecorder[] Recorders = default;
    public SpriteRenderer Highlighter = default;
    public PipDisplay Pips = default;

    public int currentLimb = 3;
    GameplayManager gameManager = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Highlighter.gameObject.SetActive(false);
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
        Pips.Activate(manager);
    }

    public void StunCurrentLimb()
    {
        gameManager.Sound.PlayOuchBark();
        StartCoroutine(DoCurrentLimbStun());
    }

    IEnumerator DoCurrentLimbStun()
    {
        Rigidbody2D rb = LimbFollows[currentLimb].GetComponentInChildren<Rigidbody2D>();
        SpriteRenderer sr = null;
        Color c = new Color(22f / 255f, 16f / 255f, 50f / 255f);
		if (rb != null)
        {
            sr = rb.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = new Color(224f / 255f, 109f / 255f, 6f / 255f);
            }
        }
        LimbColliders[currentLimb].Deactivate();
        LimbFollows[currentLimb].Rest();
        int stunnedLimb = currentLimb;
        yield return new WaitForSeconds(1f);
        if (stunnedLimb == currentLimb)
        {
            LimbColliders[currentLimb].DoCollisions();
            LimbFollows[currentLimb].Wake();
        }
        if (sr != null)
        {
            sr.color = c;
        }
    }

    public void ActivateLimb(int index)
    {
		for (int i = 0; i < LimbFollows.Length; ++i)
		{
            if (i == index)
            {
                Pips.Attach(LimbColliders[i].transform);
                LimbFollows[i].Wake();
				LimbColliders[i].DoCollisions();
                currentLimb = i;
                Recorders[i].Stop();
            }
            else
            {
                LimbFollows[i].Rest();
				LimbColliders[i].DetectCollisions();
			}
		}
	}

    public void DeactivateAllLimbs()
    {
        for (int i = 0; i < LimbFollows.Length; ++i)
        {
            LimbFollows[i].Rest();
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

    public void LimbHighlight(int index)
    {
        StartCoroutine(DoLimbHighlight(index));
    }

    IEnumerator DoLimbHighlight(int index)
    {
		Rigidbody2D rb = LimbFollows[index].GetComponentInChildren<Rigidbody2D>();
		SpriteRenderer sr = null;
		Color c = Color.white;
		if (rb != null)
		{
			sr = rb.GetComponent<SpriteRenderer>();
			if (sr != null)
			{
				c = sr.color;
				sr.color = new Color(254f / 255f, 198f / 255f, 6f / 255f);
			}
		}
        Highlighter.transform.position = LimbFollows[index].transform.position;
		Highlighter.gameObject.SetActive(true);
		yield return new WaitForSeconds(3);
		Highlighter.gameObject.SetActive(false);
		if (sr != null)
		{
			sr.color = c;
		}
	}
}
