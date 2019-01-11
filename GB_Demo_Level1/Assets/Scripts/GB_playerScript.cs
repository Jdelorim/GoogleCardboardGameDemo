using UnityEngine;
using System.Collections;

public class GB_playerScript : MonoBehaviour {


	public GameObject myPrefab;

	public bool isCarryPG = false;
	public bool hitTarget = false;


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("powerPad") && isCarryPG == true) {
			
			hitTarget = true;


		}

	}

	void Start () {

	}
	

	void Update () {
	
	}
}
