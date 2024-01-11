using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    private Vector3 pos = new Vector3(0, 10, -10);

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + pos;
        //∏∂øÏΩ∫ »Ÿ∑Œ ¡‹¿Œ/¡‹æ∆øÙ
        float wheel = Input.mouseScrollDelta.y;
        Camera.main.fieldOfView += wheel * -10;
    }
}


