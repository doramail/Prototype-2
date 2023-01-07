using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 velocityXZ;

    [SerializeField] Rigidbody _rb;
    [SerializeField] Animator _animator;
    [SerializeField] bool collisionDetected;
    [SerializeField] float _speed = 40;
    private Vector2 _movement = Vector2.zero;
    private Vector3 _triggerPosition;

    //public object other;

    [SerializeField] GameObject LeftLimit, RightLimit;

    private void Reset()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 movement)
    {
        _movement = movement;
    }

    public void OnTriggerEnter(Collider other)
    {
        collisionDetected = true;
        _triggerPosition.x = this.gameObject.transform.position.x; // Coordonnées du point de collision (coté player)
        //Debug.Log("limite latérale atteinte triggerPosition = " + _triggerPosition.x);
        float positionJoueur = GetComponent<Rigidbody>().position.x;
        //Debug.Log("Player triggerPosition = " + this._triggerPosition.x);
    }

    private void FixedUpdate()
    {
        Debug.Log("Player respawnPosition is : " + _rb.position.x);


        if (collisionDetected)
        {
            //Debug.Log("Player has collided on one Border at position :" + _triggerPosition);
        }
        if (transform.position.x < -26)
        {
            transform.position = _triggerPosition;
        }
        if (transform.position.x > 26)
        {
            transform.position = _triggerPosition;
        }
        transform.Translate(Vector3.right * _movement.x * Time.deltaTime * _speed);
    }
}
