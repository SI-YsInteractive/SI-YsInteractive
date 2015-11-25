using UnityEngine;
using System.Collections;

/**A more elaborated attack skill, that deals damage AND locks a random ennemy skill
*A skill locked cannot be charged or activated, and it will be drained slowly (as if unmaintained) until the debuff wears off.*/
public class SkillLockAttackSkill : AttackSkill {

    public float lockDuration;

    protected override void action(Player player) {
        //We attack then we lock the skill.
        base.action(player);
        PlayerManager.getInstance().sendlockRandomSkill(PlayerManager.getInstance().getOtherPlayer(player), lockDuration);
    }

}
