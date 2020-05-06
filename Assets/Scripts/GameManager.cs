using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SaveManager saveManager;
    public GameObject totalDeathsValue = null;
    Text totalDeathsValueText;
    // Start is called before the first frame update
    void Start()
    {   
        saveManager = GetComponent<SaveManager>();
        
        if(totalDeathsValue != null){
            totalDeathsValueText = totalDeathsValue.GetComponent<Text>();
            
            saveManager.Load(()=>{
                totalDeathsValueText.text = saveManager.playerScore.gameOverTotal.ToString();
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Starts a coroutine to wait for 2 seconds and then load a scene that will be used
    /// as game over scene.
    /// </summary>
    public void GameOver(){
        StartCoroutine(WaitToLoadGameOverSceneCoroutine());
        int gameOverCount = saveManager.IncreaseGameOverCount();
        totalDeathsValueText.text = gameOverCount.ToString();


    }
    /// <summary>
    /// Coroutine. It will wait for 2 seconds and then load scene "2".
    /// </summary>
    IEnumerator WaitToLoadGameOverSceneCoroutine()
    {
        yield return new WaitForSeconds(2);
        // SceneLoader.LoadGameOverScene();
        SceneManager.LoadScene(2);
    }
}
