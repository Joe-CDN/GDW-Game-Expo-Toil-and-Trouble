using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPotion : MonoBehaviour
{
    private bool pickedUp;
    
    // Update is called once per frame
    void Update()
    {
        if(PersistanceManager.instance.useJoystick == true){
            pickUpWithUI();
        }
        else{
            pickUpWithKey();
        }
        if(pickedUp == true && OnlineMove.isGrabbing == true)
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            this.transform.parent = GameObject.Find("hand").transform;
            this.transform.position = GameObject.Find("hand").transform.position; // sets the position of the object to your hand position
            this.transform.rotation = GameObject.Find("hand").transform.rotation;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
            this.transform.parent = null;
        }
    }

    private void pickUpWithKey()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Vector3.Distance(this.transform.position, GameObject.Find("hand").transform.position) <= 1.5f)
        {
            pickedUp = !pickedUp;
            OnlineMove.isGrabbing = !OnlineMove.isGrabbing;
        }
    }
    private void pickUpWithUI()
    {
        if (PersistanceManager.instance.grabObject && Vector3.Distance(this.transform.position, GameObject.Find("hand").transform.position) <= 1.5f)
        {
            pickedUp = !pickedUp;
            OnlineMove.isGrabbing = !OnlineMove.isGrabbing;
            PersistanceManager.instance.grabObject = false;
        }
    }
}
