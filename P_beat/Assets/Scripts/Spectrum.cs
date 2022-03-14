using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour
{
    public int spectrumSize = 64;
    int SpectCnt;

    GameObject spectrumObj;
    public Material myMaterial;

    public GameObject pos;

    public int rotValue;

    public int rotValueY;

    void Start()
    {
        Material myMaterial = (Material)Resources.Load("Materials/EQ_Material");

        spectrumObj = new GameObject("Spectrum");
        for (int i = 0; i < spectrumSize; i++)
        {

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.GetComponent<MeshRenderer>().material = myMaterial;
            cube.transform.parent = gameObject.transform;
            cube.transform.localEulerAngles = new Vector3(0, rotValueY, (-i * 2) + rotValue);
            cube.transform.localPosition = cube.transform.up*1.6f;
            cube.transform.localScale = new Vector3(0.1f, 1, 0.1f);
        }


    }

    void Update()
    {
        float[] spectrum = new float[spectrumSize];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 0; i < spectrumSize; i++)
        {
            gameObject.transform.GetChild(i).transform.localScale = new Vector3(0.1f, 10 * spectrum[i], 0.1f); 
        }
    }
}
