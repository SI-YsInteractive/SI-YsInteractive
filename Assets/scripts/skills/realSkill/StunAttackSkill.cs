using UnityEngine;
using System.Collections;

public class StunAttackSkill : AttackSkill {

    public bool random = false;

    //TODO, replace skilllockAttackskill duration to float.
    public float lockDuration;

    protected override void action(Player player) {
        //We attack then we lock all skills.
		if (random)
			sound = SkillManager.instance.foudre;
		else
			sound = SkillManager.instance.poison;
        base.action(player);
        if(random)
            PlayerManager.getInstance().sendlockRandomSkill(PlayerManager.getInstance().getOtherPlayer(player), lockDuration);
        else
            PlayerManager.getInstance().sendLockAllSkills(PlayerManager.getInstance().getOtherPlayer(player), lockDuration);
    }
}
