using UnityEngine.InputSystem;
using UnityEngine;

public class changeVal : MonoBehaviour
{
    public InputActionReference play;
    private Animator _animator;
    [SerializeField] private bool animeTrue;

    void Start()
    {
        _animator = GetComponent<Animator>();
        //abonnement au action
        if (play != null)
        {
            play.action.Enable();
            play.action.performed += OnPlayPressed;
            play.action.canceled += OnPlayRelease;
        }
    }
    //desabonnement au action
    private void OnDestroy()
    {
        if (play != null)
        {
            play.action.performed -= OnPlayPressed;
            play.action.canceled -= OnPlayRelease;
            play.action.Disable();
        }
    }


    private void OnPlayRelease(InputAction.CallbackContext context)
    {
        animeTrue = false; 
        _animator.SetBool("switchAnime", animeTrue);
    }


    private void OnPlayPressed(InputAction.CallbackContext context)
    {
        animeTrue = true; 
        _animator.SetBool("switchAnime", animeTrue);
    }

    private void OnValidate()
    {
        if (_animator != null)
        {
            _animator.SetBool("switchAnime", animeTrue);
        }
    }
}
