using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private bool canFireEarhquake = false;

    public void OnEarthquakeButtonPressed()
    {
        canFireEarhquake = true;
    }

}
