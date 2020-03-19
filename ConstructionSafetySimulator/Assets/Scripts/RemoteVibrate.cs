using Bhaptics.Tact.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteVibrate : MonoBehaviour {
    TactSource[] devices;

    Transform playerTrans;
    float distance;

    // Start is called before the first frame update
    void Start() {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        devices = GetComponents<TactSource>();

        if (Input.GetKeyDown(KeyCode.V)) {
            ActivateTrigger();
        }
    }



    private void ActivateTrigger() {
        distance = Vector3.Distance(transform.position, playerTrans.position);
        distance = Mathf.Abs(distance);
        distance = 1 / distance;

        StartCoroutine("Fade");
    }



    IEnumerator Fade() {


        for (int i = 0; i < 4; i++) {
            foreach (TactSource device in devices) {
                if (i == 0) {
                    device.DotPoints[0] = (byte) distance;
                    device.DotPoints[1] = 0;
                    device.DotPoints[2] = 0;
                    device.DotPoints[3] = (byte)distance;
                    device.DotPoints[4] = 0;
                    device.DotPoints[5] = 0;
                } else if (i == 1) {
                    device.DotPoints[0] = 0;
                    device.DotPoints[1] = (byte)distance;
                    device.DotPoints[2] = 0;
                    device.DotPoints[3] = 0;
                    device.DotPoints[4] = (byte)distance;
                    device.DotPoints[5] = 0;
                } else if (i == 2) {
                    device.DotPoints[0] = 0;
                    device.DotPoints[1] = 0;
                    device.DotPoints[2] = (byte)distance;
                    device.DotPoints[3] = 0;
                    device.DotPoints[4] = 0;
                    device.DotPoints[5] = (byte)distance;
                }

            }
            devices[0].Play();
            devices[1].Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
