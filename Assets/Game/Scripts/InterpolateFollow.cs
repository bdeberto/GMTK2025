using UnityEngine;

public class InterpolateFollow : MonoBehaviour
{
    public Transform Target = default;
    public float Speed = 7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * Speed);
    }
}
