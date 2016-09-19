using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ManagerScene: MonoBehaviour {
	[Header("Scene List")]
	[SerializeField] Object mainMenuScene;
	[SerializeField] Object SurvivalModeScene;

	[Header("Story Mode Scenes")]
	[SerializeField] Object[] Baghdad;
	[SerializeField] Object[] LevelScene; //urut 1-3

	static bool exist = false;

	public static int n=0;

	//void Awake(){
	//	if (!exist) {
	//		DontDestroyOnLoad (this.gameObject);
	//		exist = true;
	//	} else {
	//		Destroy (this.gameObject);
	//	}
	//}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadSurvivalMode() {
		SceneManager.LoadScene (SurvivalModeScene.name);
		//SceneManager.LoadScene(SurvivalModeScene.name);
	}

	public void LoadBaghdadOP() {
		SceneManager.LoadScene (Baghdad[0].name);
	}

	public void LoadBaghdadStoryScene() {
		SceneManager.LoadScene (Baghdad [1].name);
	}

	public void LoadBaghdadPlay() {
		SceneManager.LoadScene (Baghdad [2].name);
	}


}