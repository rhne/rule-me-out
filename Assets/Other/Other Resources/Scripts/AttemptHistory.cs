using UnityEngine;
using System.Collections.Generic;
using System;

public class AttemptHistory : MonoBehaviour {

	//get 2 clean ints from enter button
	//get question and answer from Challenge Controller
	//question is the one assigned to rule delegate, so it's in challenger's area
	//save attempts into list
	//saving attempts success...
	//we're going to need the attempts to be unique. where are we going to save the code to do this?
	//i think it's here. this script is a ruler.
	//after we have the list, we need to show up them. 
	//unlike the video tutorial, we're updating it each time a new item is added.
	//so we're going to call populate function over the other script in the list panel. OK?

	//list updater script should contain:
	//call prefab and set the text values when triggered. the trigger is... when there's new item.

	//things needed to be fixed
	//this thing harus banget taru di manager, karna ini middlewarenya kan ya.
	//jadi kerjaan fetching list container nya itu... dipikirin.

	/*
	 * problem is, the prefab isn't populating.[SOLVED]
	 * 
	 * where should we create new question?
	 */

	//has function to check for combination a and b to be unique

	List< List<int> > historyAttempt;

	// Use this for initialization
	void Start () {
	
	}

	void Init() {
		if(historyAttempt==null)
			historyAttempt = new List<List<int>>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public int AskQuestion (int a, int b) {
		//TODO: fix this condition later with proper handling.
		Debug.Assert (isAttempted (a, b) == false);
		if (isAttempted (a, b)) {
			Debug.Log ("Numbers have already attempted.");
			throw new ArgumentException ("Numbers have already attempted.");
		} else if (historyAttempt.Count > 9) {
			throw new ArgumentException ("You have used all 10 attempts");
		}

		int result = GameObject.Find ("Manager").GetComponent<ChallengeController> ().AskQuestion(a,b);
		List<int> myList = new List<int>();
		myList.Add (a);
		myList.Add (b);
		myList.Add (result);

		Init();
		historyAttempt.Add (myList);

		//populate the new attempt to screen
		GameObject.Find("History List").GetComponent<HistoryList>().Append(a,b,result);

		return result;
	}

	/* return true if the combination has already attempted
	 * in order to make sure attempted combination won't appear twice since the maximum is 10
	 */
	public bool isAttempted(int a, int b) {
		Init ();

		//coroutine
		foreach (var item in historyAttempt) {
			if (item [0] == a && item [1] == b)
				return true;
		}

		return false;
	}

}
