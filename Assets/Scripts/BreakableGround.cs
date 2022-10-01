using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableGround : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Hello world! Game object [" + gameObject.name + "] has been clicked.");
        
        if (GameManager.Instance.EarthquakePowerSelected)
        {
            Debug.Log("Platform destroyed.");

            Destroy(gameObject);

            GameManager.Instance.ActivateCooldownForEarthquakePower();
        }
    }
}
