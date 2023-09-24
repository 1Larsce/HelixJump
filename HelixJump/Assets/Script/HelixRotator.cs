using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float rotationSpeed = 300f;
    public float rotationSpeedAndroid = 50f;

    private void Update () {

        #if UNITY_EDITOR
                // this input is for pc its not working in mobile
                if(Input.GetMouseButton(0)) {
                    float mouseX = Input.GetAxisRaw ("Mouse X");
                    transform.Rotate(transform.position.x, -mouseX * rotationSpeed * Time.deltaTime, transform.position.z);
                }

        #elif UNITY_ANDROID

                //for mobile
                if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
                    float xDeltaPos = Input.GetTouch(0).deltaPosition.x;
                    transform.Rotate (transform.position.x, -xDeltaPos * rotationSpeedAndroid * Time.deltaTime, transform.position.z);
                }
        #endif
    }
}
