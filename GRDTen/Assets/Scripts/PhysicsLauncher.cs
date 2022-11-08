using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsLauncher : MonoBehaviour
{
    public static PhysicsLauncher instance { get; private set; }

    [SerializeField] private GameObject physicsObject;
    [SerializeField] private GameObject physicsObjectManager;
    private float scaleModifier = 1.0f;
    public long amount = 0;
    private float spread = 25.0f;
    private float timer = 0.0f;
    private int divisible = 10000;

    private void Awake()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        physicsObjectManager = GameObject.FindGameObjectWithTag("PhysicsObjectManager");
        StartCoroutine(ShootObjects());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator ShootObjects()
    {
        physicsObject = CropSelectionManager.instance.GetCurrentCrop();
        long extractedCount = 0;
        long actualAmount = amount / divisible;

        if (amount > 0 && amount < divisible)
            actualAmount = 1;

        if(actualAmount > 1000 && actualAmount < 10000)
        {
            scaleModifier = 2f;
            actualAmount /= 10;
        }
        else if(actualAmount > 10000)
        {
            scaleModifier = 3f;
            actualAmount /= 100;
        }

        Debug.Log(actualAmount);

        while (extractedCount < actualAmount)
        {
            float randomNumberX = Random.Range(-spread, spread);
            float randomNumberY = Random.Range(-spread, spread);
            float randomNumberZ = Random.Range(-spread, spread);
            GameObject physicsGO = Instantiate(physicsObject, transform.position, transform.rotation, physicsObjectManager.transform);
            physicsGO.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ);
            physicsGO.transform.localScale *= scaleModifier;
            physicsGO.GetComponent<Rigidbody>().AddForce(physicsGO.transform.forward * 100);
            extractedCount++;
            yield return new WaitForSeconds(0.001f);
        }

        Destroy(gameObject);
        yield return null;
    }
}
