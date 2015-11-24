using UnityEngine;
using System.Collections;

/**A skill used to create a protection around the player.*/
public class DefenseSkill : ActivableSkill {

    public Protection protectionType;

    protected override void action(Player player) {
        player.addProtection(protectionType);
    }

}
