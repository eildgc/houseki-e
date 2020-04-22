using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
