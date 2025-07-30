using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class BeatBounce : MonoBehaviour
{
    public float Amplitude = .25f;
    public float BPM = 60f;

    float startingY = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingY = transform.position.y;
        Bounce();
		transform.DOMoveY(startingY, 60f / BPM).SetEase(Ease.OutCubic).SetLoops(-1).OnComplete(Bounce).Play();
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
