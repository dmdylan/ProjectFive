using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject objectToFollow;
    public float yOffset = 15;
    public float speed = 2.0f;

    void Update()
    {
        float interpolation = speed * Time.deltaTime;

        Vector3 position = this.transform.position;

        //position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
        position.y = yOffset;
        position.z = Mathf.Lerp(this.transform.position.z, objectToFollow.transform.position.z, interpolation);

        this.transform.position = position;
    }

}
