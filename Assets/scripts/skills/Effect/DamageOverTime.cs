using UnityEngine;
using System.Collections;

public class DamageOverTime : MonoBehaviour {

	public float DamagePerTick;
	public int numberOfTicks;
	public float timeBetweenTick;
	// Use this for initialization
	void Start () {
		Destroy (this, timeBetweenTick * (numberOfTicks+1));
		InvokeRepeating ("sendDamage",timeBetweenTick, timeBetweenTick);
	}
	
	void sendDamage()
	{
		GetComponent<Player> ().removeLife (DamagePerTick);
	}
}
