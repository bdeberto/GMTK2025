using System.Collections.Generic;
using UnityEngine;

public class MotionRecorder : MonoBehaviour
{
    private struct RecordPoint
    {
        public float TimeStamp { get; set; }
        public Vector3 Point { get; set; }
    }

    private enum PlaybackState
    {
        OFF = 0,
        RECORD,
        PLAYBACK
    }

    List<RecordPoint> recordedMotion = new List<RecordPoint>();
    float timer = 0f;
    PlaybackState state = PlaybackState.OFF;
    float lastRecordedTime = 0f;

    const float TIME_STEP = .02f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastRecordedTime = -TIME_STEP;
        Stop();
    }

	void Update()
	{
		if (state != PlaybackState.OFF)
        {
            timer += Time.deltaTime;
        }
	}

	// Update is called once per frame
	void LateUpdate()
    {
        if (state == PlaybackState.RECORD)
        {
            if (timer >= lastRecordedTime + TIME_STEP)
            {
                RecordPoint p = new RecordPoint();
                p.TimeStamp = timer;
                p.Point = transform.position;
                recordedMotion.Add(p);
                lastRecordedTime = timer;
            }
        }
        else if (state == PlaybackState.PLAYBACK)
        {
			int i = (int)(timer / TIME_STEP);
			if (i < recordedMotion.Count)
            {
                transform.position = recordedMotion[i].Point;
            }
        }
    }

    public void StartRecording()
    {
        recordedMotion.Clear();
        timer = 0f;
        state = PlaybackState.RECORD;
    }

    public void StartPlayback()
    {
        timer = 0f;
        state = PlaybackState.PLAYBACK;
    }

	public void Stop()
	{
        state = PlaybackState.OFF;
	}
}
