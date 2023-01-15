using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using static UnityEditor.Progress;
using CASP.SoundManager;

public class HoldControl : MonoBehaviour
{
    public static HoldControl Instance;
    public bool isPicked = false;
    [SerializeField] Transform PickTransform;
    [SerializeField] float Radius;
    Collider[] Cols;
    [SerializeField] LayerMask LayerMask;
    public GameObject _PickedItem;
    HingeJoint hj;
    Rigidbody itemRb;
    bool inrope = false;
    bool isHoldIdleAnim=true;
    GameObject rope;
    void Start()
    {
        hj = PickTransform.GetComponent<HingeJoint>();
    }
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HoldObj();
        }
        if (Input.GetMouseButtonDown(1))
        {
            BrakeObj();
        }
        
    }

    private void BrakeObj()
    {
        if (isPicked)
        {
            EventHolder.Instance.PlayerHoldToIdle(gameObject);
            _PickedItem.AddComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            _PickedItem.transform.parent =null;
            isPicked = false;
            _PickedItem.gameObject.AddComponent<detectBox>();
            SoundManager.instance.Stop("holdTaxta");

        }
    }

    public void HoldObj()
    {
        Cols = Physics.OverlapSphere(PickTransform.position, Radius, LayerMask);
        foreach (Collider item in Cols)
        {
            if (!isPicked)
            {
                isPicked = true;
                _PickedItem = item.gameObject;
                _PickedItem.transform.parent = transform;
               Destroy(_PickedItem.GetComponent<Rigidbody>()); 
               item.gameObject.AddComponent<detectBox>();
                EventHolder.Instance.PlayerHoldIdleStart(gameObject);
            }
        }
    }
}
