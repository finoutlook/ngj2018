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
	public InputField nameText;
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

	public void AddHighscore()
	{
		int thisScore;
		string _playerName = nameText.text;
		System.IO.File.Delete(_highscoreFile);
		if(_highscores.Length < 1)
		{
			_highscores[0]="MrNobody:1";
		}
		Debug.Log("Saving scores");
		bool added = false;
		using (StreamWriter sw = File.AppendText(_highscoreFile)) 
		{
			foreach (string hs in _highscores)
			{
				thisScore = System.Int32.Parse((hs.Split(':'))[1]);
				if(_playerScore >= thisScore && !added)
				{
					sw.WriteLine(_playerName+":"+_playerScore);
					Debug.Log("Added new line "+ _playerName);
					sw.WriteLine((hs.Split(':'))[0]+":"+thisScore);
					Debug.Log("Added existing line " + (hs.Split(':'))[0]);
					added = true;
				}
				else
				{
					sw.WriteLine((hs.Split(':'))[0]+":"+thisScore);
					Debug.Log("Added existing line "+(hs.Split(':'))[0]);
				}
			}
		}
		SceneManager.LoadScene("Highscore");
	}
}
