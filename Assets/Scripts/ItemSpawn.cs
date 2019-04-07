using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    private string[] ItemNames = {//adicionar os nomes dos prefabs dos items para nascerem dentro do spawner
    "Item000",
    "Item001",
    "Item002",
    "Item003"
    };

    void Start()
    {
        int randonRange = Random.Range(0, ItemNames.Length);//vai o length mesmo porque o range com int é inclusivo para o inicial, mas exclusivo para o final

        GameObject go = (GameObject)Instantiate(Resources.Load("Items/" + ItemNames[randonRange]), this.transform.position, this.transform.rotation);
        go.transform.parent = this.transform;
    }


    void Update()
    {

    }
}
