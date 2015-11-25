using UnityEngine;
using System.Collections;

public class platformTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider collision)
	{
		if (collision.tag == "Player")
			transform.parent.gameObject.GetComponent<plateform> ().setPlayerSkill (collision.gameObject);

	}

	void OnTriggerExit(Collider collision)
	{
		if (collision.tag == "Player")
			transform.parent.gameObject.GetComponent<plateform> ().playerLeavePlatform (collision.gameObject);
		
	}

}
