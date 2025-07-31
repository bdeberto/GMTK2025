using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public LevelTrackController LevelTrack = default;
    public LimbController Limbs = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LevelTrack.Activate(this);
        Limbs.Activate(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReportHit(float distance)
    {
        //TODO: scoring
    }

    public void ReportLimbCollision()
    {
        Limbs.StunCurrentLimb();
    }
}
