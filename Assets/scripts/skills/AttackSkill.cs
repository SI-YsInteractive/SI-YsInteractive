using UnityEngine;
using System.Collections;
using System;

/**Skill that is an simple attack.
*
*/
public class AttackSkill : ActivableSkill{

    protected override void action(Player player) {
        PlayerManager.getInstance().sendDamage(PlayerManager.getInstance().getOtherPlayer(player));
    }

}
