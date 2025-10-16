using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class scripAnimation : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    private InputActionReference toggleButtonAction;

    private bool toggleState = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject.");
            return;
        }

        if (toggleButtonAction != null)
        {
            toggleButtonAction.action.Enable();
            toggleButtonAction.action.performed += OnButtonPressed;
        }
    }

    private void OnButtonPressed(InputAction.CallbackContext context)
    {
        toggleState = !toggleState;

        if (!toggleState)
        {
            animator.SetBool("start", true);
            animator.SetBool("start2", false);
            Debug.Log("Animation 'start' ");
        }
        else
        {
            animator.SetBool("start", false);
            animator.SetBool("start2", true);
            Debug.Log("Animation 'start2' ");
        }
    }

    void OnDestroy()
    {
        if (toggleButtonAction != null)
        {
            toggleButtonAction.action.performed -= OnButtonPressed;
            toggleButtonAction.action.Disable();
        }
    }

    void Update()
    {

    }
}