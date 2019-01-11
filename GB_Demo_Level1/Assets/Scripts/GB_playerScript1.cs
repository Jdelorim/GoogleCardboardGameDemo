using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GB_playerScript1 : MonoBehaviour {
	GameObject pg1;
	GameObject pg2;
	GameObject pg3;
	GameObject pg4;

	GameObject player1;


	BoxCollider inFrontBox;

	public bool isTouching1 = false;
	public bool isTouching2 = false;
	public bool isTouching3 = false;
	public bool isTouching4 = false;



	bool isDropped1 = false;
	bool isDropped2 = false;
	bool isDropped3 = false;
	bool isDropped4 = false;

	int counttoWin = 0;

	float countDown = 3.0f;
	float timer = 0f;

	public GUITexture overlay;

	public string levelchanger;

	GvrAudioSource AS;
	public AudioClip sfxPickup;
	public AudioClip sfxDrop;


	void Start () {
		pg1 = GameObject.FindGameObjectWithTag ("pg1");
		pg2 = GameObject.FindGameObjectWithTag ("pg2");
		pg3 = GameObject.FindGameObjectWithTag ("pg3");
		pg4 = GameObject.FindGameObjectWithTag ("pg4");

		player1 = GameObject.FindGameObjectWithTag ("playerobject");

		inFrontBox = player1.GetComponent<BoxCollider> ();
		inFrontBox.enabled = false;

		AS = GetComponent<GvrAudioSource> ();

	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("pg1")) {
			isTouching1 = true;

			pg2.GetComponent<BoxCollider> ().isTrigger = false;
			pg3.GetComponent<BoxCollider> ().isTrigger = false;
			pg4.GetComponent<BoxCollider> ().isTrigger = false;
			inFrontBox.enabled = true;
			AS.PlayOneShot (sfxPickup, 0.8f);
		

		}
		else if (other.gameObject.CompareTag ("pg2")) {
			isTouching2 = true;
			pg1.GetComponent<BoxCollider> ().isTrigger = false;

			pg3.GetComponent<BoxCollider> ().isTrigger = false;
			pg4.GetComponent<BoxCollider> ().isTrigger = false;
			inFrontBox.enabled = true;
			AS.PlayOneShot (sfxPickup, 0.8f);

		}
		else if (other.gameObject.CompareTag ("pg3")) {
			isTouching3 = true;
			pg1.GetComponent<BoxCollider> ().isTrigger = false;
			pg2.GetComponent<BoxCollider> ().isTrigger = false;

			pg4.GetComponent<BoxCollider> ().isTrigger = false;
			inFrontBox.enabled = true;
			AS.PlayOneShot (sfxPickup, 0.8f);

		}
		else if (other.gameObject.CompareTag ("pg4")) {
			isTouching4 = true;
			pg1.GetComponent<BoxCollider> ().isTrigger = false;
			pg2.GetComponent<BoxCollider> ().isTrigger = false;
			pg3.GetComponent<BoxCollider> ().isTrigger = false;
			inFrontBox.enabled = true;
			AS.PlayOneShot (sfxPickup, 0.8f);

		}
	

		if (other.gameObject.CompareTag ("powerPad") && isTouching1 == true) {
			inFrontBox.enabled = false;
			isDropped1 = true;


			pg1.GetComponent<Rigidbody> ().useGravity = true;
			pg1.GetComponent<Rigidbody> ().isKinematic = false;
			isTouching1 = false;
			droppedStuff ();
			counttoWin++;
			AS.PlayOneShot (sfxDrop, 0.8f);
		} 
		else if (other.gameObject.CompareTag ("powerPad") && isTouching2 == true) {
			inFrontBox.enabled = false;
			isDropped2 = true;

			pg2.GetComponent<Rigidbody> ().useGravity = true;
			pg2.GetComponent<Rigidbody> ().isKinematic = false;
			isTouching2 = false;
			droppedStuff ();
			counttoWin++;
			AS.PlayOneShot (sfxDrop, 0.8f);
		}
		else if (other.gameObject.CompareTag ("powerPad") && isTouching3 == true) {
			inFrontBox.enabled = false;
			isDropped3 = true;

			pg3.GetComponent<Rigidbody> ().useGravity = true;
			pg3.GetComponent<Rigidbody> ().isKinematic = false;
			isTouching3 = false;
			droppedStuff ();
			counttoWin++;
			AS.PlayOneShot (sfxDrop, 0.8f);
		}
		else if (other.gameObject.CompareTag ("powerPad") && isTouching4 == true) {
			inFrontBox.enabled = false;
			isDropped4 = true;

			pg4.GetComponent<Rigidbody> ().useGravity = true;
			pg4.GetComponent<Rigidbody> ().isKinematic = false;
			isTouching4 = false;
			droppedStuff ();
			counttoWin++;
			AS.PlayOneShot (sfxDrop, 0.8f);
		}

	}

	void droppedStuff(){
		if (isDropped1 == true) {
			pg1.GetComponent<BoxCollider> ().isTrigger = false;

		} else {
			pg1.GetComponent<BoxCollider> ().isTrigger = true;
		}
		if (isDropped2 == true) {
			pg2.GetComponent<BoxCollider> ().isTrigger = false;
		} else {
			pg2.GetComponent<BoxCollider> ().isTrigger = true;
		}
		if (isDropped3 == true) {
			pg3.GetComponent<BoxCollider> ().isTrigger = false;
		} else {
			pg3.GetComponent<BoxCollider> ().isTrigger = true;
		}
		if (isDropped4 == true) {
			pg4.GetComponent<BoxCollider> ().isTrigger = false;
		} else {
			pg4.GetComponent<BoxCollider> ().isTrigger = true;
		}


	}
	

	void Update () {
		if (isTouching1 == true) {
			inFrontBox.enabled = true;
			pg1.transform.position = player1.transform.position;

		} else if (isTouching2 == true) {
			inFrontBox.enabled = true;
			pg2.transform.position = player1.transform.position;
		
		} else if (isTouching3 == true) {
			inFrontBox.enabled = true;
			pg3.transform.position = player1.transform.position;

		} else if (isTouching4 == true) {
			inFrontBox.enabled = true;
			pg4.transform.position = player1.transform.position;
		
		}

		if (counttoWin >= 4) {
			timer += Time.deltaTime;
			if (timer >= countDown) {

				SceneManager.LoadScene (0, LoadSceneMode.Single);

			}

		}

	}
}
