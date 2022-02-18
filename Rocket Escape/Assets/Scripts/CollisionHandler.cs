using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This object is Friendly.");
                break;
            case "Finish":
                Debug.Log("Congrat!!!");
                break;
            case "Fuel":
                Debug.Log("You have collected fuel.");
                break;
            default:
                Debug.Log("Take Damage");
                break;
        }
    }
}
