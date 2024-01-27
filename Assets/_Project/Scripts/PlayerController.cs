using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : SubjectOfObserver
{
    private PlayerControls _playerControls;
    private bool p1A, p1X, p2A, p2X;

    [SerializeField] private Animator anim;
    [Header("Observers")]
    [SerializeField] private PainScale _painScale;
    //Health
    
    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
        //_playerControls.Player.XBtn.performed += OnXBtn;
        //_playerControls.Player.XBtn.canceled += OnXBtnCanceled;
    }

    private void OnEnable()
    {
        if(_painScale != null)
            Attach(_painScale);
        else
            throw new NullReferenceException();
    }

    private void OnDisable()
    {
        if(_painScale != null)
            Detach(_painScale);
    }

    public void playerAction() {
        NotifyObserver();
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
