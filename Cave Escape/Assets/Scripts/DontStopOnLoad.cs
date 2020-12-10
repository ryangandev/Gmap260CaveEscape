using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontStopOnLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
