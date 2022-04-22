using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30;
    public Text timerText;
    public Text timesupText;

    public bool timesUp;

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    private void Start()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else 
        {
        	timeRemaining = 0;
        }

        DisplayTime(timeRemaining);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(scenePaths[0], LoadSceneMode.Single);
    }

    void DisplayTime (float time){
    	if (time < 0){
    		time = 0;

            timesUp = true;
            timesupText.enabled = true;

            Wait();
            //Time.timeScale = 0f; //efetivamente pausa o jogo
        }

    	float minutes = Mathf.FloorToInt(time / 60);
    	float seconds = Mathf.FloorToInt(time % 60);

    	timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
