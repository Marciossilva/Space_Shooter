using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{


	private bool start;

	void Start(){
		start = true;
	}

	void Update(){
		if (start) {
			if(Input.GetKeyDown(KeyCode.S)){
				Application.LoadLevel(Application.loadedLevel+1);
			}
		}

	}






}


