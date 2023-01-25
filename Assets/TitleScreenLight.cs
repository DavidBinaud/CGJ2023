using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenLight : MonoBehaviour
{
    float rot = 50f;
    // Update is called once per frame
    void Update()
    {
        rot += Time.deltaTime * 30f;
        transform.rotation = Quaternion.Euler(rot, -30f, 0f);
    }
}
