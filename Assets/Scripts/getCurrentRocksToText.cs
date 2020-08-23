using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getCurrentRocksToText : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = ApplicationModel.currentRocks.ToString();
    }
}
