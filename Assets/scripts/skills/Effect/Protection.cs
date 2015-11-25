using UnityEngine;
using System.Collections;

public abstract class Protection : MonoBehaviour{

    public bool disableByHit;
    public bool disableByTime;

    /**The starting number of hits before the protection wears off*/
    public int startingHitLeft;
    /**The starting time before the protection wears off*/
    public float startingTimeLeft;

    /**The number of hits left before the protection wears off.*/
    protected int hitLeft;
    /**The time left before the protection wears off.*/
    protected float timeLeft;



    public bool isDisabled() {
        return (disableByTime && timeLeft <= 0) || (hitLeft <= 0 && disableByHit);
    }

    void Update() {
        if(disableByTime) timeLeft -= Time.deltaTime;
    }

    void Start() {
        hitLeft = startingHitLeft;
        timeLeft = startingTimeLeft;
    }

    public abstract float reduce(float damage, DamageType dType, Player player);
}
