using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    
    public Transform player;
    public Vector3 offset;
    float newX = 0f;
    float newY = 0f;
    public float cameraSmooth = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      newX = Mathf.Lerp(transform.position.x, player.position.x + offset.x, cameraSmooth * Time.deltaTime);
      newY = Mathf.Lerp(transform.position.y, player.position.y + offset.y, cameraSmooth * Time.deltaTime);
      transform.position = new Vector3 (newX, newY, offset.z); // Camera follows the player with specified offset position
        
    }
}