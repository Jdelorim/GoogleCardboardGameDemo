using UnityEngine;
using System.Collections;

public class PowerBarrelScript : MonoBehaviour {
	 public GameObject me;
	 GameObject holder;
	 GameObject Player;
	 GB_playerScript PS;

	 Rigidbody RBpg;
	 BoxCollider BC;

	bool alreadyCarried = false;


	void OnTriggerEnter (Collider col){
		if (col.gameObject.CompareTag("Player") && PS.isCarryPG == false) {

		
				PS.isCarryPG = true;
				


		}


	}
	void Start () {
		
		holder = GameObject.Find ("objectholder");
		Player = GameObject.FindGameObjectWithTag ("Player");
		PS = Player.GetComponent <GB_playerScript> ();
		RBpg = this.GetComponent<Rigidbody> ();
		BC = this.GetComponent<BoxCollider> ();
	
	}


	void Update () {
		
		if (PS.isCarryPG == true) {
			me.gameObject.transform.position = holder.gameObject.transform.position;
		} 
		if (PS.hitTarget == true) {
			BC.isTrigger = false;
			RBpg.isKinematic = false;
			
			PS.isCarryPG = false;

		}


	}
}
