using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIScript : MonoBehaviour
{
    private GameObject gm;
    public TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = gm.GetComponent<GameManager>().score.ToString();
    }
}
