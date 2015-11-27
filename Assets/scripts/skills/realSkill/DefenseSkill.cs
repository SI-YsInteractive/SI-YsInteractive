using UnityEngine;
using System.Collections;

/**A skill used to create a protection around the player.*/
public class DefenseSkill : ActivableSkill {

    public ProtectionType protectionType;

    public float protectionDuration;

    //slowing protection
    public float slowDuration;
    public float slowPowerMultiplier;
    // counter attack protection
    public float damages;
    public DamageType dType;
    // fixed protection
    public float specialAttackFixedProtection;
    public float standardAttackFixedProtection;


    private Player p;

    protected override void action(Player player) {
        Protection protection;
        switch(protectionType)
        {
            case ProtectionType.BouclierBasique:
            case ProtectionType.Esquive:
            case ProtectionType.BouclierFort:
                FixedProtection bouclierFort = player.gameObject.AddComponent<FixedProtection>();
                bouclierFort.startingTimeLeft = protectionDuration;
                bouclierFort.specialAttackFixedProtection = specialAttackFixedProtection;
                bouclierFort.standardAttackFixedProtection = standardAttackFixedProtection;
                protection = bouclierFort;
                break;
            case ProtectionType.ToileProtectrice:
                SlowingWebProtection toileProtectrice = player.gameObject.AddComponent<SlowingWebProtection>();
                toileProtectrice.startingTimeLeft = protectionDuration;
                toileProtectrice.specialAttackFixedProtection = specialAttackFixedProtection;
                toileProtectrice.standardAttackFixedProtection = standardAttackFixedProtection;
                toileProtectrice.slowDuration = slowDuration;
                toileProtectrice.slowPowerMultiplier = slowPowerMultiplier;
                protection = toileProtectrice;
                break;
            case ProtectionType.ContreAttaque:
                CounterAttackFixedProtection contreAttaque = player.gameObject.AddComponent<CounterAttackFixedProtection>();
                contreAttaque.startingTimeLeft = protectionDuration;
                contreAttaque.specialAttackFixedProtection = specialAttackFixedProtection;
                contreAttaque.standardAttackFixedProtection = standardAttackFixedProtection;
                contreAttaque.damages = damages;
                protection = contreAttaque;
                break;
            default:
                Debug.Log("La protection n'a pas fonctionné cf DefenseSkill");
                return;


        }
        player.addProtection(protection);
        player.playDefenseAnimation();
    }


}
