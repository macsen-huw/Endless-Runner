using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public List<GameObject> layers;
    public List<float> layerSpeeds;

    private Material[] layerMaterials;

    // Start is called before the first frame update
    void Start()
    {
        //Set up the number of layaers and calculate their widths
        layerMaterials = new Material[layers.Count];

        for (int i = 0; i < layers.Count; i++) 
        {
            MeshRenderer meshRenderer = layers[i].GetComponent<MeshRenderer>();
            //Get sprite material
            layerMaterials[i] = meshRenderer.material;

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Update each layer
        for(int i = 0; i < layers.Count; i++)
        {
            layerMaterials[i].mainTextureOffset += new Vector2(layerSpeeds[i] * Time.deltaTime, 0f);
        }
        
    }
}
