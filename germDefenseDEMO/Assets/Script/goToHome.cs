using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goToHome : MonoBehaviour
{

    private bool isInhaled;
    private bool isEnteredInBorder;
    
    public GameObject inhaler;

    private bool isDestroyCalled;
    private bool isScoreDecreased;

    private Scene currentScene;

    public ParticleSystem clearEffect;

    // Use this for initialization
    void Start ()
    {
        currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName.Contains("1")) // stage 1
        {
            iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", 0, "y", 0, "easeType", iTween.EaseType.linear, "speed", 10f));
        }
        else if (sceneName.Contains("2")) // stage 2
        {
            iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", 0, "y", 0, "easeType", iTween.EaseType.linear, "speed", 15f));
        }
        else if (sceneName.Contains("3")) // stage 3
        {
            iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", 0, "y", 0, "easeType", iTween.EaseType.linear, "speed", 20f));
        }
        else if (sceneName.Contains("4")) // stage 4
        {
            iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", 0, "y", 0, "easeType", iTween.EaseType.linear, "speed", 25f));
        }
        else if (sceneName.Contains("5")) // stage 5
        {
            iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", 0, "y", 0, "easeType", iTween.EaseType.linear, "speed", 30f));
        }
        //iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", 0, "y", 0, "easeType", iTween.EaseType.linear, "speed", 10f));
        isInhaled = false;
        isEnteredInBorder = false;
        isDestroyCalled = false;
        isScoreDecreased = false;

        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isEnteredInBorder)
        {

        }

        if(isInhaled)
        {

            if (inhaler.gameObject == null)
            {
                isInhaled = false;
            }
            else
            {
                iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", inhaler.transform.position.x, "y", inhaler.transform.position.y, "easeType", iTween.EaseType.linear, "speed", 20f));
            }

            if (!isDestroyCalled)
            {
                Destroy(this.gameObject, 1f);
                isDestroyCalled = true;
            }
            

            //isInhaled = false;
        }
	}

    /*ivate void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "inhaler")
        {
            iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", inhaler.transform.position.x, "y", inhaler.transform.position.y, "easeType", iTween.EaseType.linear, "speed", 20f));
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "inhaler")
        {
            if (lifeController.Instance.remainedGermNumber > 0)
            {
                lifeController.Instance.remainedGermNumber--;
                lifeController.Instance.remainedGerm.text = lifeController.Instance.remainedGermNumber.ToString();
                isScoreDecreased = true;
            }

            if(rotateInhaler.Instance.GetComponent<SpriteRenderer>().color == Color.green)
            {

            }


            Destroy(this.gameObject);

        }
    }

    private void OnDestroy()
    {
        try
        {


            if (!isScoreDecreased && lifeController.Instance.remainedGermNumber > 0)
            {
                lifeController.Instance.remainedGermNumber--;
                lifeController.Instance.remainedGerm.text = lifeController.Instance.remainedGermNumber.ToString();
            }

            if (!isScoreDecreased && lifeController.Instance.life > 0 && lifeController.Instance.remainedGermNumber == 0)
            {

                lifeController.Instance.clearEffect.gameObject.SetActive(true);
                lifeController.Instance.isCleared = true;

                //StartCoroutine(nextLevel());
                /*Scene currentScene = SceneManager.GetActiveScene();

                string sceneName = currentScene.name;

                if (sceneName.Contains("1"))
                {
                    SceneManager.LoadScene(1);
                }
                else if (sceneName.Contains("2"))
                {
                    SceneManager.LoadScene(2);
                }
                else if (sceneName.Contains("3"))
                {
                    SceneManager.LoadScene(3);
                }
                else if (sceneName.Contains("4"))
                {
                    SceneManager.LoadScene(4);
                }
                else if (sceneName.Contains("5"))
                {

                }*/
            }

            if (rotateInhaler.isRotating && inhaler.gameObject == rotateInhaler.currentInhaler.gameObject)
            {
                //Debug.Log("초록색으로");
                inhaler.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                //Debug.Log("일반으로");
               inhaler.GetComponent<SpriteRenderer>().color = rotateInhaler.Instance.normalColor;
            }
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

            inhaler.GetComponent<SpriteRenderer>().color = Color.red;

            //rotateInhaler.Instance.GetComponent<SpriteRenderer>().color = Color.red;
            //Debug.Log("풍혈 포지션 : " + inhalerPosition);

            

            //this.transform.RotateAround(inhaler.transform.localPosition, Vector3.forward, 90f * Time.deltaTime);
            //iTween.MoveTo(this.transform.gameObject, iTween.Hash("x", border.transform.position.x, "y", border.transform.position.y, "easeType", iTween.EaseType.linear, "speed", 15f));

            isInhaled = true;

            


        }
        else if (border.tag == "border")
        {
            //Debug.Log("결계 안에 진입");
            isEnteredInBorder = true;
        }
    }

    
}
