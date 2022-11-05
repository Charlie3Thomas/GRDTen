using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player Stuff
    private Rigidbody rb;
    [SerializeField] private Transform orientation;
    [SerializeField] private float playerSpeed;
    private float speedMult = 1f;

    // Aiming and Shooting Stuff
    [SerializeField] private LineRenderer lr;
    [SerializeField] private GameObject xSpot;
    [SerializeField] private GameObject extractor;
    private float chargeTimer = 0.0f;
    private float chargeAmount = 2.0f;
    [SerializeField] private ParticleSystem chargeParticle;
    private ParticleSystem.EmissionModule cpe;
    [SerializeField] private ParticleSystem shimmerParticle;
    private bool shoot = false;

    // Country Stuff
    [SerializeField] private LayerMask country;
    private GameObject prevCountry;

    // Inputs
    private float inputX;
    private float inputY;
    private bool fireRay;
    private bool chargeShot;
    private bool release;
    private bool flyDown;
    private bool flyUp;

    /****************************************************************************************************************************** 
    *PLEASE NOTE THAT IF YOU CHANGE THE ORDER OF THE CHILDREN UNDER "OUTLINES" IN THE HEIRARCHY, THE OUTLINES WILL NOT BE ACCURATE* 
    ******************************************************************************************************************************/

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cpe = chargeParticle.emission;
        cpe.rateOverTime = 0.0f;
        shimmerParticle.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, country))
        {
            // Scrolling line to aim towards country being aimed at
            lr.enabled = true;
            lr.SetPosition(0, orientation.position);
            lr.SetPosition(1, hit.point);
            // X object to help aim as well
            if(xSpot != null)
            {
                xSpot.transform.position = hit.point;
                xSpot.transform.up = hit.normal;
                xSpot.SetActive(true);
            }
            // Highlight country
            if (fireRay)
            {
                if (prevCountry != null)
                    prevCountry.GetComponent<CountryProperties>().GetOutlineMat().SetInt("_isHighlighted", 0);

                hit.transform.GetComponent<CountryProperties>().GetOutlineMat().SetInt("_isHighlighted", 1);
                Debug.Log(hit.transform.GetComponent<CountryProperties>().GetTemp());
                if(hit.transform.childCount > 0)
                    hit.transform.GetChild(0).GetComponent<CountryDataLoader>().GetCropDataInTime("apple", Calendar.instance.year);

                prevCountry = hit.transform.gameObject;
            }
        }
        else
        {
            // Aim forward instead of country
            lr.SetPosition(0, orientation.position);
            lr.SetPosition(1, orientation.forward * 1000);
            if (xSpot != null)
                xSpot.SetActive(false);
        }

        // Shoot crop extractor
        if (extractor != null)
        {
            if (shoot && release)
            {
                GameObject extractorGO = Instantiate(extractor, shimmerParticle.transform.position, Quaternion.identity);
                extractorGO.GetComponent<Rigidbody>().AddForce(orientation.forward * 200);
                shoot = false;
                chargeTimer = 0.0f;
            }
        }

        ChargeShot();
    }

    void ChargeShot()
    {
        if (chargeShot)
        {
            chargeTimer += Time.deltaTime;
            chargeTimer = Mathf.Clamp(chargeTimer, 0, chargeAmount);
        }
        else
            chargeTimer = 0.0f;

        if (chargeTimer > 0.2f)
        {
            cpe.rateOverTime = 90.0f;
            shimmerParticle.transform.localScale = new Vector3(chargeTimer / chargeAmount, chargeTimer / chargeAmount, chargeTimer / chargeAmount);
        }
        else
        {
            cpe.rateOverTime = 0.0f;
            shimmerParticle.transform.localScale = new Vector3(0, 0, 0);
            shoot = false;
        }

        if (chargeTimer >= chargeAmount)
            shoot = true;
    }

    void FixedUpdate()
    {
        // Movement
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
        chargeShot = Input.GetKey(KeyCode.Mouse0);
        release = Input.GetKeyUp(KeyCode.Mouse0);
        flyUp = Input.GetKey(KeyCode.Space);
        flyDown = Input.GetKey(KeyCode.LeftControl);
    }
}
