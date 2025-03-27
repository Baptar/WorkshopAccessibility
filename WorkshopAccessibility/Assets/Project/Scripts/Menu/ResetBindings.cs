using UnityEngine;
using UnityEngine.InputSystem;

public class ResetBindings : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputAction;
    [SerializeField] private string targetControlScheme;

    public void ResetControlSchemeBinding()
    {
        foreach (InputActionMap map in inputAction.actionMaps)
        {
            foreach (InputAction action in map.actions)
            {
                action.RemoveBindingOverride(InputBinding.MaskByGroup(targetControlScheme));
            }
        }
    }
}
