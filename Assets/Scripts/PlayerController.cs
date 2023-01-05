using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement _movement;
    [SerializeField] MoveForward _fireAction;

    public GameObject projectilePrefab;

    public void MoveCharacter(InputAction.CallbackContext ctx)
    {
        _movement.Move(ctx.ReadValue<Vector2>());
    }

    public void FireCharacter(InputAction.CallbackContext ctx)
    {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
}
