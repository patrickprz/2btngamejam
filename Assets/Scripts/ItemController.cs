using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private float TimeToDie;

    void Start()
    {
        Destroy(gameObject, TimeToDie);
    }

}
