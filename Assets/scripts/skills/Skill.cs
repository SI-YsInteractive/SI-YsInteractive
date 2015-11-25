﻿using UnityEngine;
using System.Collections;

/**A general skill, that players can use.
    @Author Thomas Dubrulle Benjamin Lefevre*/
public abstract class Skill : MonoBehaviour{

    /**The life cost of the skill per . If negative, it becomes a mana gain.*/
    public float lifeCost;
    /**The total charge time of the skill.*/
    public float chargeTime;
    /**The chargeMultiplier of the skill, if it is charged.*/
    public float boostedChargeMultiplier;

    //Current charge time in seconds.
    public float currentCharge;

    /**********************************************************/

    /**Tell if the skill is locked by a duration debuff, or not.*/
    public bool locked = false;
    //Current lock time. if <= 0 : not locked; otherwise locked.
    protected float lockTime = 0;

    /**********************************************************/

    /**Tell if the skill is slowed*/
    public bool slowed = false;
    /**Slow time duration*/
    protected float slowTime = 0;
    /**Slow charge multiplier*/
    protected float slowChargeMultiplier = 1;

    /**********************************************************/

    /*Make the action
     *@param player the source of the action.
     */
    protected abstract void action(Player player);
    

    /**Update the skill if the player is charging it*/
    public abstract void update(Player player, float passedTime, float boostPower);

    /**Drain the charge of the skill*/
    public abstract void drainCharge(float passedTime);

    /**Lock the skill for x time, making it unchargeable nor activable.*/
    public void lockSkill(float lockDuration) {
        //We check whichever has the highest time and take it.
        lockTime = lockTime > lockDuration? lockTime : lockDuration;
        //Useful for the player to know whether the skill should be drained or not.
        locked = true;
    }

    /**Slow the skill charge speed for x time, making it slower to charge and activate.*/
    public void slowSkill(float slowDuration, float slowPower) {
        slowTime = slowDuration;
        slowChargeMultiplier = Mathf.Min(slowPower, slowChargeMultiplier);
        slowed = true;
    }
}
