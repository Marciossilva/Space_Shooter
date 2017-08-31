using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit (Collider Other){
		Destroy (Other.gameObject);
	
	}


}
