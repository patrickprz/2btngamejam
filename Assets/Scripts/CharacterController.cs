using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed;
    private bool isDead;

    #region Events
    void Start()
    {

    }

    void FixedUpdate(){
        Run();
    }

    void Update()
    {
        Vector3 currentPos = transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentPos.x < 2)
            {
                transform.position = new Vector3(currentPos.x + 1,
                                                 currentPos.y,
                                                 currentPos.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(currentPos.x > -2)
            {
                transform.position = new Vector3(currentPos.x - 1,
                                                 currentPos.y,
                                                 currentPos.z);
            }
        }
    }
    #endregion

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Obstacle"))
        {
            isDead = true;
            print(isDead);
        }
    }

    void Run()
    {
        transform.Translate(new Vector3(0, 1, 0) * Speed * Time.deltaTime);
    }
}
