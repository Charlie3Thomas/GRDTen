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

    // Earth Stuff
    private GameObject earth;
    [SerializeField] private LayerMask country;
    private GameObject prevCountry;

    /****************************************************************************************************************************** 
    *PLEASE NOTE THAT IF YOU CHANGE THE ORDER OF THE CHILDREN UNDER "OUTLINES" IN THE HEIRARCHY, THE OUTLINES WILL NOT BE ACCURATE* 
    ******************************************************************************************************************************/

    // Start is called before the first frame update
    void Start()
    {
        earth = GameObject.FindGameObjectWithTag("Earth");
        rb = GetComponent<Rigidbody>();
        cpe = chargeParticle.emission;
        cpe.rateOverTime = 0.0f;
        shimmerParticle.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, country))
        {
            try { // Get temps from lookat country
                CountryTempHolder._INSTANCE.selected_country_temp = hit.transform.GetComponent<CountryTempsAndOutlines>().GetTemp();
                if (CountryTempHolder._INSTANCE.selected_country_temp == -99) // if no data
                    CountryTempHolder._INSTANCE.selected_country_temp = 0; } // set no temperature deviation
            catch { CountryTempHolder._INSTANCE.selected_country_temp = 0.0f; } // set no temperature deviation
            try { // Get yield of targeted crop from lookat country
                CountryYieldHolder._INSTANCE.selected_country_yield = hit.transform.GetChild(0).GetComponent<CountryDataLoader>().
                                    GetCropDataInTime(CropSelectionManager.instance.GetCurrentCrop().name, Calendar.instance.year);
                if (CountryYieldHolder._INSTANCE.selected_country_yield == -99) // if no data
                    CountryYieldHolder._INSTANCE.selected_country_yield = 0; // set no yield
            } catch { CountryYieldHolder._INSTANCE.selected_country_yield = 0; } // set no yield
            try { // Get name from lookat country
                CountryNameHolder._INSTANCE.selected_country_name = "Location: " + 
                    hit.transform.GetChild(0).GetComponent<CountryDataLoader>().c_name;
            } catch { CountryNameHolder._INSTANCE.selected_country_name = "Location: none"; }


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
            if (PlayerInputManager.instance.fireRay)
            {
                if (prevCountry != null)
                    prevCountry.GetComponent<CountryTempsAndOutlines>().GetOutlineMat().SetInt("_isHighlighted", 0);

                hit.transform.GetComponent<CountryTempsAndOutlines>().GetOutlineMat().SetInt("_isHighlighted", 1);
                Debug.Log(hit.transform.GetComponent<CountryTempsAndOutlines>().GetTemp());
                
                if (hit.transform.childCount > 0)
                    hit.transform.GetChild(0).GetComponent<CountryDataLoader>().GetCropDataInTime(CropSelectionManager.instance.GetCurrentCrop().name, Calendar.instance.year);

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
            if (shoot && PlayerInputManager.instance.release)
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
        if (PlayerInputManager.instance.chargeShot)
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
        float distMultiplier =  Mathf.Clamp(Mathf.Exp((Vector3.Distance(transform.position, earth.transform.position) / 30f)) - 1.2f, 0, 2);
        //Debug.Log(distMultiplier);
        Vector3 moveDir = orientation.forward * PlayerInputManager.instance.inputY + orientation.right * PlayerInputManager.instance.inputX;
        rb.AddForce(moveDir.normalized * playerSpeed * speedMult * distMultiplier, ForceMode.Acceleration);

        if (PlayerInputManager.instance.flyDown)
            rb.AddForce(Vector3.down * playerSpeed * speedMult * distMultiplier, ForceMode.Acceleration);

        if (PlayerInputManager.instance.flyUp)
            rb.AddForce(Vector3.up * playerSpeed * speedMult * distMultiplier, ForceMode.Acceleration);
    }
}
