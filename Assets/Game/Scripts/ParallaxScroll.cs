using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    public float speed = .1f;

    MeshRenderer sr = default;
    Vector2 direction = new Vector2(-1, .5f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		sr.material.SetTextureOffset("_BaseMap", direction * speed * Time.time);
	}
}
