using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_Ladder : MonoBehaviour {

    public GameObject ladderPlank;
    Camera mainCam;

    RaycastHit treeHit;
    RaycastHit treeHitL;
    RaycastHit treeHitR;
    // Use this for initialization
    void Start () {
        mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void instaNewPlank()
    {
        Ray rayToTree = new Ray(mainCam.transform.position, mainCam.transform.forward);

        Ray rayToTreeL = new Ray(mainCam.transform.position - transform.right * 0.1f, mainCam.transform.forward);
        Ray rayToTreeR = new Ray(mainCam.transform.position + transform.right * 0.1f, mainCam.transform.forward);

        if (Physics.Raycast(rayToTree, out treeHit))
        {
            if (treeHit.collider.CompareTag("Tree"))
            {
                if (Physics.Raycast(rayToTreeL, out treeHitL))
                {
                    if (Physics.Raycast(rayToTreeR, out treeHitR))
                    {
                        if (treeHitL.collider.gameObject == treeHitR.collider.gameObject)
                        {
                            Vector3 targetDif = treeHitR.point - treeHitL.point;
                            float angle = Vector3.Angle(targetDif, Vector3.forward);
                            print("angle  " + angle);

                            float sign = Mathf.Sign(Vector3.Dot(Vector3.up, Vector3.Cross(treeHitL.point, treeHitR.point)));
                            print("sign  " + sign);

                            float signed_angle = angle * sign;

                            print("signed_Angle  " + signed_angle);
                            

                            Vector3 newEuler = new Vector3(ladderPlank.transform.rotation.x, signed_angle, ladderPlank.transform.rotation.z);
                            Transform newRot = ladderPlank.transform;
                            newRot.localEulerAngles = newEuler;

                            //print(plankEuler);

                            Instantiate(ladderPlank, treeHit.point, newRot.rotation);
                        }
                        else if (treeHitL.collider.CompareTag("Tree"))
                        {
                            // gen at point plank will face left of the player


                        }
                        else if (treeHitR.collider.CompareTag("Tree"))
                        {
                            // gen at point plank will face right of the player


                        }
                    }
                }
            }
        }
        Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * 10, Color.green, 30);

        Debug.DrawRay(mainCam.transform.position - transform.right * 0.1f, mainCam.transform.forward * 10, Color.blue, 60);
        Debug.DrawRay(mainCam.transform.position + transform.right * 0.1f, mainCam.transform.forward * 10, Color.blue, 60);
    }

    /*float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n)
    {
        // angle in [0,180]
        float angle = Vector3.Angle(a, b);
        print("angle" + angle);
        
        print("sign" + sign);
        // angle in [-179,180]
        

        // angle in [0,360] (not used but included here for completeness)
        //float angle360 =  (signed_angle + 180) % 360;

        return signed_angle;
    }*/
}
