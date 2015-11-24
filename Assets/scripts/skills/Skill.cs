using UnityEngine;
using System.Collections;

public abstract class Skill : MonoBehaviour{

    /**The total mana cost of the skill. If negative, it becomes a mana gain.*/
    public float manaCost;
    /**The total charge time of the skill.*/
    public float chargeTime;
    /**The total chargeMultiplier of the skill.*/
    public float chargeMultiplier;

    //Current charge time in second.
    protected float currentCharge;

    protected abstract void action(Player player);

    public abstract void activate(Player player);

    protected abstract void updateTime(float passedTime);

    /**Update the charge of the skill. If the skill is charged.*/
    public abstract void charge(Player player, float passedTime);
}
