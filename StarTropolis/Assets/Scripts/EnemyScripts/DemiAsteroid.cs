using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemiAsteroid : MonoBehaviour
{
    [SerializeField]
    private float tumble, speed;

    private Vector3 zPos;

    public int health;
    public Rigidbody rb;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.angularVelocity = Random.insideUnitSphere * tumble;
        zPos = transform.localPosition;

        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        //transform.localRotation = Random.rotation ;
       

        if (zPos.z <= 0 || zPos.z >= 0)
        {
            zPos.z = 0;
        }

        if (GetComponent<EnemyScript>().health <= 0)
        {
            gameManager.GetComponent<GameManager>().AddScore(10);
            Destroy(gameObject);
        }
    }

    /*public void TakeDamage(int dmgAmount)
    {
        health -= dmgAmount;
    }*/
}
