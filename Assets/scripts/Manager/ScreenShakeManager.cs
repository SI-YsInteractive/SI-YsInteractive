using UnityEngine;
using System.Collections;

public class ScreenShakeManager : MonoBehaviour {

    //The public instance.
    public static ScreenShakeManager instance;

    public Camera controlledCamera;
    
    public int dureeMaxTremblement;
    protected int dureeTremblement;
    public float forceTremblementX;
    public float forceTremblementY;
    protected Vector3 positionCam;
    protected float fTremblements;
    protected bool finTremblement;

    // Use this for initialization
    void Start() {
        fTremblements = 0;
        finTremblement = true;
        positionCam = controlledCamera.transform.position;
    }

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    //Return the public instance of the manager.
    public static ScreenShakeManager getInstance() {
        if (instance == null) {
            instance = GameObject.FindObjectOfType(typeof(ScreenShakeManager)) as ScreenShakeManager;

            if (instance == null) {
                GameObject go = new GameObject("screenShakeManager");
                instance = go.AddComponent<ScreenShakeManager>();
            }
        }
        return instance;
    }

    // Update is called once per frame
    void Update() {
        //Test for shakings.
        if (dureeTremblement > 0) {
            float ratioTremblement = ((float) dureeTremblement) / ((float) dureeMaxTremblement);
            float decalX = Random.value * forceTremblementX * (ratioTremblement * 3 - ratioTremblement * 2);
            float decalY = Random.value * forceTremblementY * (ratioTremblement * 3 - ratioTremblement * 2);
            controlledCamera.transform.position = new Vector3(positionCam.x + decalX, positionCam.y + decalY, positionCam.z);
            dureeTremblement--;
            if (dureeTremblement <= 0) {
                fTremblements = 0f;
                finTremblement = true;
            }
        } else {
            if (finTremblement) {
                controlledCamera.transform.position = positionCam;
                finTremblement = false;
            }
        }
    }
    
    public void AddCameraShake(float facteurTremblements) {
        dureeTremblement = dureeMaxTremblement;
        if (facteurTremblements > fTremblements) {
            fTremblements = facteurTremblements;
        }

    }
}
