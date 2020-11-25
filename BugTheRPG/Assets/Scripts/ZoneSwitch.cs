using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSwitch : MonoBehaviour
{
    public ZoneFiddling zoneScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pool" || other.tag == "Sand" || other.tag == "Tree" || other.tag == "Pond" || other.tag == "Line")
        {
            zoneScript.area = other.tag;
        }
        else if (other.tag == zoneScript.area)
        {
            
        }
    }
}
