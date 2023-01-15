using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class detectBox : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("box") && HoldControl.Instance.isPicked)
        {
           PlayerMovement.Instance.isMoveable = false;
           PlayerMovement.Instance.MovementSpeed = 0;
        }
    }
}
