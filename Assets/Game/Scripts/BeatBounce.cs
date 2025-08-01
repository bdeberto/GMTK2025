using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public static class BeatBounceSync
{
    static List<BeatBounce> components = new List<BeatBounce>();

    static BeatBounceSync()
    {
    }

    public static void RegisterComponent(BeatBounce comp)
    {
        components.Add(comp);
    }

    public static void SetBPM(float bpm)
    {
        foreach (BeatBounce b in components)
        {
            b.StopBounce();
            b.StartBounce(bpm);
        }
    }
}

public class BeatBounce : MonoBehaviour
{
    public float Amplitude = .25f;
    public float Delay = 0f;

    Vector3 startingPos = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BeatBounceSync.RegisterComponent(this);
        startingPos = transform.position;
	}

    void Bounce()
    {
		transform.position = transform.position + Vector3.down * Amplitude;
	}

    public void StartBounce(float bpm)
    {
		Bounce();
		transform.DOMoveY(startingPos.y, 60f / bpm).SetDelay(Delay).SetEase(Ease.OutCubic).SetLoops(-1).OnComplete(Bounce).Play();
	}

    public void StopBounce()
    {
        transform.DOKill(false);
        transform.position = startingPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
