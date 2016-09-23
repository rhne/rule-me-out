using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ManagerScene: MonoBehaviour {

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
		SceneManager.LoadScene (1);
		//SceneManager.LoadScene(SurvivalModeScene.name);
	}

	public void LoadBaghdadOP() {
		SceneManager.LoadScene (2);
	}

	public void LoadBaghdadStoryScene() {
		SceneManager.LoadScene (3);
	}

	public void LoadBaghdadPlay() {
		SceneManager.LoadScene (4);
	}

	public void LoadBaghdadAnswer() {
		GameObject.Find ("Manager").GetComponent<ChallengeController> ().SaveRealAnswer();
		SceneManager.LoadScene (5);
	}


}