using UnityEngine;

public class ConstrainedCursorFollow : MonoBehaviour
{
    public Transform Constraint = default;
    public float MaxDistance = 4f;

    bool resting = true;
    Vector3 startPostition = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resting = true;
        startPostition = transform.parent.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
		Vector3 targetPos;
		if (resting)
        {
            targetPos = startPostition;
        }
        else
        {
            float z = transform.parent.position.z;
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = z;
            float d = Vector3.Distance(Constraint.position, target);
            if (d > MaxDistance)
            {
                float x = target.x / d * MaxDistance;
                float y = target.y / d * MaxDistance;
                targetPos = new Vector3(x, y, z);
            }
            else
            {
                targetPos = target;
            }
        }
        transform.parent.position = Vector3.Lerp(transform.parent.position, targetPos, Time.deltaTime * 7f);
    }

    public void Rest()
    {
        resting = true;
    }

    public void Wake()
    {
        resting = false;
    }
}
