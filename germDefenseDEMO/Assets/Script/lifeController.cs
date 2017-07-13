using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Text remainedGerm;
    public int remainedGermNumber;

    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public CanvasGroup mainCanvasGroup;

    public ParticleSystem bombEffect;
    public ParticleSystem clearEffect;
    private float gameOverTime;
    private bool isGameOver;
    private bool isEffectEnd;
    public bool isCleared;
    
    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        remainedGerm.text = remainedGermNumber.ToString();
        isGameOver = false;
        isEffectEnd = false;
        isCleared = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(life == 0)
        {
            if (!isGameOver)
            {
                gameOverTime = Time.time;
                bombEffect.gameObject.SetActive(true);

                isGameOver = true;
            }
            else
            {
                if(!isEffectEnd && gameOverTime + 1f < Time.time)
                {
                    bombEffect.gameObject.SetActive(false);
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);

                    isEffectEnd = true;
                }
            }
        }

        if(isCleared)
        {
            StartCoroutine(nextLevel());
            StartCoroutine(DoFade());
            isCleared = false;
        }
	}

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(2.5f);

        Scene currentScene = SceneManager.GetActiveScene();

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

        }
    }

    IEnumerator DoFade()
    {

        while (mainCanvasGroup.alpha > 0)
        {
            mainCanvasGroup.alpha -= Time.deltaTime * 1.5f;
            yield return null;
        }

        mainCanvasGroup.interactable = false;
        yield return null;
    }
}
