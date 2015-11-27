using UnityEngine;
using System.Collections;
using System;

/**Skill that is a simple attack.
*
*/
public class AttackSkill : ActivableSkill{

    public float damages;
    public DamageType dType;

    private Player p;

    protected override void action(Player player) {
        p = player;
        Invoke("launchAttack", 0.1f);
    }

    public void launchAttack()
    {
		if (sound == null)
			sound = SkillManager.instance.swordAttack;
        PlayerManager.getInstance().sendDamage(PlayerManager.getInstance().getOtherPlayer(p), damages, dType);
        p.playAnimationAttack();
		SoundManager.instance.playSound(sound,1f);
    }
}
