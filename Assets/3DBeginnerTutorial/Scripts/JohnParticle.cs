using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnParticle : MonoBehaviour
{
    public GameObject johnLemon;

    void Update()
    {
        transform.position = johnLemon.transform.position;
    }
}
