using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSroller : MonoBehaviour
{
    [SerializeField] float BackgroundScrollSpeed = 0.05f;

    Material myMaterial;

    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;

        offSet = new Vector2(0f, BackgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
