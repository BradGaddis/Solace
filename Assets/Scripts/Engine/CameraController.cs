using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* TODO:
 * Lerp the camera to give just a slight buffer before the camera moves after the player moves
 * Camera should be bounded in single rooms like the cabin
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
        Vector3 playerPos = player.transform.position;

        Vector3 newPos = new Vector3(playerPos.x, playerPos.y, playerPos.z - 3f);

        Camera.main.transform.position = newPos;

    }
}
