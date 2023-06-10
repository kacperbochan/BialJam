using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TMP_Text Text;
    public ShipMovement ship;
    // Update is called once per frame
    void Update()
    {
        Text.text = ship.velocity.ToString();
    }
}
