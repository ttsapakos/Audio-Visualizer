using UnityEngine;
using System.Collections;

public class DestroyByPosition : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < -1) {
			GameObject.Destroy(this.gameObject);
		}
	}
}
