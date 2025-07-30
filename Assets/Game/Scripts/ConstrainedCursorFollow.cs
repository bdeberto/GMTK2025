using UnityEngine;

public class ConstrainedCursorFollow : MonoBehaviour
{
    public Transform Constraint = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float z = transform.position.z;
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = z;
        transform.position = Vector3.Lerp(Constraint.position, target, .25f);
    }
}
