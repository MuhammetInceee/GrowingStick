using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _playerMovementSpeed = 1.5f;
    void Update()
    {
        if (SuccesCheck._isArrived && SuccesCheck._playerMove)
        {
            transform.Translate(Vector3.right * _playerMovementSpeed * Time.deltaTime, Space.Self);
        }
    }
}
