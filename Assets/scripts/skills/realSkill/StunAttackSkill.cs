using UnityEngine;
using System.Collections;

public class StunAttackSkill : AttackSkill {

    //TODO, replace skilllockAttackskill duration to float.
    public float lockDuration;

    protected override void action(Player player) {
        //We attack then we lock all skills.
        base.action(player);
        PlayerManager.getInstance().sendLockAllSkills(PlayerManager.getInstance().getOtherPlayer(player), lockDuration);
    }
}
