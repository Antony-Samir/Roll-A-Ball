using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
   

    public float speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody rb;
    private int count;

    [SerializeField]
    private AudioClip _clip;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";       
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(_clip, other.transform.position, 1f);
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

    }
    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            WinText.text = "You Win! Now Bonus";
        }

        if (count >= 24)
        {
            WinText.text = "Game Over";
        }
    }
}
//Destroy(other.gameObject);
//if(other.gameObject.CompareTag("Player"))
//gameObject.SetActive(false);