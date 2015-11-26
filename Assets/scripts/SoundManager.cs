using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioSource audioSource;

    public static SoundManager instance = null;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    //Return the public instance of the manager.
    public static SoundManager getInstance() {
        if (instance == null) {
            instance = GameObject.FindObjectOfType(typeof(SoundManager)) as SoundManager;

            if (instance == null) {
                GameObject go = new GameObject("SkillManager");
                instance = go.AddComponent<SoundManager>();
            }
        }
        return instance;
    }

    /**Play a sound*/
    public void playSound(AudioClip audioClip, float volume) {
		GameObject sound = new GameObject ();
		sound.AddComponent<AudioSource> ();
		sound.GetComponent<AudioSource> ().clip = audioClip;
		sound.GetComponent<AudioSource> ().volume = volume;
		sound.GetComponent<AudioSource> ().Play();
		Destroy (sound, audioClip.length);
    }
}
