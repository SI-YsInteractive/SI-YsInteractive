using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Player pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        pl.transform.position = new Vector3(0f, 0f, 0f);
        GetComponent<Text>().text = pl.name + " Win !";
	} 
	
	// Update is called once per frame
	void Update () {
	
	}
}
