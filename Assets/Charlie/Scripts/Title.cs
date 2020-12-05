using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Text titleText;
    public TextMeshProUGUI textMeshTitle; 

    private bool displayOn = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        //InvokeRepeating("DisplayTitle", 0.1f, .3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //InvokeRepeating("DisplayTitle", 2.0f, 1f);
        //StartCoroutine("DisplayTitle");
        // Debug.Log("update loop");
        //
        // //StartCoroutine("DisplayTitle");
        // if (displayOn)
        // {
        //     displayOn = false;
        //     titleText.gameObject.SetActive(false);
        //     Debug.Log("if loop");
        // }
        // else
        // {
        //     displayOn = true;
        //     titleText.gameObject.SetActive(true);
        //     Debug.Log("Else loop");
        // }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MenuScene");
        }

    }

    IEnumerator DisplayTitle()
    {
        while (true)
        {

            Debug.Log("while loop");
            titleText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
            titleText.gameObject.SetActive(true);
            yield return  new WaitForSeconds(.5f);
            
            // if (displayOn)
            // {
            //     displayOn = false;
            //     titleText.gameObject.SetActive(false);
            //     Debug.Log("if loop");
            //     yield return new WaitForSeconds(.1f);
            // }
            // else
            // {
            //     displayOn = true;
            //     titleText.gameObject.SetActive(true);
            //     Debug.Log("Else loop");
            //     yield return new WaitForSeconds(.1f);
            // }
            Debug.Log("End of displayTitle");
        }
    }
    
    
    
}
