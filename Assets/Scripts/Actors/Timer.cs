using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30;
    public Text timerText;
    public Text scoreText;
    public GameObject scorePanel;

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

            Time.timeScale = 0f; //efetivamente pausa o jogo
            DisplayScorePanel();
        }

    	float minutes = Mathf.FloorToInt(time / 60);
    	float seconds = Mathf.FloorToInt(time % 60);

    	timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayScorePanel(){
        List<GameObject> pointsOfInterest;
        pointsOfInterest = new List<GameObject>();
        pointsOfInterest.AddRange(GameObject.FindGameObjectsWithTag("MuseumPiece"));

        float numFixed = pointsOfInterest.Count;
        foreach(GameObject obj in pointsOfInterest){
            if(obj.GetComponent<ObjectAnimationController>().isMessed){
                numFixed--;
            }
        }
        Debug.Log(numFixed);
        Debug.Log(pointsOfInterest.Count);
        float score = 100f*(numFixed/pointsOfInterest.Count);
        
        scoreText.text = (int)score+"% arrumado";
        scorePanel.SetActive(true);

    }

    public void Sair(){
        Application.Quit();
    }

    public void ProximaFase(){
        SceneManager.LoadScene("Level2");
    }
}
