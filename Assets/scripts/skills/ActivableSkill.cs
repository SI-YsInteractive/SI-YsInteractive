using UnityEngine;
using System.Collections;
using System;

/**A skill that can be activated. For instance an attack.*/
public abstract class ActivableSkill : Skill {



    /**Update the charge of the skill. If the skill is charged.*/
    public override void update(Player player, float passedTime, float chargePower) {
        player.removeLife(passedTime * chargePower);
        currentCharge += (passedTime * chargePower * boostedChargeMultiplier);
        if (currentCharge >= chargeTime) {
            action(player);
            currentCharge = 0;
        }
    }
}
