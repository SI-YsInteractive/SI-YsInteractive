using UnityEngine;
using System.Collections;
using System;

/**Skill, or state, where the player is resting to regain his mana.
*
*/
public class RestSkill : Skill {

    //No action is made in this state.
    protected override void action(Player player) { }

    //No action is made in this state.
    public override void activate(Player player) { }

    //No time is counted in this state.
    protected override void updateTime(float passedTime) { }

    //We add mana instead of draining it.
    public override void charge(Player player, float passedTime) {
        player.addMana((manaCost / chargeTime) * passedTime);
    }
}
