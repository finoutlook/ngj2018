using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour {

	private string _highscoreFile;
	public Text highscoreList;

	private string[] _highscores;

	// Use this for initialization
	void Start () {
		_highscoreFile = ApplicationModel.highscoreFile;
		highscoreList.text = "";
		_highscores = System.IO.File.ReadAllLines(_highscoreFile);
		foreach (string line in _highscores)
		{
			highscoreList.text += line.Replace(":"," : ") + "\n\r";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
