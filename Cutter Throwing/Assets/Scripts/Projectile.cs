using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Projectile : MonoBehaviour
{
    private float clickTimer;
    private float moveForce;

    private bool throwable = false;

    private bool isMoving;

    [SerializeField] private GameObject nextThrowable;

    [SerializeField] private float moveFactor;
    // Start is called before the first frame update
    void Start()
    {
        clickTimer = .0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            InputController();
            Throw();
        }

        Move();
        Die();
    }

    private void InputController()
    {
        if (Input.GetMouseButton(0))
        {
            clickTimer += Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveForce = moveFactor * clickTimer;
            throwable = true;
            clickTimer = 0f;
        }
    }

    private void Throw()
    {
        if (throwable)
        {
            isMoving = true;
            throwable = !throwable;
            Instantiate(nextThrowable, new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
        }
    }

    private void Move()
    {
        if (isMoving)
        {
            transform.position += Vector3.forward * Time.deltaTime * moveForce;
        }
    }

    public void Die()
    {
        if(transform.position.z>= 7f)
        {Destroy(gameObject);}
    }

}
