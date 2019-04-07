using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance;
    public float Speed;
    private bool isDead;
    private float lastDecimal = 0;

    #region Events
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    void Update()
    {
        Vector3 currentPos = transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Mathf.RoundToInt(currentPos.x) < 2)
            {
                transform.position = new Vector3(Mathf.RoundToInt(currentPos.x + 1),
                                                 currentPos.y,
                                                 currentPos.z);
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Mathf.RoundToInt(currentPos.x) > -2)
            {
                transform.position = new Vector3(Mathf.RoundToInt(currentPos.x - 1),
                                                 currentPos.y,
                                                 currentPos.z);
            }
        }
        Run();
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
        int newDecimal = (int)(GameMasterController.Instance.TimeElapsed / 5f);
        if (newDecimal > lastDecimal)
        {
            lastDecimal = newDecimal;
            Speed += 0.25f;
        }
        transform.Translate(new Vector3(0, 1, 0) * Speed * Time.deltaTime);
        this.GetComponent<Animator>().speed = Speed;
    }
}
