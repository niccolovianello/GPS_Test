using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{

    public float lat;
    public float lon;
    public Text gpsText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Input.location.isEnabledByUser) StartCoroutine(GetLocation());
        
    }
    
    private IEnumerator GetLocation()
    {
          Input.location.Start();
          while (Input.location.status == LocationServiceStatus.Initializing)
          {
              yield return new WaitForSeconds(0.5f);
          }

          lat = Input.location.lastData.latitude;
          lon = Input.location.lastData.longitude;
          yield break;
    }

    // Update is called once per frame
    void Update()
    {
        lat = Input.location.lastData.latitude;
        lon = Input.location.lastData.longitude;

        gpsText.text = "Lat: " + lat + "\nLon: " + lon;
    }
}
