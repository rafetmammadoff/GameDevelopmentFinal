using CASP.SoundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tele : MonoBehaviour
{
    public static tele Instance;
    public bool isActive = true;
    public Animator teleAnim;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        teleAnim=GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isActive)
        {
            if (collision.transform.CompareTag("box"))
            {
                teleAnim.SetTrigger("active");
                SoundManager.instance.Play("tele", true);
                transform.tag = "activeTele";
                isActive= false;
            }
        }
    }
}
