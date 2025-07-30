using UnityEngine;

public class LimbController : MonoBehaviour
{
    public ConstrainedCursorFollow[] LimbTargets;

    int currentLimb = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateLimb(currentLimb);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ++currentLimb;
            if (currentLimb >= LimbTargets.Length)
            {
                currentLimb = 0;
            }
            ActivateLimb(currentLimb);
        }
    }

    public void ActivateLimb(int index)
    {
		for (int i = 0; i < LimbTargets.Length; ++i)
		{
			LimbTargets[i].enabled = i == index;
		}
	}

    public void DeactivateAllLimbs()
    {
        for (int i = 0; i < LimbTargets.Length; ++i)
        {
            LimbTargets[i].enabled = false;
        }
    }
}
