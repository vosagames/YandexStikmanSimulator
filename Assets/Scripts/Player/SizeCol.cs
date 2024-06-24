using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeCol : MonoBehaviour
{
   public void SetSize()
    {
       var coll = gameObject.GetComponent<CapsuleCollider>();
        coll.height = 1.1f;
    }
    public void Default()
    {
        var coll = gameObject.GetComponent<CapsuleCollider>();
        coll.height = 1.77f;
    }
}
