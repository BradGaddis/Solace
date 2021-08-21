using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* TODO:
 * add slight buffer before the cameras moves...at least on the x axis to see how it looks
 */
public class CameraController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 playerPos = player.transform.position;
        //cam.transform.position = new Vector3(playerPos.x, playerPos.y, cam.transform.position.z);
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);

    }
}
