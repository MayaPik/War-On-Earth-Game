using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDistract : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 3f;    

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
