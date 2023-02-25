using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //1
    public float moveSpeed = 10f;

    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;

    public float distanceToGround = 0.01f;
    public LayerMask groundLayer;

    public GameObject bullet;
    public float bulletSpeed = 100f;

    private CapsuleCollider _col;
    
    //2
    private float _vInput;
    private float _hInput;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;




        // this.transform.Translate(Vector3.forward * (_vInput * Time.deltaTime));
        // this.transform.Rotate(Vector3.up * (_hInput * Time.deltaTime));

    }

    private void FixedUpdate()
    {
        
        Vector3 rotation = Vector3.up * _hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        
        _rigidbody.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * angleRot);
        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet,
                this.transform.position + new Vector3(1, 0, 0),
                this.transform.rotation) as GameObject;
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
        
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }

        
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer,
            QueryTriggerInteraction.Ignore);
        
        return grounded;
    }
}
