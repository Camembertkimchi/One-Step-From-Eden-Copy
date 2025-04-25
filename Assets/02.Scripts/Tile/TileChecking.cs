using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TileChecking : MonoBehaviour
{
    [SerializeField] GameObject shadow;
    [SerializeField] GameObject onIt;
    [SerializeField] Vector2Int gridPos;
    TileState tileState;
    [SerializeField] float fireDuration = 10f;
    float elapsed = 0f;

    public TileState StateTile
    {
        get => tileState;
        set
        {
            if(tileState != value)
            {
                tileState = value;
                if(tileState == TileState.Fire)
                {
                    elapsed = 0f;
                    StartCoroutine(FireCoroutine());
                }
            }
        }
    }

    Damageable objOnTile;

    private void Awake()
    {
        Vector3 pos = transform.position;
        gridPos = TileManager.Instance.WorldToGrid(pos);

        TileManager.Instance.RegisterTile(gridPos, this);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            onIt.SetActive(false);
        }
        if(collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            objOnTile = collision.GetComponent<Damageable>();
            shadow.SetActive(true);
            if(tileState == TileState.Fire )
            {
                objOnTile.ApplyDamage(10, false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (objOnTile != null)
        {
            objOnTile = null;
        }
        if (!onIt.activeSelf)
        {
            onIt.SetActive(true);
        }
        if (shadow.activeSelf)
        {
            shadow.SetActive(false);
        }
        if (tileState == TileState.Glassed)
        {
            tileState = TileState.Broken;
        }
    }

    IEnumerator FireCoroutine()
    {
        
        while(elapsed < fireDuration)
        {
            if(objOnTile != null)
            {
                objOnTile.ApplyDamage(10, false);
            }

            elapsed += 1f;
            yield return new WaitForSeconds(1f);
        }
        

        
    }
    

}
