using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
   private Queue<ICommand> commandQueue = new Queue<ICommand>();

    public void EnqueueCommand(ICommand command)
    {
        commandQueue.Enqueue(command);
    }
    public void ExecuteNextCommnad()
    {
        if(commandQueue.Count > 0)
        {
            ICommand command = commandQueue.Dequeue();
            command.Execute();
        }
    }

}
