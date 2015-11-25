using UnityEngine;
using System.Collections;

public class SlowAttackSkill : AttackSkill {

    /**The slow duration, in seconds.*/
    public float slowDuration;
    /**The slow power multiplier. 0 = charge is stopped. 1 = charge is at normal speed.*/
    public float slowPowerMultiplier;


    protected override void action(Player player) {
        //We attack then we lock all skills.
        base.action(player);
        PlayerManager.getInstance().sendSlowAllSkills(PlayerManager.getInstance().getOtherPlayer(player), slowDuration, slowPowerMultiplier);
    }
}
