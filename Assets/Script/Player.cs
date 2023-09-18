using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MoveBall : MonoBehaviour
{
    private int count;
    private Rigidbody rb;
    public float velocidade;
    public TMP_Text countText;
    public TMP_Text winText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        Time.timeScale = 1;
    }
    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        Vector3 movimento = new Vector3(movimentoHorizontal, 0.0f, movimentoVertical);
        rb.AddForce(movimento * velocidade);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pick up")
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.layer == 3)
        {
            winText.text = "TRY AGAIN";
            Time.timeScale = 0;
        }  
        
    }
    void SetCountText()
    {
        
        countText.text = "Pílulas: " + count.ToString() + "/13" ;
        if (count >= 13)
        {
            winText.text = "YAY •ᴗ•";
            Time.timeScale = 0;
        }
    }
}