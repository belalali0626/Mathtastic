using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{


    [Header("Objects")]
    [SerializeField]GameObject spawn1;
    [SerializeField]GameObject spawn2;

    [Header("Strings")]
    public string playerTag;
    public string playerTag2;






    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        if (collision.gameObject.tag == playerTag)
        {
            player.transform.position = spawn1.transform.position;
        }

        else if (collision.gameObject.tag == playerTag2)
        {
            player.transform.position = spawn2.transform.position;
        }
    }
}
