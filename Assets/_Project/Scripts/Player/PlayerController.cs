using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : SubjectOfObserver
{
    private PlayerControls _playerControls;
    private bool p1A, p1X, p2A, p2X;
    private AudioSource audioSource;

    [SerializeField] private AudioClip[] fartSteps;
    [SerializeField] private Animator anim;
    [Header("Observers")]
    [SerializeField] private PainScale _painScale;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private DirtSplash _dirtSplash;
    [SerializeField] private GameState _gameState;
    [SerializeField] private TextMeshProUGUI _instructionText;
    
    
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
    }

    public void moveForward() {
        if (fartSteps.Length > 0) {
            audioSource.PlayOneShot(fartSteps[UnityEngine.Random.Range(0, fartSteps.Length)], 0.2f                                                                                                                                                                                                                                                                                                                                    );
        }
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
        string instructions = "You messed up!";
        if (p1A && !p2A && !p1X && !p2X) {
            instructions = "Hold Q, Press O";
        }
        if (p1A && p2A && !p1X && !p2X) {
            instructions = "Release Q";
        }
        if (!p1A && p2A && !p1X && !p2X) {
            instructions = "Hold O, Press W";
        }
        if (!p1A && p2A && p1X && !p2X) {
            instructions = "Release O";
        }
        if (!p1A && !p2A && p1X && !p2X) {
            instructions = "Hold W, Press P";
        }
        if (!p1A && !p2A && p1X && p2X) {
            instructions = "Release W";
        }
        if (!p1A && !p2A && !p1X && p2X) {
            instructions = "Hold P, Press Q";
        }
        if (p1A && !p2A && !p1X && p2X) {
            instructions = "Release P";
        }
        
        _instructionText.text = instructions;

        return instructions;
    }
}
