using UnityEngine;
using System.Collections;

public class FixedProtection : Protection {

    /**Reduce special damage by a fixed value*/
    public float specialAttackFixedProtection;

    /**Reduce standard damage by a fixed value*/
    public float standardAttackFixedProtection;

    /**Reduce damage by a percent.*/
    public override float reduce(float damage, DamageType dType, Player player) {
        if (dType == DamageType.SPECIAL) {
            return Mathf.Max(damage - specialAttackFixedProtection,0f);
        } else if (dType == DamageType.STANDARD) {
			return Mathf.Max(damage - standardAttackFixedProtection,0f);
        } else {
            return damage;
        }
    }
}
