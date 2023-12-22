using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBasketball : MonoBehaviour
{
    public Transform other;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,other.position + Vector3.up * 4,5*Time.deltaTime);
    }
}
