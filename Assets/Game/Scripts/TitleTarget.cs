using UnityEngine;

public class TitleTarget : MonoBehaviour
{
	public PipDisplay Display = default;

	int tokensHeld = 0;
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
		if (other != null)
		{
			bool exchangeHappened = false;
			while (other.pipsHeld > 0 && tokensHeld < Display.Pips.Length)
			{
				other.pipsHeld--;
				tokensHeld++;
				exchangeHappened = true;
			}
			for (int i = 0; i < Display.Pips.Length; ++i)
			{
				Display.Pips[i].enabled = i + 1 <= tokensHeld;
			}
			for (int i = 0; i < other.Pips.Length; ++i)
			{
				other.Pips[i].enabled = i + 1 <= other.pipsHeld;
			}
			if (exchangeHappened)
			{
				//TODO: effects
				if (tokensHeld == Display.Pips.Length)
				{
					gameManager.Game.Sound.PlayPraiseBark();
					gameManager.IsReady = true;
				}
			}
		}
	}
}
