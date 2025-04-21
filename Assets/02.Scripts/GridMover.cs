using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2Int currentGridPos = new Vector2Int(0, 0);
    bool isMoving = false;
    [SerializeField] float tileSpaceX = 1.6f;
    [SerializeField] float tileSapceY = 1.0f;
    [SerializeField] Vector2 originalGridPos = new Vector2(-5.55f, -1.5f);

    public void GirdMove(Vector2Int dir)
    {
        Vector2Int targetGrid = currentGridPos + dir;
        if (IsInBounds(targetGrid))
        {
            currentGridPos = targetGrid;
            Vector3 targetPos = GridToWorld(currentGridPos);
            StartCoroutine(MoveToPosition(targetPos));
        }
    }


    bool IsInBounds(Vector2Int pos)
    {
        return pos.x >= -1 && pos.x <= 2 && pos.y >= -1 && pos.y <= 2;
    }

    Vector3 GridToWorld(Vector2Int gridPos)
    {
        return new Vector3(
            originalGridPos.x + gridPos.x * tileSpaceX,
            originalGridPos.y + gridPos.y * tileSapceY,
            0f
            );
    }

    IEnumerator MoveToPosition(Vector3 targetPos)
    {
        isMoving = true;
        while (Vector3.Distance(originalGridPos, targetPos) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;

    }

}
