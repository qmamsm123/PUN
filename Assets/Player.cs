using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATUS { MOVE, VIEW }
public class Player : MonoBehaviour {
    public static STATUS status;

    public float speed = 5;

    // Start is called before the first frame update
    void Start() {
        status = STATUS.MOVE;
    }

    // Update is called once per frame
    void Update() {
        if (status == STATUS.MOVE) {
            if (Input.GetKey(KeyCode.W))
                transform.position += Vector3.forward * Time.deltaTime * speed;
            if (Input.GetKey(KeyCode.A))
                transform.position += Vector3.left * Time.deltaTime * speed;
            if (Input.GetKey(KeyCode.S))
                transform.position += Vector3.back * Time.deltaTime * speed;
            if (Input.GetKey(KeyCode.D))
                transform.position += Vector3.right * Time.deltaTime * speed;
            //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * speed);

            if (Input.GetKeyDown(KeyCode.F)) {
                status = STATUS.VIEW;
                Debug.Log("status is changed: " + status.ToString());
                GameObject.Find("Main Camera").transform.parent = null;
                gameObject.SetActive(false);
            }
        }
    }
}
