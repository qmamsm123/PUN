using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {
    public GameObject player;
    public float speed = 1;
    public float radius = 3;

    // Start is called before the first frame update
    void Start() {
        transform.parent = player.transform;
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
        transform.Translate(new Vector3(0, 5, -10));
    }

    // Update is called once per frame
    void FixedUpdate() {
        switch (Player.status) {
            case STATUS.VIEW:
                if (Input.GetKey(KeyCode.W))
                    transform.position += transform.localRotation * Vector3.forward * Time.deltaTime * speed;
                if (Input.GetKey(KeyCode.A))
                    transform.position += transform.localRotation * Vector3.left * Time.deltaTime * speed;
                if (Input.GetKey(KeyCode.S))
                    transform.position += transform.localRotation * Vector3.back * Time.deltaTime * speed;
                if (Input.GetKey(KeyCode.D))
                    transform.position += transform.localRotation * Vector3.right * Time.deltaTime * speed;

                if (Input.GetKeyDown(KeyCode.F)) {
                    Player.status = STATUS.MOVE;
                    Debug.Log("status is changed: " + Player.status.ToString());
                    player.SetActive(true);
                    transform.parent = player.transform;
                    transform.position = player.transform.position;
                    transform.rotation = player.transform.rotation;
                    transform.Translate(new Vector3(0, 5, -10));
                }
                break;
            case STATUS.MOVE:
                transform.LookAt(player.transform);
                break;
        }
    }
}
