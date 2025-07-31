using DG.Tweening;
using UnityEngine;

public class BeatBounce : MonoBehaviour
{
    public float Amplitude = .25f;
    public float BPM = 60f;
    public float Delay = 0f;

    float startingY = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingY = transform.position.y;
        Bounce();
		transform.DOMoveY(startingY, 60f / BPM).SetDelay(Delay).SetEase(Ease.OutCubic).SetLoops(-1).OnComplete(Bounce).Play();
	}

    void Bounce()
    {
		transform.position = transform.position + Vector3.down * Amplitude;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
