using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthOrbit : MonoBehaviour
{
    public static EarthOrbit instance { get; private set; }

    [SerializeField] private float rotSpeed = 0f;
    private float minValue = 0;
    private float maxValue = 0;
    private Vector3 lastFwd;
    private float curAngleY = 0f;
    private int turn = 0;

    private void Start()
    {
        lastFwd = transform.forward;
    }

    void Update()
    {
        if (Time.timeScale == 0) {  return; }
        rotSpeed = Mathf.Clamp(rotSpeed, minValue, maxValue);
        transform.Rotate(0, rotSpeed, 0);
        AffectYear();

        if (PlayerInputManager.instance == null)
            return;

        if (PlayerInputManager.instance.fastForward)
        {
            minValue = 0f;
            maxValue = 5f;
            rotSpeed += Time.deltaTime;
        }
        else
        {
            if(minValue == 0f && maxValue == 5f)
                rotSpeed -= Time.deltaTime * 5f;
        }

        if (PlayerInputManager.instance.rewind)
        {
            minValue = -5f;
            maxValue = 0f;
            rotSpeed -= Time.deltaTime;
        }
        else
        {
            if (minValue == -5f && maxValue == 0f)
                rotSpeed += Time.deltaTime * 5f;
        }
    }

    void AffectYear()
    {
        Vector3 curFwd = transform.forward;

        float ang = Vector3.Angle(curFwd, lastFwd);
        if (ang > 0.01)
        {
            if (Vector3.Cross(curFwd, lastFwd).y < 0) ang = -ang;
            curAngleY += ang;
            lastFwd = curFwd;
        }

        if (Calendar.instance == null)
            return;

        if(curAngleY <= -360)
        {
            curAngleY += 360;
            Calendar.instance.IncrimentYear();
        }

        if (curAngleY >= 360)
        {
            curAngleY -= 360;
            Calendar.instance.DecrementYear();
        }
    }
}
