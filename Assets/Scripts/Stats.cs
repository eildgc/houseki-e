using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f;
    public float damageOnHit = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHit() {
        //health = health - damageOnHit; Restale y asignalo
        health -= damageOnHit;

        if (health <= 0f) {
            Die();
        }
    }
    private void Die() {
        Destroy(this.gameObject);
    }
}
