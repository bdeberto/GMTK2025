using UnityEngine;
using UnityEngine.Audio;

public class GlobalSound : MonoBehaviour
{
	public AudioResource[] MenuBarks = default;
	public AudioResource[] OuchBarks = default;
    public AudioResource[] PraiseBarks = default;
    public AudioResource Rewind = default;
	public AudioResource LoopBack = default;
	public AudioResource Goal = default;
	public AudioResource Ding = default;

    AudioSource source = default;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayMenuBark()
    {
        int r = Random.Range(0, MenuBarks.Length);
        source.resource = MenuBarks[r];
        source.Play();
    }

	public void PlayOuchBark()
	{
		int r = Random.Range(0, OuchBarks.Length);
		source.resource = OuchBarks[r];
		source.Play();
	}

	public void PlayPraiseBark()
	{
		int r = Random.Range(0, PraiseBarks.Length);
		source.resource = PraiseBarks[r];
		source.Play();
	}

	public void PlayRewind()
	{
		source.resource = Rewind;
		source.Play();
	}

	public void PlayLoopBack()
	{
		source.resource = LoopBack;
		source.Play();
	}

	public void PlayGoal()
	{
		source.resource = Goal;
		source.Play();
	}

	public void PlayDing()
	{
		source.resource = Ding;
		source.Play();
	}
}
