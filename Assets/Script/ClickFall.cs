using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ClickFall : MonoBehaviour
{
    [SerializeField]
    private InputActionReference triggerAction;

    private RigidBodyScript[] allRigidBodyScripts;

    void Start()
    {
        allRigidBodyScripts = FindObjectsOfType<RigidBodyScript>();

        if (triggerAction != null)
        {
            triggerAction.action.Enable();
            triggerAction.action.performed += OnTriggerPressed;
        }
    }

    private void OnTriggerPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Bouton pressé !");
        TriggerFallForAllObjects();
    }

    private void TriggerFallForAllObjects()
    {
        if (allRigidBodyScripts.Length == 0)
        {
            Debug.LogWarning("Aucun RigidBodyScript trouvé dans la scène !");
            return;
        }

        foreach (var rigidBodyScript in allRigidBodyScripts)
        {
            if (rigidBodyScript != null)
            {
                rigidBodyScript.ActivateRigidbody();
            }
        }

    }

    void Update()
    {
        
    }

    void OnDestroy()
    {
        if (triggerAction != null)
        {
            triggerAction.action.performed -= OnTriggerPressed;
        }
    }
}