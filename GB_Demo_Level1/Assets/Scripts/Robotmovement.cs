using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Robotmovement : MonoBehaviour {
	Transform playerT;

	public Transform[] points;

	int destPoint = 0;
   
	NavMeshAgent navA;

	public float attackDistance;
    
    float acceleration1 = 4f;


	public string levelchanger2;
	GameObject player;


	GLOBALS glob;



	void Start () {
		playerT = GameObject.FindGameObjectWithTag ("Player").transform;
		player = GameObject.FindGameObjectWithTag ("Player");
		glob = player.gameObject.GetComponent<GLOBALS> ();


		navA = GetComponent<NavMeshAgent> ();
		navA.autoBraking = false;
		glob.Espeed = 1.5f;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("Player")) {
			restartCurrentScene ();
		}

	}
	void restartCurrentScene(){
		SceneManager.LoadSceneAsync (levelchanger2, LoadSceneMode.Single);

	}

	void distance(){
		float dist = Vector3.Distance(playerT.position, transform.position);
		//print("Distance to other: " + dist);
		print (glob.Espeed);
		if (dist >= 10.0f) {
			glob.Espeed = Random.Range(3.0f,4.0f);
		} else if (dist >= 5.0f) {
			glob.Espeed = Random.Range(4.0f,5.0f);
		} else {
			glob.Espeed = Random.Range(5.0f,6.0f);
		}

	}
	void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0)
			return;

		// Set the agent to go to the currently selected destination.
		navA.destination = points[destPoint].position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
	}

	void Update () {


		float dist = Vector3.Distance(playerT.position, transform.position);
		if (glob.ignore == false) {
			if (dist <= attackDistance) {

				glob.Espeed = Random.Range (3.5f, 4.5f);
				navA.SetDestination (playerT.position);

			} else {

				glob.Espeed = Random.Range (1.5f, 3.0f);
				if (navA.remainingDistance < 0.5f) {
					GotoNextPoint ();
				}

			}
		} else {
			glob.Espeed = 0f;
		}



		
		navA.speed = glob.Espeed;
		navA.acceleration = acceleration1;
	
	}
}
