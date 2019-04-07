using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] EasyItems = { };
    [SerializeField]
    private GameObject[] EasyMedItems = { };
    [SerializeField]
    private GameObject[] MedItems = { };
    [SerializeField]
    private GameObject[] HardItems = { };
    [SerializeField]
    private float YPositionMultiplier = 0f;
    private float CurrentlyYPosition = 3f;
    [SerializeField]
    private float SpawnCooldown = 0f;
    private float SpawnCooldownTimeLeft = 0f;

    private void Start()
    {
        for (int i = 0; i < 4; i++)
            SpawnItem();
    }
    void Update()
    {
        SpawnCooldownTimeLeft -= Time.deltaTime;
        if (SpawnCooldownTimeLeft <= 0)
        {
            SpawnItem();
            SpawnCooldownTimeLeft = SpawnCooldown;
        }
    }

    public void SpawnItem()
    {
        float score = GameMasterController.Instance.GetScore();

        if (score < 6)
            Instantiate(EasyItems[Random.Range(0, EasyItems.Length)], new Vector3(0f, CurrentlyYPosition, 0f), this.transform.rotation);
        else if (score < 20)
            Instantiate(EasyMedItems[Random.Range(0, EasyMedItems.Length)], new Vector3(0f, CurrentlyYPosition, 0f), this.transform.rotation);
        else if (score < 40)
            Instantiate(MedItems[Random.Range(0, MedItems.Length)], new Vector3(0f, CurrentlyYPosition, 0f), this.transform.rotation);
        else
            Instantiate(HardItems[Random.Range(0, HardItems.Length)], new Vector3(0f, CurrentlyYPosition, 0f), this.transform.rotation);

        CurrentlyYPosition += YPositionMultiplier;

    }
}
