using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionPlayer : MonoBehaviour
{
    public GameObject playerOne;
    private Rigidbody rigidbody;
    private bool collided;

    // Start is called before the first frame update
    void Start()
    {
        playerOne = GameObject.Find("PlayerOne");
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("fuoco"))
        {
            Rigidbody playerOneRb = collision.gameObject.GetComponent<Rigidbody>();
            Debug.Log("Collided with: " + collision.gameObject.name);
            collided = true;
            rigidbody.velocity = Vector3.zero;lll
        }
    }

    public bool getCollided()
    {
        return collided;
    }

    public void setCollided(bool isCollided)
    {
        collided = isCollided;
    }
}
