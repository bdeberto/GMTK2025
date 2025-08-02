using UnityEngine;

public class PipDisplay : MonoBehaviour
{
    public SpriteRenderer[] Pips = default;

    GameplayManager gameManager = default;
    public int pipsHeld = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		foreach (SpriteRenderer s in Pips)
		{
			s.enabled = false;
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(GameplayManager manager)
    {
        gameManager = manager;
    }

    public void Attach(Transform target)
    {
        transform.parent = target;
        transform.localPosition = Vector3.zero;
    }

    public bool TouchToken()
    {
        if (pipsHeld < Pips.Length)
        {
            Pips[pipsHeld++].enabled = true;
            return true;
        }
        return false;
    }

    public void DumpTokens()
    {
        pipsHeld = 0;
        foreach (SpriteRenderer s in Pips)
        {
            s.enabled = false;
        }
    }

    
}
