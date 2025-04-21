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

   

}
