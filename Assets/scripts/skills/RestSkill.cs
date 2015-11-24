using UnityEngine;
using System.Collections;
using System;

/**Skill, or state, where the player is resting to regain his mana.
*
*/
public class RestSkill : Skill {

    //TTODO
    //No action is made in this state.
    protected override void action(Player player) { }




    //We add mana instead of draining it.
    public override void update(Player player, float passedTime, float chargePower) {

    }
}
