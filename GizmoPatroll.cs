using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoPatroll : MonoBehaviour
{
    [SerializeField]
    float Area;
    
    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), Area);
    }
}
