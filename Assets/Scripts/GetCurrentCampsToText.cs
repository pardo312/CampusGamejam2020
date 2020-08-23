using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetCurrentCampsToText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = ApplicationModel.currentCampsDestroyed.ToString();
    }
}
