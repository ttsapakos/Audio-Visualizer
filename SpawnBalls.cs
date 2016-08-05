using UnityEngine;
using System.Collections;

public class SpawnBalls : MonoBehaviour {

	public GameObject ball;
	public float spawnRate;

	void Start () {
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn() {
		while (true) {
			float randX = Random.Range(-1f, 1f);
			float randZ = Random.Range(-1f, 1f);
			Vector3 spawnPos = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randZ);
			Instantiate (ball, spawnPos, Quaternion.identity);
			yield return new WaitForSeconds (spawnRate);
		}
	}
}
