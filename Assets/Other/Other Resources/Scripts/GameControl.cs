using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using LitJson;

public class GameControl : MonoBehaviour {
	public static GameControl control;

	public string level;
	public int score;

	int playCount;

	//dictionary<question_index, correct_count>
	Dictionary<int,int> questions = new Dictionary<int,int>();
	JsonData playData;

	void Awake() {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != null) {
			Destroy (gameObject);
		}
		UpdateScoreGUI ();
	}
		
	/*void OnApplicationQuit() {
		WriteToXML ();
		Debug.Log ("onquit");
	}
	*/
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayCountIncrement() {
		control.playCount += 1;
	}

	public void AddScore(int n) {
		control.score += n;
	}

	public void ResetScore() {
		control.score = 0;
	}

	public void UpdateScoreGUI() {
		//update score if exists
		Text scoreBoard = GameObject.Find ("Score Board").GetComponent<Text> ();
		if (scoreBoard) {
			scoreBoard.text = control.score.ToString();
		}
	}

	public void UpdateQuestionsCorrectCount(int questionIndex) {
		if (control.questions.ContainsKey (questionIndex)) {
			control.questions [questionIndex] += 1;
		} else {
			control.questions.Add(questionIndex,1);
		}
	}

	public void WriteToXML() {
		//questions.Add(999,playCount);

		string filepath = Application.dataPath + "/Data/gamedata.xml";

		XmlSerializer serializer = new XmlSerializer(typeof(GameControl));

		FileStream stream = new FileStream (filepath, FileMode.OpenOrCreate);
		serializer.Serialize (stream, control);

		stream.Close ();

	}

	public void WriteJSON() {
		control.questions.Add(999,playCount);
		GameData data = new GameData ();
		data.GameDataConstructor(playCount, control.questions);
		playData = JsonMapper.ToJson (data);
		File.WriteAllText (Application.dataPath + "Playdata.json", playData.ToString ());
		Debug.Log ("WriteToJSON");
	}
}

public class GameData {
	public int playCount;
	public int[] questions;
	public int[] trueCounts;

	public void GameDataConstructor (int a, Dictionary<int,int> dict) {
		this.playCount = a;
		this.questions = dict.Keys.ToArray();
		this.trueCounts = dict.Values.ToArray();
	}
}