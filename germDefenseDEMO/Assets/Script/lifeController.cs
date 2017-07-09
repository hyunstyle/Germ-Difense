using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeController : MonoBehaviour
{

    

    private static lifeController instance;
    public static lifeController Instance
    {
        get
        {
            if (instance == null)
            {
                return GameObject.FindObjectOfType<lifeController>();
            }
            return lifeController.instance;
        }
    }

    public int life;

    public GameObject[] healthBar;
    //public GameObject healthBarObject;
    /*public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public GameObject h4;
    public GameObject h5;
    public GameObject h6;
    public GameObject h7;
    public GameObject h8;
    public GameObject h9;
    public GameObject h10;*/

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
