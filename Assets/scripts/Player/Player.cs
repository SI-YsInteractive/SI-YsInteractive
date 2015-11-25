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

    //List of skills of the player.
    public List<Skill> skills;

    //List of platform of the player.
    public List<plateform> plateforms;

	public Skill currentSkill;

    //Return player's life.
    public float getLife() {
        return life;
    }

    /**Make the player take damage (after reducing the damages)*/
    public void takeDamage(DamageType dType, float damages) {
        //TODO reduce damages by defences.
        removeLife(damages);
    }

    /**Remove some part of player's life*/
    public void removeLife(float minus) {
        life = Mathf.Clamp(life - minus, 0, startingLife);
    }

    /**Add some life to the player's life.*/
    public void addLife(float add) {
        life = Mathf.Clamp(life + add, 0, startingLife);
    }

    // Use this for initialization
    void Start() {
        life = startingLife;
    }

    /**Get a random platform.*/
    public plateform getRandomPlatform()
    {
        return plateforms[Random.Range(0, plateforms.Count)];
    }

    // Update is called once per frame
    void Update() {
        foreach(Skill sk in skills) {
            sk.update(this, Time.deltaTime, 1);
        }
    }
}
