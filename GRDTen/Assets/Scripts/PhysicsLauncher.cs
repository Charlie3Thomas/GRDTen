using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsLauncher : MonoBehaviour
{
    [SerializeField] private GameObject physicsObject;
    [SerializeField] private int timeToShoot = 10;
    [SerializeField] private int amount = 1;
    private float spread = 10.0f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootObjects());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator ShootObjects()
    {
        if (physicsObject == null)
            yield return null;

        while (timer <= timeToShoot)
        {
            float randomNumberX = Random.Range(-spread, spread);
            float randomNumberY = Random.Range(-spread, spread);
            float randomNumberZ = Random.Range(-spread, spread);
            GameObject physicsGO = Instantiate(physicsObject, transform.position, transform.rotation);
            physicsGO.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ);
            physicsGO.GetComponent<Rigidbody>().AddForce(physicsGO.transform.forward * 100);
            yield return new WaitForSeconds(timeToShoot / amount);
        }

        Destroy(gameObject);
        yield return null;
    }
}
