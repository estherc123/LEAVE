using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField]
    private float XMinRotation;
    [SerializeField]
    private float XMaxRotation;
    [Range(1.0f, 10.0f)]
    [SerializeField]
    private float Xsensitivity;
    [Range(1.0f, 10.0f)]
    [SerializeField]
    private float Ysensitivity;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float runSpeed;
    private float rotAroundX, rotAroundY;
    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 moveDirection;
    private Rigidbody rb;

    private void Start()
    {
        rotAroundX = transform.eulerAngles.x;
        rotAroundY = transform.eulerAngles.y;
        rb = GetComponent<Rigidbody>();

    }

    public void MoveAndRotatePlayer(float XMInput,float YMInput, float HInput,float VInput)
    {


        rotAroundX += YMInput * Xsensitivity;
        rotAroundY += XMInput * Ysensitivity;
        rotAroundX = Mathf.Clamp(rotAroundX, XMinRotation, XMaxRotation);
        transform.rotation = Quaternion.Euler(0, rotAroundY, 0);
        // cam.MoveAndRotatePlayerCamera(Quaternion.Euler(-rotAroundX, rotAroundY, 0));
        cam.transform.rotation= Quaternion.Euler(-rotAroundX, rotAroundY, 0);
        horizontalMovement = HInput;
        verticalMovement = VInput;
        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
        rb.velocity = moveDirection * runSpeed * Time.fixedDeltaTime * 100;

    }

}
