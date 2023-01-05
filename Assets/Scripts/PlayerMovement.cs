using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _animator;
    [SerializeField] bool collisionDetected;

    [SerializeField] float _speed = 40;
    [SerializeField] int _FireForce = 10;
    private int _limiteDroite;
    private int _limiteGauche;
    private Vector3 positionJoueurDroite;
    private Vector3 positionJoueurGauche;
    private float positionJoueurGaucheX = 0;
    private float positionJoueurDroiteX = 0;
    public Vector3 velocityXZ;
    private float limitPosition;




    [SerializeField] GameObject LeftLimit, RightLimit;

    private void Awake()
    {
        // Récupération des limites droites et gauches entre lesquelles le player pourra se déplacer.
        LeftLimit = GameObject.FindWithTag("LeftBorder");
        RightLimit = GameObject.FindWithTag("RightBorder");
        // Debug.Log("found " + LeftLimit + " et aussi " + RightLimit + "."); OK
        _limiteGauche = (int)LeftLimit.transform.position.x;
        _limiteDroite = (int)RightLimit.transform.position.x;
        // Debug.Log("_limiteGauche = " + _limiteGauche + " et _limiteDroite = " + _limiteDroite + ".");  OK
    }

    private Vector2 _movement = Vector2.zero;

    private object other;

    private void Reset()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 movement)
    {
        _movement = movement;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if other collider is the "LeftBorder" or "Rightborder", the do something.
        if (other.gameObject.CompareTag("LeftBorder"))
        {
            // Debug.Log("Player has collided on the LEFT Border.");
            positionJoueurGauche = GetComponent<Rigidbody>().position;
            positionJoueurGaucheX = positionJoueurGauche.x;
            // Debug.Log("Player LEFT Border position is :" + positionJoueurGaucheX);
        }
        if (other.gameObject.CompareTag("RightBorder"))
        {
            // Debug.Log("Player has collided on the RIGHT Border.");
            positionJoueurDroite = GetComponent<Rigidbody>().position;
            positionJoueurDroiteX = positionJoueurDroite.x;

            // Debug.Log("Player RIGHT Border position is :" + positionJoueurDroiteX);
        }
    }

    private void FixedUpdate()
    {
        // Détection de collision à droite ou à gauche
        collisionDetected = Physics.Raycast(transform.position, Vector3.right,1f) || (Physics.Raycast(transform.position, Vector3.left, 1f));
        if (collisionDetected)
        {   
            if (positionJoueurGaucheX != 0 || positionJoueurDroiteX != 0)
            {
                limitPosition = transform.position.x;
                transform.position = new Vector3(limitPosition * _speed * Time.deltaTime, _movement.y * _speed * Time.deltaTime, 0);
            }
        }
        // Debug.Log("New limitPosition = " + limitPosition);
        // déplacement horizontal (Vector2) du player
        //transform.Translate(_movement * _speed * Time.deltaTime, relativeTo: Space.World);
        transform.Translate(_movement * _speed * Time.deltaTime, relativeTo: Space.World);
        // transform.position = new Vector3(transform.position.x * _speed * Time.deltaTime, _movement.y * _speed * Time.deltaTime, 0);

        //if (Mathf.Abs(positionJoueurGaucheX) == Mathf.Abs(_movement.x))
        //{
        //    Debug.Log("Valeur absolue droite égale à celle du joueur.");
        //}
        //if (Mathf.Abs(positionJoueurGaucheX) != Mathf.Abs(_movement.x))
        //{ 
        //   // _rb.velocity = new Vector3(_movement.x * _speed, _rb.velocity.y, _movement.y * _speed);
        //   // _ = new Vector3(_rb.velocity.x * Time.deltaTime, 0, _rb.velocity.z * Time.deltaTime);
        //}
        //else
        //{
        //    if (_movement.x < positionJoueurDroiteX)
        //    {
        //        _rb.velocity = new Vector3(_movement.x * _speed, _rb.velocity.y, _movement.y * _speed);
        //        _ = new Vector3(_rb.velocity.x * Time.deltaTime, 0, _rb.velocity.z * Time.deltaTime);
        //    }
        //}

        //On applique un déplacement en "x" et en "z" avec un facteur vitesse fixé par la valeur "_speed"
        //_rb.velocity = new Vector3(_movement.x * _speed, _rb.velocity.y, _movement.y * _speed);
        //Vector3 velocityXZ = new Vector3(_rb.velocity.x * Time.deltaTime, 0, _rb.velocity.z * Time.deltaTime);

        // On fait tourner l'animation dans le même sens que celui du vecteur de déplacement.
        // Pas utilisé ici car on souhaite que le player soit constamment face aux ennemis.
        /*
        if (velocityXZ != Vector3.zero)
        {
            _rb.rotation = Quaternion.LookRotation(velocityXZ, Vector3.up);
        }
        */
    }
}
