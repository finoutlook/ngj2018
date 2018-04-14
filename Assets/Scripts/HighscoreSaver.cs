using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreSaver : MonoBehaviour {

	private string _highscoreFile;
	private int _playerScore;
	private string _playerName;
	private string[] _highscores;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		_highscoreFile = ApplicationModel.highscoreFile;
		_playerScore = ApplicationModel.playerScore;
		_playerName = "Anonymous";
		_highscores = System.IO.File.ReadAllLines(_highscoreFile);
		scoreText.text = _playerScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetName(string name)
	{
		_playerName = name;
	}

	public void AddHighscore()
	{
		int thisScore;
		System.IO.File.Delete(_highscoreFile);
		if(_highscores.Length < 1)
		{
			_highscores[0]="MrNobody:1";
		}
		Debug.Log("Saving scores");
		using (StreamWriter sw = File.AppendText(_highscoreFile)) 
		{
			foreach (string hs in _highscores)
			{
				thisScore = System.Int32.Parse((hs.Split(':'))[1]);
				if(_playerScore >= thisScore)
				{
					sw.WriteLine(_playerName+":"+_playerScore);
					Debug.Log("Added new line");
					sw.WriteLine((hs.Split(':'))[0]+":"+thisScore);
					Debug.Log("Added existing line");
				}
				else
				{
					sw.WriteLine((hs.Split(':'))[0]+":"+thisScore);
					Debug.Log("Added existing line");
				}
			}
		}
		SceneManager.LoadScene("Highscore");
	}
}
