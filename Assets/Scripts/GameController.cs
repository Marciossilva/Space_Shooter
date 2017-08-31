using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public GameObject hazard;
	public Vector3 spawValues;
	public int hazardCount;
	public float spawWait;
	public float startWait;
	public float waitWave;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;


	private bool gameOver;
	private bool restart;
	private int score;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine( SpawWaves ());
	}

	void Update(){
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel-1);
			}
		}
	
	}

	IEnumerator SpawWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while(true){
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawPosition = new Vector3 (Random.Range (-spawValues.x, spawValues.x), spawValues.y, spawValues.z);
				Quaternion spawRotation = Quaternion.identity;
				Instantiate (hazard, spawPosition, spawRotation);
				yield return new WaitForSeconds (spawWait);

			}
			yield return new WaitForSeconds (waitWave);
			hazardCount++;

			if (gameOver) {
				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	public void addScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}
	public void GameOver(){
		gameOverText.text = "GAME OVER";
		gameOver = true;
	}
}
