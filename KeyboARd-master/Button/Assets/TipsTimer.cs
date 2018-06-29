using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsTimer : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void activeSet()
    {
        StartCoroutine(SetFalse());
    }

    private IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
        
    }
}
