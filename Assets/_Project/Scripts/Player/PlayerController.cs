using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : SubjectOfObserver
{
    private PlayerControls _playerControls;
    
    [Header("Observers")]
    [SerializeField] private PainScale _painScale;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private DirtSplash _dirtSplash;
    
    
    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
        _playerControls.Player.XBtn.performed += OnXBtn;
        _playerControls.Player.XBtn.canceled += OnXBtnCanceled;
    }

    private void OnEnable()
    {
        if(_painScale != null && _playerHealth != null && _dirtSplash != null)
        {
            Attach(_painScale);
            Attach(_playerHealth);
            Attach(_dirtSplash);
        }
        else
            throw new NullReferenceException();
    }

    private void OnDisable()
    {
        if(_painScale != null && _playerHealth != null && _dirtSplash != null)
        {
            Detach(_painScale);
            Detach(_playerHealth);
            Detach(_dirtSplash);
        }
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
