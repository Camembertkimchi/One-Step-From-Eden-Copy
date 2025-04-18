using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    bool isDead;
    Vector2Int currentGridPos = new Vector2Int(0,0);
    bool isMoving = false;
    [SerializeField] float tileSpaceX = 1.6f;
    [SerializeField] float tileSapceY = 1.0f;
    [SerializeField] Vector2 originalGridPos = new Vector2(-5.55f, -1.5f);
    void OnEnable()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(!isDead)
        {
            
        }
    }

    Vector3 GridToWorld(Vector2Int gridPos)
    {
        return new Vector3(
            originalGridPos.x + gridPos.x * tileSpaceX,
            originalGridPos.y + gridPos.y * tileSapceY,
            0f
            );
    }

}
