using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class blender : MonoBehaviour
{
    public static blender Instance;

    public Animator anim;
    public bool isActive = true;
    public GameObject knife;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
    }

    void Update()
    {
        //if (!isActive)
        //{
        //    anim.SetTrigger("deactive");
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("box")||collision.transform.CompareTag("Player"))
        {
            transform.DOMoveY(transform.position.y - 0.1f, 0.5f);
            anim.SetTrigger("deactive");
            isActive = false;
            knife.GetComponent<AudioSource>().enabled= false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("box") || collision.transform.CompareTag("Player"))
        {
            transform.DOMoveY(transform.position.y + 0.1f, 0.5f);
            anim.SetTrigger("active");
            isActive = true;
            knife.GetComponent<AudioSource>().enabled = true;
        }
    }
}
