using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private int _score;
	public Text scoreText;
	private string _prefix;

	// Use this for initialization
	void Start () {
		_score = 0;
		_prefix = "SCORE: ";
	}
	
	// Update is called once per frame
	void Update () {	
		scoreText.text = _prefix + _score.ToString();	
	}

	public void UpdateScore(int value)
	{
		_score += value;
	}

	public int GetScore()
	{
		return _score;
	}
}
