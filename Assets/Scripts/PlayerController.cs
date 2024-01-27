using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    private bool p1A, p1B, p2A, p2B, started;

    public void onAwake() {
        p1A = false;
        p2A = false;
        p1B = false;
        p2B = false;
        started = false;
    }

    public void playerAction() {
        started = true;
        anim.SetBool("p1A", p1A);
        anim.SetBool("p1B", p1B);
        anim.SetBool("p2A", p2A);
        anim.SetBool("p2B", p2B);
    }

    public void p1Aaction(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            p1A = true;
        }
        if (context.phase == InputActionPhase.Canceled) {
            p1A = false;
        }
        playerAction();
    }

    public void p1Baction(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            p1B = true;
        }
        if (context.phase == InputActionPhase.Canceled) {
            p1B = false;
        }
        playerAction();
    }

    public void p2Aaction(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            p2A = true;
        }
        if (context.phase == InputActionPhase.Canceled) {
            p2A = false;
        }
        playerAction();
    }

    public void p2Baction(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            p2B = true;
        }
        if (context.phase == InputActionPhase.Canceled) {
            p2B = false;
        }
        playerAction();
    }
}
