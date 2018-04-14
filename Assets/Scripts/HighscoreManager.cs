using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour {

	private string _highscoreFile = "C:\\Projects\\GameJam\\ngj2018\\highscore.txt";
	public Text highscoreList;

	private string[] _highscores;

	// Use this for initialization
	void Start () {
		highscoreList.text = "";
		_highscores = System.IO.File.ReadAllLines(_highscoreFile);
		foreach (string line in _highscores)
		{
			highscoreList.text += line + "\n\r";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddHighscore(int score, string name)
	{
		int thisScore;
		System.IO.File.Delete(_highscoreFile);
		using (StreamWriter sw = File.AppendText(_highscoreFile)) 
		{
			foreach (string hs in _highscores)
			{
				thisScore = System.Int32.Parse((hs.Split(':'))[1]);
				if(score >= thisScore)
				{
					System.IO.File.AppendText(name+":"+score);
				}
				else
				{
					System.IO.File.AppendText((hs.Split(':'))[0]+":"+thisScore);
				}
			}
		}
	}
}
