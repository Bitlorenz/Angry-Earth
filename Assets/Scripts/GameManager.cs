using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button earthquakeButton;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float earthquakePowerCooldown = 3f;

    public bool EarthquakePowerSelected { get; private set; }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            EarthquakePowerSelected = false;
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator EarthquakePowerCooldown()
    {
        Debug.Log("Waiting for [" + earthquakePowerCooldown + "] seconds before activating earthquake button again...");
        yield return new WaitForSeconds(earthquakePowerCooldown);

        EnableEarthquakeButton();
    }

    public void SelectEarthquakePower()
    {
        EarthquakePowerSelected = true;
        DisableEarthquakeButton();

        Debug.Log("Earthquake power selected.");
    }

    public void EnableEarthquakeButton()
    {
        earthquakeButton.gameObject.SetActive(true);
    }

    public void DisableEarthquakeButton()
    {
        if (earthquakeButton == null)
        {
            Debug.Log("EarthquakeButton is null!!!!");
        }
        else if (earthquakeButton.gameObject == null)
        {
            Debug.Log("earthquakeButton.gameObject is null!!!!");
        }
        else
        {
            earthquakeButton.gameObject.SetActive(false);

            Debug.Log("Earthquake button disabled.");
        }
    }

    public void ActivateCooldownForEarthquakePower()
    {
        EarthquakePowerSelected = false;
        DisableEarthquakeButton();
        StartCoroutine(EarthquakePowerCooldown());
    }
}
