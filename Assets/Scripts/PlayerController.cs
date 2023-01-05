using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement _movement;
 //   [SerializeField] SpawnManager _fireAction;
    [SerializeField] SpawnManager _spawnEnnemi;
    private bool _fireAction = false;

    public GameObject projectilePrefab;

    public void MoveCharacter(InputAction.CallbackContext ctx)
    {
        _movement.Move(ctx.ReadValue<Vector2>());
    }

    public void FireCharacter(InputAction.CallbackContext ctx)
    {
            _fireAction = true; // fire action triggered.
    }

    public void SpawnAnimal(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _spawnEnnemi.SpawnEnnemi();
        }
    }

    void Update()
    {
        if (_fireAction == true)
        {
            // Chaque appui sur la touche paramétrée dans le Input System (ici "Espace") provoque un tir de 2 pizzas .
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            _fireAction = false; // Arrête le spawn des ennemis.
        }
    }

}
