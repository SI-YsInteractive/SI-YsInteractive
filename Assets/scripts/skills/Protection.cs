using UnityEngine;
using System.Collections;

public abstract class Protection : MonoBehaviour{

    public int hitLeft;
    public float timeLeft;

    public bool isDisabled() {
        return timeLeft <= 0 || hitLeft <= 0;
    }

    void Update() {
        timeLeft -= Time.deltaTime;
    }

    public abstract float reduce(float damage, DamageType dType);
}
