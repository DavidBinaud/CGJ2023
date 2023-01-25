using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Light _light;

    public float maxBrightness = 1f;
    public float minBrightness = 0.5f;
    public float speedFlicker = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _light.intensity = (maxBrightness - minBrightness) / 2f + Mathf.Sin(Time.time * speedFlicker) * (maxBrightness - minBrightness)/2f;
    }
}