using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [SerializeField]
    private float tumble, speed;

    private Vector3 offSetOne, offSetTwo, offSetThree;
   //public int health;

    public GameObject demiAsteroid;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;

        offSetOne = new Vector3(2, Random.Range(-4, 2), 0);
        offSetTwo = new Vector3(-2, Random.Range(-2, 4), 0);
        offSetThree = new Vector3(0, Random.Range(-2, 2), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        //transform.localRotation = Random.rotation ;

        Quaternion rotationOne = Quaternion.Euler(new Vector3(0, 0, Random.Range(-65, 5)));
        Quaternion rotationTwo = Quaternion.Euler(new Vector3(0, 0, Random.Range(-20, 20)));
        Quaternion rotationThree = Quaternion.Euler(new Vector3(0, 0, Random.Range(-5, 65)));

        if (GetComponent<EnemyScript>().health <= 0)
        {
            Instantiate(demiAsteroid, transform.position + offSetOne, rotationOne);
            Instantiate(demiAsteroid, transform.position + offSetTwo, rotationTwo);
            Instantiate(demiAsteroid, transform.position + offSetThree, rotationThree);
            Destroy(gameObject);
        }
    }

    /*public void TakeDamage(int dmgAmount)
    {
        health -= dmgAmount;
    }*/
}
