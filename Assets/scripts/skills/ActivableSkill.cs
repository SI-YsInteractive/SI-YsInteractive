using UnityEngine;
using System.Collections;
using System;

/**A skill that can be activated. For instance an attack.*/
public abstract class ActivableSkill : Skill {

    /**Update the charge of the skill. If the skill is charged, it is activated and the charge resetted to 0.
    * @param player the player owning the skill
    * @param passedTime the time passed since the last call to update (Time.deltaTime)
    * @param chargePower the charge power used to speed up the charge (0 = no boost; anything > 0 = boosted)*/
    public override void update(Player player, float passedTime, float chargePower) {
        if (!locked) {
            player.removeLife(passedTime * chargePower * SkillManager.getInstance().boostLifeCostPerSecond);
            currentCharge += ((passedTime + (passedTime * chargePower * boostedChargeMultiplier)) * slowChargeMultiplier);
            if (currentCharge >= chargeTime) {
                action(player);
                currentCharge = 0;
            }
        } else {
            lockTime -= passedTime;
            if (lockTime <= 0) locked = false;
        }
        //Slow status.
        if(slowed) {
            slowTime -= passedTime;
            if (slowTime <= 0) {
                slowed = false;
                //Setting back to 1 (no speed change)
                slowChargeMultiplier = 1f;
            }
        }
    }

    public override void drainCharge(float passedTime) {
        //At least 0 to avoid negative charges.
		Debug.Log(SkillManager.instance.drainMultiplier);
        currentCharge = Mathf.Max(currentCharge - (passedTime * SkillManager.instance.drainMultiplier), 0);
    }

}
