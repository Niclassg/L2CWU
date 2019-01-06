using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Range(0.1f, 10f)]
    [Tooltip("The speed the player moves at")]
    [SerializeField] private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed, ForceMode.Impulse);
    }
}
