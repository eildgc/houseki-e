using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Calls the SceneManager to load scene that uses the slot 1 in the Build Manager settings.
    /// When more scenes exists, these can be added and called properly from here.
    /// </summary>
    public void LoadScene()
     {
        SceneManager.LoadScene(1);  
     }
    public static void LoadGameOverScene()
    {
        SceneManager.LoadScene(2);
    }
}
