using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance;
    public float Speed;
    private float lastDecimal = 0;
    [SerializeField]
    private GameObject FlipFlop;
    private bool isAlive = true;

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
        Vector3 flipFlorCurrentPos = FlipFlop.transform.position;
        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && Mathf.RoundToInt(currentPos.x) < 2)
            {
                transform.position = new Vector3(Mathf.RoundToInt(currentPos.x + 1), currentPos.y, currentPos.z);
                FlipFlop.transform.position = new Vector3(Mathf.RoundToInt(currentPos.x + 1), flipFlorCurrentPos.y, flipFlorCurrentPos.z);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && Mathf.RoundToInt(currentPos.x) > -2)
            {
                transform.position = new Vector3(Mathf.RoundToInt(currentPos.x - 1), currentPos.y, currentPos.z);
                FlipFlop.transform.position = new Vector3(Mathf.RoundToInt(currentPos.x - 1), flipFlorCurrentPos.y, flipFlorCurrentPos.z);
            }
            Run();
        }
    }
    #endregion

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Obstacle"))
        {
            //acho que nao faz nada aqui porque ai vai travar a velocidade e o chinelo vai alcançar
            //mas qualquer coisa da pra adicionar alguma penalidade aqui
        }
        if (collider.CompareTag("flipflop"))
        {
            isAlive = false;
            GetComponent<Animator>().speed = 0f;
            GameMasterController.Instance.StopCounter();
            AudioGameController.Instance.PlayFlipFlop();

        }
        if (collider.CompareTag("hole"))
        {
            isAlive = false;
            AudioGameController.Instance.PlayFall();
            StartCoroutine(Holed());
            //tocar a animação do buraco
        }
        if (!isAlive)
        {
            StartCoroutine(DeathPanel());
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
        GetComponent<Animator>().speed = Speed;

        FlipFlop.transform.Translate(new Vector3(0, 1, 0) * Speed * Time.deltaTime);
    }
    IEnumerator DeathPanel()
    {
        yield return new WaitForSeconds(0.5f);
        GameMasterController.Instance.ShowDeathPanel();
    }
    IEnumerator Holed()
    {
        yield return new WaitForSeconds(0.5f);
        GameMasterController.Instance.StopCounter();
        GetComponent<Animator>().SetTrigger("isHoled");
        yield return new WaitForSeconds(0.4f);
        GameMasterController.Instance.ShowDeathPanel();
        Destroy(this);
    }
}
