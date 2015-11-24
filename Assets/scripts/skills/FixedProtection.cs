using UnityEngine;
using System.Collections;

public class FixedProtection : Protection {

    /**Reduce special damage by a fixed value*/
    public float specialAttackFixedProtection;

    /**Reduce standard damage by a fixed value*/
    public float standardAttackFixedProtection;

    /**Reduce damage by a percent.*/
    public override float reduce(float damage, DamageType dType) {
        if (dType == DamageType.SPECIAL) {
            return damage - specialAttackFixedProtection;
        } else if (dType == DamageType.STANDARD) {
            return damage - standardAttackFixedProtection;
        } else {
            return damage;
        }
    }
}
