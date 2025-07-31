using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class LevelTrackController : MonoBehaviour
{
    public PlayableDirector Director = default;
    public Transform[] TargetSpawnRoots = default;
    public LimbTarget TargetPrefab = default;

    GameplayManager gameManager = default;
    float totalTimer = -1f;
    float safeTime = -1f;
    bool isRunning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (totalTimer < safeTime && Input.GetKeyDown(KeyCode.Mouse0))
            {


                
            }
            totalTimer += Time.deltaTime;
            if (totalTimer > Director.duration)
            {
                totalTimer = 0f;
                Debug.Log("Looping back");
            }
        }
    }

    public void Activate(GameplayManager manager)
    {
        gameManager = manager;
        totalTimer = 0f;
        safeTime = (float)Director.duration - 2f;
        Director.Play();
        isRunning = true;
    }


}
