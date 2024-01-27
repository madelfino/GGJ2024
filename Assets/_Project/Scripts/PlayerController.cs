using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : SubjectOfObserver
{
    private PlayerControls _playerControls;
    
    [Header("Observers")]
    [SerializeField] private PainScale _painScale;
    //Health
    
    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
        _playerControls.Player.XBtn.performed += OnXBtn;
        _playerControls.Player.XBtn.canceled += OnXBtnCanceled;
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

    void OnXBtn(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            NotifyObserver();
            print("X performed");
        }
    }
    void OnXBtnCanceled(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled)
        {
            NotifyObserver();
            print("X canceled");
        }
    }
    
    
}
