using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationScript : MonoBehaviour
{
    public List<GameObject> formation;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in formation)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Formation!");
            foreach (GameObject obj in formation)
            {
                obj.SetActive(true);
            }
        } 
    }
}
