using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandQ2 : MonoBehaviour
{
    public string LevelName;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        if ((Input.GetKey("r")))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if ((Input.GetKey("1")))
            SceneManager.LoadScene("One Player");
        if ((Input.GetKey("space")))
            image.enabled = false;


    }
}