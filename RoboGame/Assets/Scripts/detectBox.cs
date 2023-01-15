using CASP.SoundManager;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ToonyColorsPro.ShaderGenerator.Enums;

public class detectBox : MonoBehaviour
{
    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("box") && HoldControl.Instance.isPicked)
        {
           PlayerMovement.Instance.isMoveable = false;
            SoundManager.instance.Stop("holdTaxta");
           PlayerMovement.Instance.MovementSpeed = 0;
        }
       
    }
}
