using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Slide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        transform.DOLocalMove(new Vector3(-.15f, -.15f, 0f), 1f).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnDestroy()
	{
        DOTween.Kill(transform);
	}
}
