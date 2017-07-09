using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMonster : MonoBehaviour {

    private GameObject clone;

    public GameObject warpMon;
    public GameObject tornadoMon;
    public GameObject steadyMon;
    public GameObject normalMon;
    public GameObject packMon;
    public GameObject goldMon;

    public GameObject parentPanel;
    private float time;
    public float spawnTime;

    private const int LEFT = 0;
    private const int RIGHT = 1;
    private const int UP = 2;
    private const int DOWN = 3;
    // Use this for initialization
    void Start ()
    {
        time = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        if(time > spawnTime)
        {
            clone = Instantiate(normalMon, parentPanel.transform);

            int randomDir = Random.Range(0, 4);
            float randomX = 999;
            float randomY = 999;
            switch (randomDir)
            {
                case LEFT:
                    randomX = Random.Range(-Screen.width * 2, -Screen.width);
                    randomY = Random.Range(-Screen.height, Screen.height);
                    break;
                case RIGHT:
                    randomX = Random.Range(Screen.width, Screen.width * 2);
                    randomY = Random.Range(-Screen.height, Screen.height);
                    break;
                case UP:
                    randomX = Random.Range(-Screen.width, Screen.width);
                    randomY = Random.Range(Screen.height, Screen.height * 2);
                    break;
                case DOWN:
                    randomX = Random.Range(-Screen.width, Screen.width);
                    randomY = Random.Range(-Screen.height, -Screen.height * 2);
                    break;
                default:
                    break;
            }

            clone.transform.localPosition = new Vector3(randomX, randomY);

            time = 0f;
            //clone.transform.position = new Vector3();
        }
	}





    void makeMonster(GameObject mon, string monName, ref int num)
    {
        while (num > 0)
        {
            clone = Instantiate(mon, this.transform);
            float randomX = Random.Range(-Screen.width / 2, Screen.width / 2);
            float randomY = Random.Range(-100, Screen.height / 2 - 190);
            clone.transform.localPosition = new Vector3(randomX, randomY, 0);
            clone.transform.parent = this.transform;
            clone.name = monName;
            clone.SetActive(true);
            num--;
        }
    }


}
