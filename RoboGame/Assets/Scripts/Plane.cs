using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public Animator PlaneAnim;
    public Animator PerAnim;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlaneAnim.SetTrigger("active");
            PerAnim.SetTrigger("active");
            StartCoroutine(WaitFly());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
        }
    }


    public IEnumerator WaitFly()
    {
        yield return new WaitForSeconds(0.5f);
        transform.DOMoveY(transform.position.y + 8, 4).OnComplete(() =>
        {
            transform.DOMoveY(.8f, 4).OnComplete(() =>
            {
                PlaneAnim.SetTrigger("deactive");
            });
        });
    }
}
