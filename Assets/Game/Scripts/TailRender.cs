using UnityEngine;

public class TailRender : MonoBehaviour
{
    public Transform[] Points = default;

    LineRenderer line = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = Points.Length;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = 0; i < Points.Length; ++i)
        {
            line.SetPosition(i, Points[i].position);
        }
    }
}
