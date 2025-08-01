using UnityEngine;

public class ColorPulse : MonoBehaviour
{
    public float Speed = 3f;

    SpriteRenderer sr = default;
    Color c = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        c = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        c.a = Mathf.Lerp(1f, 0f, Mathf.Sin(Time.time * Speed));
        sr.color = c;
    }
}
