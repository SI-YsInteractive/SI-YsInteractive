using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = ""+GameObject.Find("Player1").GetComponent<PlayerMovement>().rotationSpeed;
	}
}
