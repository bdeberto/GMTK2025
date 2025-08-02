using UnityEngine;

public class Token : MonoBehaviour
{
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
        PipDisplay other = collision.transform.parent.GetComponentInChildren<PipDisplay>();
		if (other != null && other.TouchToken())
        {
            //TODO: effects
            gameObject.SetActive(false);
        }
	}
}
