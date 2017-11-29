using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currNote : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape)) 
        Application.Quit();   
    }

    public void updatePosition(float posY)
    {
        float speed = 35.0f;
        Vector3 yTransform = new Vector3(rigidBody.transform.position.x, posY, rigidBody.transform.position.z);
		rigidBody.transform.position = Vector3.Lerp(rigidBody.transform.position, yTransform, Time.deltaTime * speed);
    }
}
