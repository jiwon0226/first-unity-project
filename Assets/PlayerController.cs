using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    bool isJumping = false;
    private Vector3 dir = Vector3.zero;
    public float jumpForce = 10.0f;
    public float maxJumpForce = 10.0f;
    // Start is called before the first frame update


    Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    void OnCollisionEnter(Collision collision) //�浹 ����
    {
        if (collision.gameObject.tag == "Floor")
        { //tag�� Floor�� ������Ʈ�� �浹���� ��
            isJumping = false; //isJumping�� �ٽ� true��
        }
    }
    // Update is called once per frame
    void Update()
    {

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        
            if (dir != Vector3.zero && isJumping == false)
            {
                transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * 50);
                //transform.forward = dir;
                rb.MovePosition(transform.position + dir * 10 * Time.deltaTime);//�Ű������� �̵��� ��ġ�� ������ ��
            }
           
        if (Input.GetKey(KeyCode.Space))
        {

            //if(Input.GetKeyDown())
            if (jumpForce < maxJumpForce)
            {
                jumpForce += Time.deltaTime * 15;
            }

        }
        if (Input.GetKeyUp(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
            Vector3 temp = Vector3.up + transform.forward;
            temp.Normalize();
            Vector3 direction = temp;
            rb.AddForce(direction * jumpForce, ForceMode.VelocityChange);
            jumpForce = 0.0f;
        }
        anim.SetBool("IsRun", dir != Vector3.zero );
        anim.SetBool("IsJump", isJumping);
    }

    

}