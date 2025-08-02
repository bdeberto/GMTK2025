using UnityEngine;

public class TokenTarget : MonoBehaviour
{
    public PipDisplay Display = default;

    int tokensHeld = 0;
    int tokensThisRound = 0;
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
    }

    public void ResetTargets()
    {
        tokensHeld -= tokensThisRound;
        tokensThisRound = 0;
		for (int i = 0; i < Display.Pips.Length; ++i)
		{
			Display.Pips[i].enabled = i + 1 <= tokensHeld;
		}
	}

    public void RoundClear()
    {
        tokensThisRound = 0;
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
                tokensThisRound++;
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
                    gameManager.Sound.PlayPraiseBark();
                    gameManager.ReportHit(0f);
                }
            }
		}
	}
}
