using UnityEngine;
using System.Collections;

public class CriticalAttackSkill : AttackSkill {

	public float criticalDamage;
	
	protected override void action(Player player) {
		//We attack then we lock the skill.
		base.action(player);
		Player other = PlayerManager.getInstance ().getOtherPlayer (player);
		foreach (Skill skill in other.skills) 
		{
			if(skill.slowed || skill.locked)
				continue;
			else
			{
				return;
			}

		}
		PlayerManager.getInstance().sendDamage(other, criticalDamage-damages, dType);
	}
}
