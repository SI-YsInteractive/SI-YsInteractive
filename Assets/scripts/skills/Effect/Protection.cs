﻿using UnityEngine;
using System.Collections;

public abstract class Protection : MonoBehaviour{

    public bool disableByHit;
    public bool disableByTime;

    /**The starting time before the protection wears off*/
    public float startingTimeLeft = 1f;

    /**The number of hits left before the protection wears off.*/
    protected int hitLeft;
    /**The time left before the protection wears off.*/
    protected float timeLeft;

	void Start() {
		timeLeft = startingTimeLeft;
	}




    void Update() {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            GetComponent<Player>().protections.Remove(this);
            Destroy(this);

        }
    }


    public abstract float reduce(float damage, DamageType dType, Player player);
}
