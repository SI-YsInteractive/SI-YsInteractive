using UnityEngine;
using System.Collections;

public abstract class Skill : MonoBehaviour{

    /**The life cost of the skill per . If negative, it becomes a mana gain.*/
    public float lifeCost;
    /**The total charge time of the skill.*/
    public float chargeTime;
    /**The chargeMultiplier of the skill, if it is charged.*/
    public float boostedChargeMultiplier;

    //Indicate if the skill is charging (to be activated) or not.
    protected bool charging;

    //Current charge time in seconds.
    public float currentCharge;

    protected abstract void action(Player player);
    

    /**Update the skill if the player is charging it*/
    public abstract void update(Player player, float passedTime, float boostPower);
}
