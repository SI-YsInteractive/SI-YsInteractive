using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    /**The starting mana of the player, or, ingame, the maximum mana of the player*/
    public float startingMana;
    /**The starting life of the player, or, ingame, the maximum life of the player*/
    public float startingLife;

    //Current mana.
    protected float mana;
    //Current life.
    protected float life;
    //The player number. It will be the index in the player manager.
    public int playerNumber;

    public float getMana() {
        return mana;
    }

    public void removeMana(float minus) {
        mana = Mathf.Clamp(mana-minus, 0, startingMana);
    }

    public void addMana(float add) {
        mana = Mathf.Clamp(mana + add, 0, startingMana);

    }

    public float getLife() {
        return life;
    }

    public void removeLife(float minus) {
        life = Mathf.Clamp(life - minus, 0, startingLife);
    }

    public void addLife(float add) {
        life = Mathf.Clamp(mana + add, 0, startingLife);
    }

    // Use this for initialization
    void Start() {
        mana = startingMana;
        life = startingLife;
    }

    // Update is called once per frame
    void Update() {

    }
}
