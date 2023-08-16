using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [SerializeField]
    private float speed, tumble;

    public Rigidbody rb;
    public Transform player;

    public EnemyScript enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        transform.LookAt(player);

        if (GetComponent<EnemyScript>().health <= 0)
        {
            rb.angularVelocity = Random.insideUnitSphere * tumble;
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        
        //transform.rotation = Random.rotation;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }


}
