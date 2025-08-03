using System.Collections;
using UnityEngine;

public class TitleToken : MonoBehaviour
{
	GameFlowManager gameManager = default;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Activate(GameFlowManager manager)
	{
		gameManager = manager;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PipDisplay other = collision.transform.parent.GetComponentInChildren<PipDisplay>();
		if (other != null && other.TouchToken())
		{
			//TODO: effects
			gameManager.Game.Sound.PlayDing();
			gameObject.SetActive(false);
		}
	}
}
