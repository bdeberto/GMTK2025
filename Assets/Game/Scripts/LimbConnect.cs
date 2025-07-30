using UnityEngine;

public class LimbConnect : MonoBehaviour
{
    public Transform[] Connectors = default;
    public Transform Root = default;
    public Transform Target = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float xDist = Target.position.x - Root.position.x;
        float yDist = Target.position.y - Root.position.y;
        float xStep = xDist / Connectors.Length;
        float yStep = yDist / Connectors.Length;
        for (int i = 0; i < Connectors.Length; ++i)
        {
            Vector3 connectorPos = Root.position + new Vector3(xStep * i, yStep * i);
            Connectors[i].position = connectorPos;
        }
    }
}
