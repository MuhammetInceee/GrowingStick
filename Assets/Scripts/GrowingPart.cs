using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPart : MonoBehaviour
{
    private static GrowingPart _instance;
    public static GrowingPart Instace
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager is NULL");
            return _instance;
        }
    }

    private Vector3 _scaleChange;
    private Vector3 _positionChange;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        _scaleChange = new Vector3(0, 1, 0);
        _positionChange = new Vector3(0, 0.5f, 0);
    }
    void Update()
    {
        if (GameManager.Instace._holding)
        {
            transform.localScale += _scaleChange * Time.deltaTime;
            transform.position += _positionChange * Time.deltaTime;
        }
        if (transform.localEulerAngles.z < 271 && GameManager.Instace._ungrow && transform.localEulerAngles.z != 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 270);
        }
    }

    public void Rotating()
    {
        GetComponent<HingeJoint2D>().useMotor = true;
        GetComponent<Rigidbody2D>().freezeRotation = false;
    }
}
