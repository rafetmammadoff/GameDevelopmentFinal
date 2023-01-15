using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (transform.CompareTag("p1"))
        {
            Transform teleportTransform = GameObject.FindGameObjectWithTag("p2").transform;
            transform.DOScale(0, 0.1f).OnComplete(() =>
            {
                transform.position = new Vector3(teleportTransform.position.x, teleportTransform.position.y, teleportTransform.position.z - 1);
                transform.DOScale(1, 0.2f);
            });
        }
    }
}
