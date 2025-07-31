using UnityEngine;

public class LimbController : MonoBehaviour
{
    public ConstrainedCursorFollow[] LimbTargets = default;
    public LimbCollision[] LimbColliders = default;
    public MotionRecorder Recorder = default;

    int currentLimb = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ActivateLimb(currentLimb);
        //Recorder.StartRecording();
        DeactivateAllLimbs();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //++currentLimb;
            //if (currentLimb >= LimbTargets.Length)
            //{
            //    currentLimb = 0;
            //}
            //ActivateLimb(currentLimb);


            //DeactivateAllLimbs();
            //Recorder.StartPlayback();
        }
    }

    public void ActivateLimb(int index)
    {
		for (int i = 0; i < LimbTargets.Length; ++i)
		{
			LimbTargets[i].enabled = i == index;
            if (i == index)
            {
                LimbColliders[i].DoCollisions();
            }
            else
            {
				LimbColliders[i].DetectCollisions();
			}
		}
	}

    public void DeactivateAllLimbs()
    {
        for (int i = 0; i < LimbTargets.Length; ++i)
        {
            LimbTargets[i].enabled = false;
            LimbColliders[i].Deactivate();
        }
    }
}
