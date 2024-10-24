using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float zoom;
    float x,y;  

    private void Start()
    {
        zoom = Camera.main.orthographicSize;
        x = 0;
        y = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (zoom < 500)
            {
                zoom += .1f;
                Camera.main.orthographicSize = zoom;
            }
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            if (zoom > 5)
            {
                zoom -= .1f;
                Camera.main.orthographicSize = zoom;
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Camera.main.orthographicSize = 10;
            Camera.main.transform.position = new Vector3(0,0,-10);
        }

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        Camera.main.transform.position += new Vector3(x/10,y/10,0);
    }
}
