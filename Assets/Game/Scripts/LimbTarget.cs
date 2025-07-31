using DG.Tweening;
using System.Collections;
using UnityEngine;

public class LimbTarget : MonoBehaviour
{
    public Transform IndicatorRing = default;
    public SpriteRenderer HitIndicator = default;
    public float AliveTime = 3f;

    Color originalColor = default;
    Transform hit = null;
    bool alive = true;
    GameplayManager gameManager = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (alive)
        {
            HitIndicator.color = Color.white;
            hit = collision.transform;
        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (alive)
        {
            HitIndicator.color = originalColor;
            hit = null;
        }
	}

	public void Activate(GameplayManager manager)
    {
        gameManager = manager;
		originalColor = HitIndicator.color;
		IndicatorRing.DOScale(2f, AliveTime);
        IndicatorRing.DORotate(Vector3.forward * 180f, AliveTime).SetEase(Ease.OutCubic);
        StartCoroutine(SignalParent());
    }

    IEnumerator SignalParent()
    {
        yield return new WaitForSeconds(AliveTime);
        transform.DOScale(0f, .5f);
		IndicatorRing.DORotate(Vector3.zero, .2f);
        if (hit != null)
        {
            float d = Vector3.Distance(transform.position, hit.position);
            gameManager.ReportHit(d);
        }
        alive = false;
		yield return new WaitForSeconds(.6f);
		Destroy(gameObject);
    }
}
