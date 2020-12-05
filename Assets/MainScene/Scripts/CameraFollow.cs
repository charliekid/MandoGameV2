using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xMargin = -1f;
    public float xMove = 8f;
    public float yMove = 8f;
    public Vector2 maxXandY;
    public Vector2 minXandY;

    private Transform thePlayer;
    // Start is called before the first frame update
    private void Awake()
    {
        thePlayer = GameObject.Find("Player (1)").transform;
    }

    private bool CheckXMargin()
    {
        return (transform.position.x - thePlayer.position.x) < xMargin;
    }

    private void Update()
    {
        trackPlayer();
    }

    // Update is called once per frame
    private void trackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, thePlayer.position.x, xMove * Time.deltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXandY.x, maxXandY.x);

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
