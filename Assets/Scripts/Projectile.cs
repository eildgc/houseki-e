using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Projectile used by Player
/// </summary>
public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// Projectile's speed is established in this variable.
    /// </summary>
    public float projectileSpeed = 0.5f;
    /// <summary>
    /// Used to save the Tag of the target that is going to receive the damage when triggered at contact.
    /// </summary>
    public string damageableTargetTag = "";
    /// <summary>
    /// Used to indicate the direction that we desire the projectile will take.
    /// </summary>
    Vector3 projectileDirection;
    /// <summary>
    /// Used to check if player is "looking" to right or not. Projectile will be instantiated in the
    /// direction that the playing is facing.
    /// </summary>
    public bool shootRight = false;
    /// <summary>
    /// The projectile has a lifespan, the projectile will be destroyed when its lifespan is depleted to 0.
    /// </summary>
    public float m_Lifespan = 3f; // this is the projectile's lifespan (in seconds)
    void Start()
    {
        //Projectile is going to be destroyed when lifespan is over.
        Destroy(gameObject, m_Lifespan);
        
    }

    // Update is called once per frame
    void Update()
    {
        //First check what direction is the player facing.
        if (shootRight ){
            transform.Translate(new Vector2(projectileSpeed, 0f));
        // if (transform.position.y > maxYPosition || transform.position.y < minYPosition){
        //     Destroy(gameObject);
        // } else if(transform.position.x > maxXPosition || transform.position.x < minXPosition){
        //     Destroy(gameObject);
        // }
        } else {
            transform.Translate(new Vector2(-projectileSpeed, 0f));
        }
    
        
    }
//When the projectile is triggered by the collider of the damageableTargetTag, it is going to
//do damage (the quantity of damage is established in Stats.cs) and be destroyed after doing sit.
private void OnTriggerEnter(Collider other) {
            
            if (other.gameObject.tag == damageableTargetTag){
                Stats enemyStats = other.gameObject.GetComponent<Stats>();
                enemyStats.OnHit();
                Debug.Log(other.gameObject);
                Destroy(gameObject);
            }
        }
}
