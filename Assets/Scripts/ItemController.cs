using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private float TimeToDie = 3;

    void Start()
    {
        Destroy(gameObject, TimeToDie);
    }

}
