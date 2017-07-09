using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToHome : MonoBehaviour
{

    private bool isInhaled;
    private bool isEnteredInBorder;
    private bool isInhalerDetected;
    private GameObject inhaler;
    private Vector3 inhalerPosition;

	// Use this for initialization
	void Start ()
    {
        iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", 0, "y", 0, "easeType", iTween.EaseType.linear, "speed", 10f));
        isInhaled = false;
        isEnteredInBorder = false;
        isInhalerDetected = false;
        inhalerPosition = new Vector3(999, 999, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isEnteredInBorder)
        {

        }

        if(isInhaled)
        {
            //this.transform.position = Vector3.MoveTowards(this.transform.position, inhaler.transform.position, 0);
            iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", inhaler.transform.position.x, "y", inhaler.transform.position.y, "easeType", iTween.EaseType.linear, "speed", 15f));

            Destroy(this.gameObject, 1f);
            
            isInhaled = false;
        }
	}

    private void OnDestroy()
    {
        try
        {
            rotateInhaler.Instance.GetComponent<SpriteRenderer>().color = rotateInhaler.Instance.normalColor;
        }
        catch(System.Exception e)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D border)
    {
        if (border.tag == "house")
        {
            if (lifeController.Instance.life > 0)
            {
                //isEnteredInBorder = true;
                lifeController.Instance.life--;

                lifeController.Instance.healthBar[lifeController.Instance.life].SetActive(false);

                Destroy(this.gameObject);
            }


            if (lifeController.Instance.life <= 0)
            {

                Debug.Log("GameOver");
                // GameOver Scene 만들기
                //SceneManager.LoadScene(1);
            }
        }
        else if (border.tag == "inhaler" && !isEnteredInBorder)
        {

            inhaler = border.transform.gameObject;

            rotateInhaler.Instance.GetComponent<SpriteRenderer>().color = Color.red;
            //Debug.Log("풍혈 포지션 : " + inhalerPosition);


            //iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", border.transform.position.x, "y", border.transform.position.y, "easeType", iTween.EaseType.linear, "speed", 15f));

            isInhaled = true;


        }
        else if (border.tag == "border")
        {
            Debug.Log("결계 안에 진입");
            isEnteredInBorder = true;
        }
    }
}
