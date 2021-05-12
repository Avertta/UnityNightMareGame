using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TakingCover
{

    //Just an example to taking cover to a close wall
    public class TakeCover : MonoBehaviour
    {
        RaycastHit wall;
        public Animator anim;
        void Start()
        {
            anim = GetComponent<Animator>();
        }
        void Update()
        {
            if (Physics.Raycast(transform.position, new Vector3(0,0,1), out wall, 10.0f))
            { 
               if(wall.collider.gameObject.tag == "Player")
                {
                    if (anim == null)
                    { 
                        anim.Play("Base Layer.Stand To Cover", 0, 1.0f);
                    }
                }
            }
        }
    }
}
