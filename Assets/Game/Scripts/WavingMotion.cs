using DG.Tweening;
using UnityEngine;

public class WavingMotion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Sin(Time.time) * 20) + 130);
    }
}
