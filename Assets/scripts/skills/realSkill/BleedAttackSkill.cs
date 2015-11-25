using UnityEngine;
using System.Collections;

public class BleedAttackSkill : AttackSkill {

    //Damage per ticks.
    public int DamagePerTick;
    //The number of ticks the damage will be applied.
    public int numberOfTicks;
    //The time between each tick.
    public float timeBetweenTick;

    //Total damage = damagePerTick * numberOfTicks
    //Total time = timeBetweenTick * numberOfTicks


    protected override void action(Player player) {
        //We attack then we apply the bleed.
        base.action(player);
        PlayerManager.getInstance().getOtherPlayer(player).transform.gameObject.AddComponent<DamageOverTime>();
        PlayerManager.getInstance().getOtherPlayer(player).transform.gameObject.GetComponent<DamageOverTime>().DamagePerTick = this.DamagePerTick;
        PlayerManager.getInstance().getOtherPlayer(player).transform.gameObject.GetComponent<DamageOverTime>().numberOfTicks = this.numberOfTicks;
        PlayerManager.getInstance().getOtherPlayer(player).transform.gameObject.GetComponent<DamageOverTime>().timeBetweenTick = this.timeBetweenTick;
    }
}
