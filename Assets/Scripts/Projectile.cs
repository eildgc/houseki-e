using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float projectileSpeed = 0.5f;
    // public int maxYPosition = 100;
    // public int minYPosition = -100;
    // public int maxXPosition = 100;
    // public int minXPosition = -100;
    public string damageableTargetTag = "";
    Vector3 projectileDirection;
    public bool shootRight = false;
    public float m_Lifespan = 3f; // this is the projectile's lifespan (in seconds)
    void Start()
    {
        Destroy(gameObject, m_Lifespan);
    }

    // Update is called once per frame
    void Update()
    {
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
    void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject);
            
            if (other.gameObject.tag == damageableTargetTag){
                Stats enemyStats = other.gameObject.GetComponent<Stats>();
                enemyStats.OnHit();
                Debug.Log(other.gameObject);
                Destroy(gameObject);
            }
        }
}
