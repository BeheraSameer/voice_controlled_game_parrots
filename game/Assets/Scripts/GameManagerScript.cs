using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
	public Text outputGUI;
    public GameObject flashRight;
    public GameObject flashWrong;

    void Start ()
    {
		//outputGUI = GameObject.Find("Text").GetComponent<Text>();    
        //outputGUI.text = "";
	}
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) 
        Application.Quit();
	}
	
	public void clear()
    {
		//if(outputGUI == null)
       // {
		//	outputGUI = GameObject.Find("Text").GetComponent<Text>();
		//}
		//outputGUI.text = "";
        flashRight.SetActive(false);
        flashWrong.SetActive(false);
    }

	public void setMatch()
	{
		//if(outputGUI == null)
       // {
		//	outputGUI = GameObject.Find("Text").GetComponent<Text>();
		//}
        //outputGUI.text = "Yay! It's a match";
        flashRight.SetActive(true);
    }

	public void setNotMatch()
	{
		//if(outputGUI == null)
       // {
		//	outputGUI = GameObject.Find("Text").GetComponent<Text>();
		//}

		//if(outputGUI.text != "Yay! It's a match")
			//outputGUI.text = "Not a match!";
        flashWrong.SetActive(true);
    }	
}
