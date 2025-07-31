using UnityEngine;
using UnityEngine.WSA;

public class LimbCollision : MonoBehaviour
{
    public Collider2D CollisionDetector = default;
    public Collider2D Collision = default;

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

    public void DetectCollisions()
    {
        Collision.enabled = false;
        CollisionDetector.enabled = true;
    }

	public void DoCollisions()
	{
		Collision.enabled = true;
		CollisionDetector.enabled = false;
	}

	public void Deactivate()
	{
		Collision.enabled = false;
		CollisionDetector.enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        gameManager.ReportLimbCollision();
	}
}
