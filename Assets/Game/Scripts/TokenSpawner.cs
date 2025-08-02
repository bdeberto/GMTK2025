using DG.Tweening.Core.Easing;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public Token TokenPrefab = default;
    public Transform TokenRoot = default;

	GameplayManager gameManager = default;
    List<Token> spawnedTokens = new List<Token>();

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Activate(GameplayManager manager)
	{
		gameManager = manager;
	}

    public void SpawnNextToken()
    {
        float x = Random.Range(0f, 1f);
		float y = Random.Range(0f, 1f);
        Token t = Instantiate(TokenPrefab);
        t.transform.parent = TokenRoot;
        t.transform.localPosition = new Vector3(x, y, 0);
        spawnedTokens.Add(t);
	}

    public void CleanUpTokens()
    {
        foreach (Token t in spawnedTokens)
        {
            Destroy(t.gameObject);
        }
        spawnedTokens.Clear();
    }
}
