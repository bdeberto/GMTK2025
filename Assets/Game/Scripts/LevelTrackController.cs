using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class LevelTrackController : MonoBehaviour
{
    public PlayableDirector Director = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Director.duration

            //Need to be able to figure out when in the timeline the playable is at at any given time
            //Need to throw an event when the playable is done and then loop it back
        }
    }
}
