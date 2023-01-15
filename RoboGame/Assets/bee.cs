using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0, 19);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move()
    {
        transform.DOMove(new Vector3(transform.position.x + 20, transform.position.y, transform.position.z), 8).OnComplete(() =>
        {
            transform.DORotate(new Vector3(transform.rotation.x, -90, transform.rotation.z), 1).OnComplete(() =>
            {
                transform.DOMove(new Vector3(transform.position.x - 20, transform.position.y, transform.position.z), 8).OnComplete(() =>
                {
                    transform.DORotate(new Vector3(transform.rotation.x, -270, transform.rotation.z), 1);
                });
            });
        });
    }
}
