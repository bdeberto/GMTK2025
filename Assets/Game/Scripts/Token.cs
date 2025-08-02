using System.Collections;
using UnityEngine;

public class Token : MonoBehaviour
{
    GameplayManager gameManager = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
		gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate(GameplayManager manager)
    {
        gameManager = manager;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        PipDisplay other = collision.transform.parent.GetComponentInChildren<PipDisplay>();
		if (other != null && other.TouchToken())
        {
            //TODO: effects
            gameManager.Sound.PlayDing();
            gameObject.SetActive(false);
        }
	}
}
