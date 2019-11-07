using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public GameObject image;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space key was pressed");
            image.SetActive(false);
            text.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}