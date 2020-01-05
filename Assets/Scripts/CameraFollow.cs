using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ObjectFollow;
    public Vector2 minCamPos, maxCamPos;
    public float smoothTime;

    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(
            transform.position.x,
            ObjectFollow.transform.position.x,
            ref velocity.x, 
            smoothTime);
        float posY = Mathf.SmoothDamp(
            transform.position.y,
            ObjectFollow.transform.position.y,
            ref velocity.y,
            smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.x),
            transform.position.z);
    }

}
