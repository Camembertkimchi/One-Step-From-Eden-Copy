using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("플레이어 타일맵")]
    [SerializeField] private GameObject _gridPrefab;
    [SerializeField] private int _rows = 4; //그리드 행
    [SerializeField] private int _cols = 4; //그리드 행
    [SerializeField] private float _cellSize = 4.0f;
    [Header("적 타일맵")]
    [SerializeField] private GameObject _enemyGridPrefab;

    private GameObject[,] _gridCells;
    private GameObject[,] _enemyGridCells;
    private void Awake()
    {
        
    }

    private void SettingGrid()
    {
        _gridCells = new GameObject[_rows, _cols];
        Vector2 startPos = Vector2.zero;//시작 위치 (좌측하단)
        //중앙 배치를 위한 오프셋 계산
        startPos.x = -(_cols / 2.0f - 0.5f) * _cellSize;//0.5는 Sprite의 중앙 기준을 위한 것
        startPos.y = -(_cols / 2.0f - 0.5f) * _cellSize;//원점에서 왼쪽 배치해야 중앙에 위치함
        for (int row = 0; row < _rows; row++)//행열마다 배치되도록 for문
        {
            for (int col = 0; col < _cols; col++)
            {
                //결과값을 계산함. 가장 왼쪽 시작점에 cellSize를 곱해서 그 간격으로 배치되도록 함
                //마찬가지로 위쪽으로 갈수록 cellSize간격으로 배치됨.
                Vector2 cellPosition = new Vector2(startPos.x + (col * _cellSize), startPos.y + (row * _cellSize));
                //할당한 프리팹을 계산된 위치에 생성.
                GameObject cell = Instantiate(_gridPrefab, cellPosition, Quaternion.identity);
                cell.name = $"Cell ({row}, {col})";
                cell.transform.parent = this.transform;
                _gridCells[row, col] = cell;
            }
        }
    }
    private void GenerateEnemyGrid()
    {

    }

    public Vector2 GetWorldPosition(int row, int col)
    {
        if (row < 0 || row >= _rows || col < 0 || col >= _cols)
        {
            Debug.LogError($"이건 또 어디 접근 중임?: ({row}, {col})");
            return Vector2.zero;
        }
        return _gridCells[row, col].transform.position;
    }
}
