using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


public interface ICommand
{
    void Execute();
    void Undo();
}

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    bool isDead;
    [SerializeField] GridMover gridMover;
    [SerializeField] CommandInvoker invoker;

    void OnEnable()
    {
        anim = GetComponent<Animator>();
        if(invoker == null)
        {
            invoker = GameObject.FindObjectOfType<CommandInvoker>();
        }
    }

    
    void Update()
    {
        if(!isDead)
        {
            
        }
    }

   

}
