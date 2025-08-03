using DG.Tweening;
using System.Collections;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public GameplayManager Game = default;
    public Transform GameCameraPos = default;
    //public Transform TitleCameraPos = default;
    public Transform Title = default;
    public TitleTarget Target = default;
    public TitleToken Token1 = default;
    public GameObject InstructionText = default;

    public bool IsReady { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        //Camera.main.transform.position = TitleCameraPos.position;
        Target.Activate(this);
        Token1.Activate(this);
        yield return null;
		BeatBounceSync.SetBPM(60f);
		Game.Limbs.ActivateLimb(0);
        yield return new WaitUntil(Ready);
        InstructionText.SetActive(false);
        Title.DOMoveX(20f, 1f).SetEase(Ease.InCubic);
        Target.transform.DOMoveY(20f, 1f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(1f);
        Camera.main.transform.DOMove(GameCameraPos.position, 1f).SetEase(Ease.OutCubic);
        yield return new WaitForSeconds(2f);
        StartCoroutine(Game.DoPlayGame());
	}

    bool Ready()
    {
        return IsReady;
    }

	// Update is called once per frame
	void Update()
    {
        
    }
}
