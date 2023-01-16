using CASP.SoundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footStep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void footStep1()
    {
        if (PlayerMovement.Instance.onGround)
        {
            SoundManager.instance.Play("footStep", true);

        }
    }
}
