using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTukamuman3 : MonoBehaviour
{

    public static Vector3 TerceroLocalPos;
    public static Quaternion TerceroLocalRot;
    int freeze,d;
    Rigidbody rbo;
    Collider m_object, finger;
    int c;
    private Vector3 phantom;
    public static int grabpreparation2;
    public static bool grabswitch = false;
    public string save_name;
    public bool save_name_tf = false;


    void Start()
    {
        rbo = this.transform.GetComponent<Rigidbody>();
        m_object = GetComponent<Collider>();
        GameObject Finger = GameObject.Find("Finger_F1");
    }

    void Update()
    {

        //print(this.gameObject.transform.parent.name);

        if (OVRInput.Get(OVRInput.RawButton.X) == false)
        {
            
            //string parent;
            //parent = this.gameObject.transform.parent.tag;
            //if (parent == "robothand")
            //{
                //this.gameObject.transform.parent = null;
            //}
            var rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            print("離したはず");
            m_object.isTrigger = false;
            grabpreparation2 = 0;
            /*if (save_name_tf == true)
            {
                this.gameObject.name = save_name;
                save_name_tf = false;
                save_name = null;
            }*/
            
        }

        if (OVRInput.Get(OVRInput.RawButton.X))
        {
            finger = this.gameObject.GetComponent<Collider>();
            finger.isTrigger = false;
        }
    }

    void OnCollisionStay(Collision col)
    {

        if (col.gameObject.tag == "Finger" && OVRInput.Get(OVRInput.RawButton.X) && this.gameObject.name != "HV_assembled")
        {

            if (CubeTukamuman2.grabpreparation == 1)
            {
                GameObject.Find("InvisibleObject").transform.rotation = this.gameObject.transform.rotation;
                this.gameObject.transform.parent = GameObject.Find("InvisibleObject").transform;
                grabpreparation2 = 2;
                print("ワシじゃよ1");
                //save_name = this.gameObject.name;
               // this.gameObject.name = "HV";
                //save_name_tf = true;
            }

            if(CubeTukamuman2.grabpreparation == 3)
            {
                //Rigidbodyを取得
                var rb = GetComponent<Rigidbody>();

                //isKinematicをオンにする
                rb.isKinematic = true;

                GameObject.Find("TerceroPhantom").transform.parent = this.gameObject.transform;
                TerceroLocalPos = GameObject.Find("TerceroPhantom").transform.localPosition;
                TerceroLocalRot = GameObject.Find("TerceroPhantom").transform.localRotation;
                print(TerceroLocalPos);
                print(TerceroLocalRot);
                print("ワシじゃよ3");
                grabswitch = true;
            }

            
        }

    }

}
