using UnityEngine;
using System.Collections;

public class SpectrumAnalyzer : MonoBehaviour {

	public float multiplier;
	public int numDivisions;
	private int numCubes;
	private float tempValue;
	private int currValue;
	private float[] spectrum;

	void Update () {
		spectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.Hamming);

		GameObject[] cubes = GameObject.FindGameObjectsWithTag ("Cube");
		numCubes = cubes.Length;
		BoxCollider tempCollider;

		for (int p = 0; p < numCubes; p++) {
			tempValue = AddValues(p);
			cubes[p].transform.localScale = new Vector3 (cubes[p].transform.localScale.x, multiplier * tempValue, transform.localScale.z);
			tempCollider = (BoxCollider)cubes[p].GetComponent("BoxCollider");
			tempCollider.size = new Vector3 (cubes[p].transform.localScale.x, multiplier * tempValue, transform.localScale.z);
		}
	}

	private float AddValues(int p) {
		float result = 0;
		for (int i = (int)(p * Mathf.Floor((1024/numDivisions) / numCubes)); i < ((p + 1) * Mathf.Floor((1024/numDivisions) / numCubes)); i++) {
			result += spectrum[i];
		}
		return result;
	}
}
