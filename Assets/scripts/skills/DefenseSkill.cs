using UnityEngine;
using System.Collections;

public class DefenseSkill : ActivableSkill {

    public Protection protectionType;

    protected override void action(Player player) {
        player.addProtection(protectionType);
    }

}
