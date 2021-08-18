using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField]
    private float XMinRotation;
    [SerializeField]
    private float XMaxRotation;
    [Range(0.0f, 10.0f)]
    [SerializeField]
    private float Xsensitivity;
    [Range(0.0f, 10.0f)]
    [SerializeField]
    private float Ysensitivity;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float runSpeed = 2;
    private float rotAroundX, rotAroundY;
    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 moveDirection;
    private Rigidbody rb;
    private float timer;
    [SerializeField]
    private float bobbingSpeed;
    [SerializeField]
    private float bobbingAmount;
    [SerializeField]
    private float midpoint;

    private void Start()
    {
        rotAroundX = transform.eulerAngles.x;
        rotAroundY = transform.eulerAngles.y;
        rb = GetComponent<Rigidbody>();
        timer = 0.0F;

    }

    public void MoveAndRotatePlayer(float XMInput,float YMInput, float HInput,float VInput)
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = 6;
            Xsensitivity = 2;
            Ysensitivity = 2.5f;
            //Debug.Log("a" + 6);
        }
        else
        {
            runSpeed = 2;
            Xsensitivity =1;
            Ysensitivity =1.5f;
            //Debug.Log("a" + 2);
        }
        rotAroundX += YMInput * Xsensitivity;
        rotAroundY += XMInput * Ysensitivity;
        rotAroundX = Mathf.Clamp(rotAroundX, XMinRotation, XMaxRotation);
        transform.rotation = Quaternion.Euler(0, rotAroundY, 0);
        // cam.MoveAndRotatePlayerCamera(Quaternion.Euler(-rotAroundX, rotAroundY, 0));
        cam.transform.rotation= Quaternion.Euler(-rotAroundX, rotAroundY, 0);
        horizontalMovement = HInput;
        verticalMovement = VInput;
        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
        rb.velocity = new Vector3 (moveDirection.x * runSpeed * Time.fixedDeltaTime * 100, rb.velocity.y, moveDirection.z * runSpeed * Time.fixedDeltaTime * 100) ;

    }

    public void MoveAndRotatePlayerAuthentic(float MouseInput, float HInput, float VInput)
    {


        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = 6;
            Xsensitivity = 2;
            Ysensitivity = 2.5f;
            //Debug.Log("b" + 6);
        }
        else
        {
            runSpeed = 2;
            Xsensitivity = 1;
            Ysensitivity = 1.5f;
            //Debug.Log("b" + 2);
        }
        //Debug.Log(MouseInput);
        rotAroundX += MouseInput * Xsensitivity;
        rotAroundY += HInput * Ysensitivity;
        rotAroundX = Mathf.Clamp(rotAroundX, XMinRotation, XMaxRotation);
        transform.rotation = Quaternion.Euler(0, rotAroundY, 0);
        // cam.MoveAndRotatePlayerCamera(Quaternion.Euler(-rotAroundX, rotAroundY, 0));
        cam.transform.rotation = Quaternion.Euler(-rotAroundX, rotAroundY, 0);
        horizontalMovement = HInput;
        verticalMovement = VInput;
        moveDirection = (verticalMovement * transform.forward).normalized;
        rb.velocity = new Vector3(moveDirection.x * runSpeed * Time.fixedDeltaTime * 100, rb.velocity.y, moveDirection.z * runSpeed * Time.fixedDeltaTime * 100);
        headbob(HInput, VInput);

    }

    private void headbob(float HInput, float VInput)
    {
        float waveslice = 0.0F;
        float horizontal = HInput;
        float vertical = VInput;
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0F;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0F, 1.0F);
            translateChange = totalAxes * translateChange;
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, midpoint + translateChange, cam.transform.localPosition.z);
        }
        else
        {
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, midpoint, cam.transform.localPosition.z);
        }
    }

}
