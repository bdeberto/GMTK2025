using UnityEngine;

public class LimbConnect : MonoBehaviour
{
    public Transform[] Connectors = default;
    public Transform Root = default;
    public Transform Target = default;

    LineRenderer lr = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = Connectors.Length + 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float xDist = Target.position.x - Root.position.x;
        float yDist = Target.position.y - Root.position.y;
        float xStep = xDist / Connectors.Length;
        float yStep = yDist / Connectors.Length;
        lr.SetPosition(0, Root.position);
        for (int i = 0; i < Connectors.Length; ++i)
        {
            Vector3 connectorPos = Root.position + new Vector3(xStep * i, yStep * i);
            Connectors[i].position = Vector3.Lerp(Connectors[i].position, connectorPos, Time.deltaTime * 3f * (i + 1));
            lr.SetPosition(i + 1, Connectors[i].position);
		}
		lr.SetPosition(lr.positionCount - 1, Target.position);
    }
}
