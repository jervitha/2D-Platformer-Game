using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text winText;

    void Start()
    {
        winText.text = ""; // Hide the "You Win" message initially
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if (other.CompareTag("FinalLevel"))
        {
            Debug.Log("Finish point reached");
            winText.text = "You Win!";
        }
    }

}
