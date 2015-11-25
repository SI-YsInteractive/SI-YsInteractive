using UnityEngine;
using System.Collections;

public class PercentageProtection : Protection {

    /**Reduce special damage by a percent*/
    public float specialAttackPercentProtection;

    /**Reduce standard damage by a percent*/
    public float standardAttackPercentProtection;

    /**Reduce damage by a percent.*/
    public override float reduce(float damage, DamageType dType) {
        if (dType == DamageType.SPECIAL) {
            return damage * specialAttackPercentProtection;
        } else if (dType == DamageType.STANDARD) {
            return damage * standardAttackPercentProtection;
        } else {
            return damage;
        }
    }
}
