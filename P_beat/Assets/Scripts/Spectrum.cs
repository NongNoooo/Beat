using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour
{
    //public GameObject spectrumObj;

    public int spectrumSize = 64;
    int SpectCnt;

    GameObject spectrumObj;
    public Material myMaterial;

    public GameObject pos;

    public int rotValue;

    public int rotValueY;

    // Start is called before the first frame update
    void Start()
    {
        Material myMaterial = (Material)Resources.Load("Materials/EQ_Material");

        spectrumObj = new GameObject("Spectrum");
        for (int i = 0; i < spectrumSize; i++)
        {

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.GetComponent<MeshRenderer>().material = myMaterial;
            cube.transform.parent = gameObject.transform;
            //cube.transform.localPosition = new Vector3(0.1f * i, (1.6f - i), 0);
            cube.transform.localEulerAngles = new Vector3(0, rotValueY, (-i * 2) + rotValue);
            //cube.transform.position = cube.transform.parent.position + new Vector3(0.1f * i, (1.6f - i), 0);
            //cube.transform.localPosition = new Vector3((0.1f * i), 1.6f, 0);
            cube.transform.localPosition = cube.transform.up*1.6f;
            cube.transform.localScale = new Vector3(0.1f, 1, 0.1f);
        }


    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrum = new float[spectrumSize];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);


        for (int i = 0; i < spectrumSize; i++)
        {
            gameObject.transform.GetChild(i).transform.localScale = new Vector3(0.1f, 10 * spectrum[i], 0.1f); 
            /*
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
           */
        }
    }



}
