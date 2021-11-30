using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Photon.Pun;

public class OnlineMove : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float groundDistance = 0.4f;
    public Transform cam;
    public Joystick joystick;
    public static Button pickUp;
    public PhotonView view;
    public RawImage page;
    
    //public bool is3rdPerson = true;
    public static bool isGrabbing;
    Vector3 moveDir;

    float horizontal;
    float vertical;
    public float speed = 6f;
    public float gravity = -9.81f;

    Vector3 velocity;    
    public Vector3 camOffset;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool isGrounded;
    bool lookedAt;
    
    void Start()
    {
        lookedAt = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(view.IsMine == true){
            cam.position = transform.position + camOffset;

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0){
                velocity.y = -1f;
            }

            if(PersistanceManager.instance.useJoystick == true){
                horizontal = joystick.Horizontal;
                vertical = joystick.Vertical;  
            }
            if(PersistanceManager.instance.useJoystick == false){
                horizontal = Input.GetAxisRaw("Horizontal");
                vertical = Input.GetAxisRaw("Vertical");
            }  
            joystick.gameObject.SetActive(PersistanceManager.instance.useJoystick);
            pickUp.gameObject.SetActive(PersistanceManager.instance.useJoystick);

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);

                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }

            lookForBook();
        }
    }
    public void playerPickUp()
    {
        //PersistanceManager.instance.grabObject = !PersistanceManager.instance.grabObject;
        PersistanceManager.instance.grabObject = true;        
    }
    public void lookForBook()
    {
        if(PersistanceManager.instance.useJoystick == true){
            if(Vector3.Distance(this.transform.position, GameObject.Find("recipeBook").transform.position) <= 2f){
                lookedAt = true; 
            }
            if(Vector3.Distance(this.transform.position, GameObject.Find("recipeBook").transform.position) > 2f){
                lookedAt = false;
            }  
        }
        if(PersistanceManager.instance.useJoystick == false){
            if(Vector3.Distance(this.transform.position, GameObject.Find("recipeBook").transform.position) <= 2f && Input.GetKeyDown(KeyCode.E)){
                lookedAt = !lookedAt; 
            }
            if(Vector3.Distance(this.transform.position, GameObject.Find("recipeBook").transform.position) > 2f){
                lookedAt = false;
            }
        }
        page.gameObject.SetActive(lookedAt);
    }
    public void SetData(GameObject cameraParent) {
        Joystick[] joys = cameraParent.GetComponentsInChildren<Joystick>();
        foreach (Joystick joy in joys)
        {
            if (joy.name == "MoveControl")
                joystick = joy;
        }
        Button[] btns = cameraParent.GetComponentsInChildren<Button>();
        foreach (Button btn in btns)
        {
            if (btn.name == "Pickup")
                pickUp = btn;
        }
        pickUp.onClick.AddListener(playerPickUp);
        RawImage[] RIs = cameraParent.GetComponentsInChildren<RawImage>();
        foreach (RawImage RI in RIs)
        {
            if (RI.name == "RecipeBook")
                page = RI;
        }
        CinemachineVirtualCamera brain = cameraParent.GetComponentInChildren<CinemachineVirtualCamera>();
        brain.LookAt = this.transform;
        //brain.Follow = this.transform;
        cam = cameraParent.transform;
    }
}
