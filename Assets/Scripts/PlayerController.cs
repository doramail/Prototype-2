using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement _movement;
    [SerializeField] SpawnManager _fireAction;

    public GameObject projectilePrefab;

    public void MoveCharacter(InputAction.CallbackContext ctx)
    {
        _movement.Move(ctx.ReadValue<Vector2>());
    }

    public void FireCharacter(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _fireAction.ProjectileLauch();
            // Chaque appui sur la touche paramétrée dans le Input System (ici "Espace") provoque un tir de pizza.
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    public void SpawnAnimal(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _fireAction.ProjectileLauch();
            // Chaque appui sur la touche paramétrée dans le Input System (ici "Espace") provoque un tir de pizza.
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

}
