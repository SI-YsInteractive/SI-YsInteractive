using UnityEngine;
using System.Collections;

public class CounterAttackFixedProtection : FixedProtection {

    //CounterAttack's damage.
    public float damages;
    //Damage type of the counterAttack.
    public DamageType dType;

    public override float reduce(float damage, DamageType dType, Player player) {
        PlayerManager.getInstance().sendDamage(PlayerManager.getInstance().getOtherPlayer(player), damages, dType);
        return base.reduce(damage, dType, player);
    }
}
