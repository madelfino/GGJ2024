using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : SubjectOfObserver
{
    public PlayerControls _playerControls;
    private bool p1A, p1X, p2A, p2X;
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] fartSteps;
    [SerializeField] private Animator anim;
    [Header("Observers")]
    [SerializeField] private PainScale _painScale;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private DirtSplash _dirtSplash;
    [SerializeField] private GameState _gameState;
    
    
    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Enable();
        //_playerControls.Player.XBtn.performed += OnXBtn;
        //_playerControls.Player.XBtn.canceled += OnXBtnCanceled;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if(_painScale != null && _playerHealth != null && _dirtSplash != null && _gameState != null)
        {
            Attach(_painScale);
            Attach(_playerHealth);
            Attach(_dirtSplash);
            Attach(_gameState);
        }
        else
            throw new NullReferenceException();
    }

    private void OnDisable()
    {
        if(_painScale != null && _playerHealth != null && _dirtSplash != null && _gameState != null)
        {
            Detach(_painScale);
            Detach(_playerHealth);
            Detach(_dirtSplash);
            Detach(_gameState);
        }
    }

    public void playerAction() {
        NotifyObserver();
        anim.SetBool("p1A", p1A);
        anim.SetBool("p1X", p1X);
        anim.SetBool("p2A", p2A);
        anim.SetBool("p2X", p2X);
        Debug.Log(nextInputNeeded());
        if (fartSteps.Length > 0) {
            audioSource.PlayOneShot(fartSteps[UnityEngine.Random.Range(0, fartSteps.Length)], 0.2f);
        }
    }

    public void p1Aaction(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            p1A = true;
            playerAction();
        }
        if (context.phase == InputActionPhase.Canceled) {
            p1A = false;
            playerAction();
        }
    }

    public void p1Xaction(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            p1X = true;
            playerAction();
        }
        if (context.phase == InputActionPhase.Canceled) {
            p1X = false;
            playerAction();
        }
    }

    public void p2Aaction(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            p2A = true;
            playerAction();
        }
        if (context.phase == InputActionPhase.Canceled) {
            p2A = false;
            playerAction();
        }
    }

    public void p2Xaction(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Started) {
            p2X = true;
            playerAction();
        }
        if (context.phase == InputActionPhase.Canceled) {
            p2X = false;
            playerAction();
        }
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
