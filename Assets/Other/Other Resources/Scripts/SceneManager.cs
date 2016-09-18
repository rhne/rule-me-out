using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManager : MonoBehaviour {
	[Header("Scene List")]
	[SerializeField] Object mainMenuScene;
	[SerializeField] Object SurvivalModeScene;

	[Header("Story Mode Scenes")]
	[SerializeField] Object[] Baghdad;
	[SerializeField] Object[] LevelScene; //urut 1-3

	static bool exist = false;

	void Awake(){
		if (!exist) {
			DontDestroyOnLoad (this.gameObject);
			exist = true;
		} else {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadSurvivalMode() {
		Application.LoadLevel (SurvivalModeScene.name);
		//SceneManager.LoadScene(SurvivalModeScene.name);
	}

	public void LoadBaghdadOP() {
		Application.LoadLevel (Baghdad[0].name);
	}

	public void LoadBaghdadStoryScene() {
		Application.LoadLevel (Baghdad [1].name);
	}

	public void LoadBaghdadPlay() {
		Application.LoadLevel (Baghdad [2].name);
	}

}