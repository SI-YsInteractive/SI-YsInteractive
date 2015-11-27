using UnityEngine;
using System.Collections;
using System;

/**A skill that can be activated. For instance an attack.*/
public abstract class ActivableSkill : Skill {

    public AudioClip soundOnActivation;
    public float soundVolume;

    /**Update the charge of the skill. If the skill is charged, it is activated and the charge resetted to 0.
    * @param player the player owning the skill
    * @param passedTime the time passed since the last call to update (Time.deltaTime)
    * @param chargePower the charge power used to speed up the charge (0 = no boost; anything > 0 = boosted)*/
    public override void update(Player player, float passedTime, float chargePower) {
		Debug.Log (locked);
        if (!locked) {
            player.removeLife(passedTime * chargePower * SkillManager.getInstance().boostLifeCostPerSecond);
            currentCharge += ((passedTime + (passedTime * chargePower * SkillManager.getInstance().BoostedChargeMultiplier)) * slowChargeMultiplier);
            if (currentCharge >= chargeTime) {
                action(player);
				if(soundOnActivation)
                	SoundManager.getInstance().playSound(soundOnActivation, soundVolume);
                currentCharge = 0;
            }
        } 
        
    }

    public override void drainCharge(float passedTime) {
        //At least 0 to avoid negative charges.
        currentCharge = Mathf.Max(currentCharge - (passedTime * SkillManager.instance.drainMultiplier), 0);
    }

}
