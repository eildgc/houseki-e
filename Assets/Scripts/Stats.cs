using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 200f;
    public float damageOnHit = 50f;

    public bool deathEqualsGameOver = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This is going to apply damage when hit is received.
    /// The value of health changes.
    /// If the value of health is reduced to 0 or less, the game object using this script
    /// will die.
    /// </summary>
    public void OnHit() {
        //health = health - damageOnHit; Restale y asignalo
        health -= damageOnHit;
        
        //
        if (health <= 0f) {
            Die();
        }
    }
    /// <summary>
    /// When Die is called. The game object using this script will be destroyed.
    /// But if the Tag of this game object equals to "Player" it is going to looks for
    /// GameManager component and starts a coroutine to load the game over scene.
    /// </summary>
    private void Die() {
        string currentGameObjectTag = this.gameObject.tag;

        if (currentGameObjectTag == "Player")
        {
            var gameManagerComponent = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManagerComponent.GameOver();
            Debug.Log("Player died");
            Destroy(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
    }

    
}
