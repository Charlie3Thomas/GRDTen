using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance { get; private set; }

    // Inputs
    public float inputX;
    public float inputY;
    public bool fireRay;
    public bool chargeShot;
    public bool release;
    public bool flyDown;
    public bool flyUp;
    public bool fastForward;
    public bool rewind;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    void UpdateInput()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        fireRay = Input.GetKeyDown(KeyCode.Mouse0);
        chargeShot = Input.GetKey(KeyCode.Mouse0);
        release = Input.GetKeyUp(KeyCode.Mouse0);
        flyUp = Input.GetKey(KeyCode.Space);
        flyDown = Input.GetKey(KeyCode.LeftControl);
        fastForward = Input.GetKey(KeyCode.E);
        rewind = Input.GetKey(KeyCode.Q);
    }
}
