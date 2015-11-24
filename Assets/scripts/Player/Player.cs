using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    /**The starting life of the player, or, ingame, the maximum life of the player*/
    public float startingLife;
    
    //Current life.
    protected float life;
    //The player number. It will be the index in the player manager.
    public int playerNumber;

    public List<Skill> skills;

    public float getLife() {
        return life;
    }

    public void takeDamage(DamageType dType, float damages) {
        removeLife(damages);
    }

    public void removeLife(float minus) {
        life = Mathf.Clamp(life - minus, 0, startingLife);
    }

    public void addLife(float add) {
        life = Mathf.Clamp(life + add, 0, startingLife);
    }

    // Use this for initialization
    void Start() {
        life = startingLife;
    }

    // Update is called once per frame
    void Update() {
        foreach(Skill sk in skills) {
            //Todo
        }
    }
}
