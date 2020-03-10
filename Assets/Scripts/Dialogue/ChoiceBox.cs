using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceBox : MonoBehaviour
{
    public Color selectecColor;
    public Color notSelectedColor;
    private TMPro.TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        Unchoose();
    }

    public void Choose()
    {
        textMesh.color = selectecColor;
    }

    public void Unchoose()
    {
        textMesh.color = notSelectedColor;
    }

    public void SetText(string text)
    {
        textMesh.text = text;
    }
}
