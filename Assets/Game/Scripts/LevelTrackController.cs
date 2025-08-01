using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class LevelTrackController : MonoBehaviour
{
    [System.Serializable]
    public struct Level
    {
		public float bpm;
        public Color bgColor;
		public PlayableAsset leadIn;
        public PlayableAsset levelTrack;
        public Transform[] limbTargetParents;
        public int[] pointThresholds;
    }

    public PlayableDirector Director = default;
    public PlayableAsset LeadInAsset = default;
    public PlayableAsset LevelAsset = default;
    public AudioSource[] SoundChannels = default;

    public Level[] levels = default;

    public bool OKToContinue { set; get; }

    GameplayManager gameManager = default;
    bool isRunning = false;
    bool isDone = false;
    bool confirmed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OKToContinue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (isDone && Input.GetKeyDown(KeyCode.Mouse0))
            {
                DoContinue();
            }
        }
    }

    public void Activate(GameplayManager manager)
    {
        gameManager = manager;
    }

    public void BeginLevel()
    {
        isRunning = true;
        isDone = false;
        confirmed = false;
        StartCoroutine(DoLevel());
    }

    bool DoContinue()
    {
        return !isRunning && isDone && confirmed;
    }

    public bool IsDone()
    {
        return isDone;
    }

    IEnumerator DoLevel()
    {
        BeatBounceSync.SetBPM(90f);
        Camera.main.DOColor(new Color(224f / 255f, 109f / 255f, 6f / 255f), 2f);
        foreach (AudioSource a in SoundChannels)
        {
            a.enabled = false;
        }
        for (int i = 0; i < 4; ++i)
        {
			gameManager.TargetSpawn.Targets = levels[0].limbTargetParents[i].GetComponentsInChildren<Transform>();
            gameManager.targetsHit = 0;
            gameManager.targetsRequired = levels[0].pointThresholds[i];
			SoundChannels[i].enabled = true;
			do
            {
                Director.extrapolationMode = DirectorWrapMode.None;
                Director.playableAsset = LeadInAsset;
				Director.Play();
                gameManager.Limbs.LimbHighlight(i);
				yield return new WaitForSeconds((float)Director.duration - 2);
				gameManager.Limbs.ActivateLimb(i);
                yield return new WaitForSeconds(2);
                Director.playableAsset = LevelAsset;
                Director.Play();
                for (int j = 0; j < 4; ++j)
                {
                    if (j != i)
                    {
                        gameManager.Limbs.StartPlayback(j);
                    }
                }
				gameManager.Limbs.StartRecording(i);
                yield return new WaitForSeconds((float)Director.duration);
				gameManager.Limbs.StopAllPlayback();
                gameManager.Limbs.DeactivateAllLimbs();
			} while (!OKToContinue);
		}
        Director.Play();
		Director.extrapolationMode = DirectorWrapMode.Loop;
		for (int j = 0; j < 4; ++j)
		{
			gameManager.Limbs.StartPlayback(j, true);
		}
		isDone = true;
        yield return new WaitUntil(DoContinue);
	}
}
