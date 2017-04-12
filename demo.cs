using UnityEngine;
using System.Collections;

public class demo : MonoBehaviour {

    public Light myLight;
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKey("Space"))
        {
            myLight.enabled = true;
        }
    else
        {
            myLight.enabled = false;
        }
	}
}
