using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
    GLOBALS glob;
	GameObject player;
	float countDown = 8.0f;
	float timer = 0f;
	bool startTimer = false;


	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		glob = player.GetComponent<GLOBALS> ();
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			glob.Espeed = 0f;
			startTimer = true;
			this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			glob.ignore = true;
			Debug.Log ("did Collide");
		}

	}
	void Update () {
		transform.Rotate (new Vector3(0f, 45f, 0f)*Time.deltaTime);
		if(startTimer == true){
			timer += Time.deltaTime;
			if (timer >= countDown) {
				glob.ignore = false;
				//glob.Espeed = Random.Range (1.5f, 3.0f);
				startTimer = false;
			}


			}
	}
}
