using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public List<Quest> questList = new List<Quest>();
    public float playerSpeed = 7f;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public bool flashLightActive = false;
    public GameObject flashLight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;
        ToggleFlashLight();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }

    void ToggleFlashLight()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (flashLightActive == false)
            {
                flashLight.gameObject.SetActive(true);            
                flashLightActive = true;
            }
            else
            {
                flashLight.gameObject.SetActive(false);
                flashLightActive = false;
            }
        }
    }
}
