using UnityEngine;
using System.Collections;
using System;

/**A skill that can be activated. For instance an attack.*/
public abstract class ActivableSkill : Skill {

    public override void activate(Player player) {
        if (currentCharge >= chargeTime) {
            action(player);
            currentCharge = 0;
        }
    }

    protected override void updateTime(float passedTime) {
        currentCharge += (passedTime * chargeMultiplier);
    }

    /**Update the charge of the skill. If the skill is charged.*/
    public override void charge(Player player, float passedTime) {
        player.removeMana((manaCost / chargeTime) * (passedTime * chargeMultiplier));
    }
}
