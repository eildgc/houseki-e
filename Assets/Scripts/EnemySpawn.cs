using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemyPos;
    private float repeatRate = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// Update is called once per frame
    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag =="Player"){
            //It repeats a function described at bottom. It calls EnemySpawner, after 0.5 seconds it would spawn
            //enemy and after 5 seconds it is going to spawn another enemy
            InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
            //The gameobject is going to be destroyed after 11 seconds so thousand of enemies don't spawn
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    //Instatiates an enemy 
    void EnemySpawner() {
        Instantiate(enemy, enemyPos.position, enemyPos.rotation);   
    }
}
