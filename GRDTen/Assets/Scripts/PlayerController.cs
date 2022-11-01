using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private GameObject xSpot;
    [SerializeField] private float playerSpeed;
    [SerializeField] private LayerMask country;
    [SerializeField] private GameObject outlines;
    private Transform prevOutline;
    private float speedMult = 1f;
    private Rigidbody rb;

    // inputs
    private float inputX;
    private float inputY;
    private bool fireRay;
    private bool sprint;
    private bool flyDown;
    private bool flyUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();

        if (outlines == null)
            return;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << country))
        {
            lr.enabled = true;
            lr.SetPosition(0, orientation.transform.position);
            lr.SetPosition(1, hit.point);
            if(xSpot != null)
            {
                xSpot.transform.position = hit.point;
                xSpot.transform.up = hit.normal;
                xSpot.SetActive(true);
            }
            if (fireRay)
            {
                if (prevOutline != null)
                    prevOutline.GetComponent<Renderer>().material.SetInt("_isHighlighted", 0);

                outlines.transform.GetChild(hit.transform.GetSiblingIndex()).GetComponent<Renderer>().material.SetInt("_isHighlighted", 1);
                prevOutline = outlines.transform.GetChild(hit.transform.GetSiblingIndex());
            }
        }
        else
        {
            lr.SetPosition(0, orientation.transform.position);
            lr.SetPosition(1, orientation.transform.forward * 1000);
            if (xSpot != null)
                xSpot.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (sprint)
            speedMult = 2;
        else
            speedMult = 1;

        Vector3 moveDir = orientation.forward * inputY + orientation.right * inputX;
        rb.AddForce(moveDir.normalized * playerSpeed * speedMult, ForceMode.Acceleration);

        if (flyDown)
            rb.AddForce(Vector3.down * playerSpeed * speedMult, ForceMode.Acceleration);

        if (flyUp)
            rb.AddForce(Vector3.up * playerSpeed * speedMult, ForceMode.Acceleration);
    }

    void UpdateInput()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        fireRay = Input.GetKeyDown(KeyCode.Mouse0);
        sprint = Input.GetKey(KeyCode.LeftShift);
        flyUp = Input.GetKey(KeyCode.Space);
        flyDown = Input.GetKey(KeyCode.LeftControl);
    }
}
