using UnityEngine;
using System.Collections;

public class CriticalAttackSkill : AttackSkill {

	public float criticalDamage;
	
	protected override void action(Player player) {
		//We attack then we lock the skill.
		Player other = PlayerManager.getInstance ().getOtherPlayer (player);
		bool stun = false;
		foreach (Skill skill in other.skills) 
		{
			if(skill.slowed || skill.locked)
				continue;
			else
			{
				PlayerManager.getInstance().sendDamage(other, damages, dType);
				return;
			}

		}
		PlayerManager.getInstance().sendDamage(other, criticalDamage, dType);
	}
}
