using UnityEngine;
using System.Collections;
using System;

public class SlowingWebProtection : FixedProtection
{
    /**The slow duration, in seconds.*/
    public float slowDuration;
    /**The slow power multiplier. 0 = charge is stopped. 1 = charge is at normal speed.*/
    public float slowPowerMultiplier;

    public override float reduce(float damage, DamageType dType, Player player) {
        PlayerManager.getInstance().sendSlowAllSkills(PlayerManager.getInstance().getOtherPlayer(player), slowDuration, slowPowerMultiplier);
        return base.reduce(damage, dType, player);
    }
}
