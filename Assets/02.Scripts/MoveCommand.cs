using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private GridMover mover;
    private Vector2Int direction;

    public MoveCommand(GridMover mover, Vector2Int dir)
    {
        this.mover = mover;
        this.direction = dir;
    }
    public void Execute()
    {
        mover.GirdMove(direction);
    }
    public void Undo()
    {
        mover.GirdMove(-direction);
    }

}
