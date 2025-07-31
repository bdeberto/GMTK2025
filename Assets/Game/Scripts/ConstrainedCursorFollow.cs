using UnityEngine;

public class ConstrainedCursorFollow : MonoBehaviour
{
    public Transform Constraint = default;
    public float MaxDistance = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //TODO: MAKE THIS INTERPOLATE TO CURSOR INSTEAD
        float z = transform.position.z;
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = z;
        float d = Vector3.Distance(Constraint.position, target);
        if (d > MaxDistance)
        {
            float x = target.x / d * MaxDistance;
            float y = target.y / d * MaxDistance;
            transform.position = new Vector3(x, y, z);
        }
        else
        {
            transform.position = target;
        }
    }
}
