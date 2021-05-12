using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PlayerJoystick
{
    public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        public Transform player;
        Vector3 move;
        public float moveSpeed;
        public RectTransform pad;
        float running;
        
        
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
            transform.localPosition =
                Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);
            move = new Vector3(transform.localPosition.x, 0, transform.localPosition.y).normalized;
            if (running <= 0.2f)
            {
              
                player.GetComponent<Animator>().SetFloat("running", 1.0f);

            }
            else
            {
                player.GetComponent<Animator>().SetFloat("running", 0.0f);


            }
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            transform.localPosition = Vector3.zero;
            move = Vector3.zero;
            StopCoroutine("PlayerMove");

            running = 0.0f;
            player.GetComponent<Animator>().SetFloat("running", 0.0f);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            StartCoroutine("PlayerMove");

        }
        IEnumerator PlayerMove()
        {
            while (true)
            {
                player.Translate(move * moveSpeed * Time.deltaTime, Space.World);
                if (move != Vector3.zero)
                    player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 12 * Time.deltaTime);


                yield return null;
            }
        }

       


    }
}
