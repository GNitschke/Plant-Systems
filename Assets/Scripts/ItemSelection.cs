using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSelection : MonoBehaviour
{
    public Camera cam;
    public TurnManager turnManager;

    private bool down;
    private bool up;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        Debug.Log(cam.scaledPixelHeight * 0.8 - 50);
        Debug.Log(transform.position.y);
        down = false;
        up = false;
    }

    
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, 1 << 9) && hit.transform.GetComponent<ItemSelection>() != null && transform.position.y < cam.scaledPixelHeight * 0.8 - 50)
        {
            while(transform.position.y < cam.scaledPixelHeight * 0.9 - 50)
            {
                transform.Translate(0, 60, 0);
            }
        }

        float targetY = cam.scaledPixelHeight * 0.9f - 50.0f;
        if (transform.position.y < targetY && up)
        {
            transform.Translate(0, 60, 0);
        }
        if (transform.position.y > targetY)
        {
            up = false;
            transform.SetPositionAndRotation(new Vector3(transform.position.x, targetY, transform.position.z), Quaternion.identity);
        }

        if (transform.position.y > 63 && down)
        {
            transform.Translate(0, -60, 0);
        }
        if(transform.position.y < 63)
        {
            down = false;
            transform.SetPositionAndRotation(new Vector3(transform.position.x, 63, transform.position.z), Quaternion.identity);
        }
    }
    

    public void GoUp()
    {
        up = true;
        down = false;
        turnManager.picking = true;
    }

    public void GoDown()
    {
        down = true;
        up = false;
        turnManager.picking = false;
    }
}
