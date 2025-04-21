using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileChecking : MonoBehaviour
{
    [SerializeField]GameObject shadow;
    [SerializeField]GameObject onIt;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            onIt.SetActive(false);
        }
        if(collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            shadow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!onIt.activeSelf)
        {
            onIt.SetActive(true);
        }
        if (shadow.activeSelf)
        {
            shadow.SetActive(false);
        }
    }
}
