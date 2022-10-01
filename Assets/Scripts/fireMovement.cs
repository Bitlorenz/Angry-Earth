using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMovement : MonoBehaviour
{
    public float boundX = 50f;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   // se collided è falso allora il fuoco si muove
        if(!GetComponent<collisionPlayer>().getCollided())
            moveFire();
    }
   
    void DestroyOutOfBound()
    {
        if (transform.position.x > boundX)
            Destroy(gameObject);
    }

    void moveFire()
    {
        transform.position += speed * Time.deltaTime * new Vector3(1, 0f, 0f);
    }
}
