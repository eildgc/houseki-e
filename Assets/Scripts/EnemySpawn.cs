using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    /// <summary>
    /// The "spawner" is going to instantiate a game object, in this case, an enemy.
    /// </summary>
    public GameObject enemy;
    /// <summary>
    /// The game object declared before is going to be instantiated in the position of the object we establish in this
    /// variable.
    /// </summary>
    public Transform enemyPos;
    /// <summary>
    /// Rate established that is going to repeat an action after some seconds.
    /// We can change this value if we want that enemies rate's spawn be slower or quickier. 
    /// </summary>
    private float repeatRate = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// If the gameObject tagged as "Player" enter in contact with the collider,
    /// will starts spawning enemies.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag =="Player"){
            //It repeats a function described at after these two line of comments. It calls EnemySpawner, after 0.5 seconds it would spawn
            //an enemy and after 5 seconds it is going to spawn another enemy
            InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
            //The gameobject that is "calling" the enemies is going to be destroyed after 11 seconds so thousand of enemies don't spawn
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    //Instatiates an enemy 

        /// Update is called once per frame
    /// <summary>
    /// Instantiate one enemy, in the same position and rotation as the object that calls the method when triggered.
    /// </summary>
    /// <param name="other"></param>
    void EnemySpawner() {
        Instantiate(enemy, enemyPos.position, enemyPos.rotation);   
    }
}
