using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Items;
    [SerializeField]
    private float YPositionMultiplier;
    private float CurrentlyYPosition;
    [SerializeField]
    private float SpawnCooldown;
    private float SpawnCooldownTimeLeft;
    void Start()
    {
        CurrentlyYPosition = 6f;
        SpawnCooldownTimeLeft = 0f;
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
        int randonRange = Random.Range(0, Items.Length);//vai o length mesmo porque o range com int é inclusivo para o inicial, mas exclusivo para o final

        Instantiate(Items[randonRange], new Vector3(0f, CurrentlyYPosition, 0f), this.transform.rotation);
        CurrentlyYPosition += YPositionMultiplier;

    }
}
