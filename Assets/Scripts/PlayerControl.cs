using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public Animator anim;
    private bool p1A, p1X, p2A, p2X;

    public void onAwake() {
        p1A = false;
        p2A = false;
        p1X = false;
        p2X = false;
    }

    public void playerAction() {
        anim.SetBool("p1A", p1A);
        anim.SetBool("p1X", p1X);
        anim.SetBool("p2A", p2A);
        anim.SetBool("p2X", p2X);
        Debug.Log(nextInputNeeded());
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

    public void p1Xaction(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            p1X = true;
        }
        if (context.phase == InputActionPhase.Canceled) {
            p1X = false;
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

    public void p2Xaction(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            p2X = true;
        }
        if (context.phase == InputActionPhase.Canceled) {
            p2X = false;
        }
        playerAction();
    }

    public string nextInputNeeded() {
        if (p1A && !p2A && !p1X && !p2X) {
            return "Hold Q, Press O";
        }
        if (p1A && p2A && !p1X && !p2X) {
            return "Release Q";
        }
        if (!p1A && p2A && !p1X && !p2X) {
            return "Hold O, Press W";
        }
        if (!p1A && p2A && p1X && !p2X) {
            return "Release O";
        }
        if (!p1A && !p2A && p1X && !p2X) {
            return "Hold W, Press P";
        }
        if (!p1A && !p2A && p1X && p2X) {
            return "Release W";
        }
        if (!p1A && !p2A && !p1X && p2X) {
            return "Hold P, Press Q";
        }
        if (p1A && !p2A && !p1X && p2X) {
            return "Release P";
        }
        return "You messed up!";
    }
}
