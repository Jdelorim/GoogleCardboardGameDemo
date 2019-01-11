using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {

    void Update () 
	{
		transform.Rotate (new Vector3(15, 0, 0)*Time.deltaTime);
	
	}
}
