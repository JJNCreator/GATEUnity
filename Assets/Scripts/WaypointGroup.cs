using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointGroup : MonoBehaviour
{
    public int groupID = 0;
    public Transform[] waypointChildren;
    // Start is called before the first frame update
    void Start()
    {
        waypointChildren = transform.GetComponentsInChildren<Transform>();
        var toList = waypointChildren.ToList();
        toList.RemoveAt(0);
        waypointChildren = toList.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
