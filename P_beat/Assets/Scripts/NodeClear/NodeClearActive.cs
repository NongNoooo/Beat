using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NodeClearActive : MonoBehaviour
{


    public GameObject d_key;
    public GameObject f_key;
    public GameObject g_key;
    public GameObject h_key;
    public GameObject j_key;
    public GameObject k_key;

    public GameObject d_Dummy;
    public GameObject f_Dummy;
    public GameObject g_Dummy;
    public GameObject h_Dummy;
    public GameObject j_Dummy;
    public GameObject k_Dummy;

    Renderer dr;
    Renderer fr;
    Renderer gr;
    Renderer hr;
    Renderer jr;
    Renderer kr;

    Material dm;
    Material fm;
    Material gm;
    Material hm;
    Material jm;
    Material km;


    float intensity = 2.4169f;
    float bintensity = 4.4169f;

    public GameObject DmeshCut;
    public GameObject FmeshCut;
    public GameObject GmeshCut;
    public GameObject HmeshCut;
    public GameObject JmeshCut;
    public GameObject KmeshCut;




    public GameObject d_saber;
    public GameObject f_saber;
    public GameObject g_saber;
    public GameObject h_saber;
    public GameObject j_saber;
    public GameObject k_saber;

    Material dsm;
    Material fsm;
    Material gsm;
    Material hsm;
    Material jsm;
    Material ksm;

    Renderer dsr;
    Renderer fsr;
    Renderer gsr;
    Renderer hsr;
    Renderer jsr;
    Renderer ksr;


    Animator d_anim;
    Animator f_anim;
    Animator g_anim;
    Animator h_anim;
    Animator j_anim;
    Animator k_anim;

    //public GameObject[] keys;
    //public GameObject[] dummys;
    //Renderer[] dummyRenders;
    //Material[] materials;
    //Animator[] anims;

    //public GameObject[] lightSabers;
    //Renderer[] lightSaberRenders;
    //Material[] lightSaberMaterials;


    void Start()
    {
        d_key = transform.GetChild(0).gameObject;
        f_key = transform.GetChild(1).gameObject;
        g_key = transform.GetChild(2).gameObject;
        h_key = transform.GetChild(3).gameObject;
        j_key = transform.GetChild(4).gameObject;
        k_key = transform.GetChild(5).gameObject;

        dr = d_Dummy.transform.GetChild(1).GetComponent<Renderer>();
        fr = f_Dummy.transform.GetChild(1).GetComponent<Renderer>();
        gr = g_Dummy.transform.GetChild(1).GetComponent<Renderer>();
        hr = h_Dummy.transform.GetChild(1).GetComponent<Renderer>();
        jr = j_Dummy.transform.GetChild(1).GetComponent<Renderer>();
        kr = k_Dummy.transform.GetChild(1).GetComponent<Renderer>();

        dm = dr.material;
        fm = fr.material;
        gm = gr.material;
        hm = hr.material;
        jm = jr.material;
        km = kr.material;

        dsr = d_saber.GetComponent<Renderer>();
        dsm = dsr.material;

        fsr = f_saber.GetComponent<Renderer>();
        fsm = fsr.material;

        gsr = g_saber.GetComponent<Renderer>();
        gsm = gsr.material;

        hsr = h_saber.GetComponent<Renderer>();
        hsm = hsr.material;

        jsr = j_saber.GetComponent<Renderer>();
        jsm = jsr.material;

        ksr = k_saber.GetComponent<Renderer>();
        ksm = ksr.material;

        d_anim = d_Dummy.GetComponent<Animator>();
        f_anim = f_Dummy.GetComponent<Animator>();
        g_anim = g_Dummy.GetComponent<Animator>();
        h_anim = h_Dummy.GetComponent<Animator>();
        j_anim = j_Dummy.GetComponent<Animator>();
        k_anim = k_Dummy.GetComponent<Animator>();


        //for(int i = 0; i < 6; i++)
        //{
        //    keys[i] = transform.GetChild(i).gameObject;
        //    dummyRenders[i] = dummys[i].transform.GetChild(1).GetComponent<Renderer>();
        //    materials[i] = dummyRenders[i].material;
        //    anims[i] = dummys[i].GetComponent<Animator>();

        //    lightSaberRenders[i] = lightSabers[i].GetComponent<Renderer>();
        //    lightSaberMaterials[i] = lightSaberRenders[i].material;
        //}
    }

    void getMaterial(Renderer r, GameObject g, Material m)
    {
        r = g.GetComponent<Renderer>();
        m = r.material;
    }
    

    void Update()
    {
        ButtonActive();
    }

    void ButtonActive()
    {
        Dkey();
        Fkey();
        Gkey();
        Hkey();
        Jkey();
        Kkey();

    }

    void ColorChange(Material a, string b)
    {
        if (b == "Black")
        {
            a.SetVector("_EmissionColor", Color.black * intensity);
        }
        if (b == "Green")
        {
            a.SetVector("_EmissionColor", Color.green * intensity);
        }
        if (b == "Yellow")
        {
            a.SetVector("_EmissionColor", Color.yellow * intensity);
        }
        if (b == "Cyan")
        {
            a.SetVector("_EmissionColor", Color.cyan * intensity);
        }
        if (b == "White")
        {
            a.SetVector("_EmissionColor", Color.white * intensity);
        }
        if (b == "Red")
        {
            a.SetVector("_EmissionColor", Color.red * intensity);
        }
        if (b == "Blue")
        {
            a.SetVector("_EmissionColor", Color.blue * bintensity);
        }
    }

    void Dkey()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            d_key.SetActive(true);

            ColorChange(dm,"Green");
            ColorChange(dsm, "Green");

            DmeshCut.SetActive(true);

            d_anim.SetTrigger("Slash");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            d_key.SetActive(false);

            DmeshCut.SetActive(false);

            NodeCrash nc = d_key.GetComponent<NodeCrash>();
            nc.GetkeyUp();
        }
    }

    public void DummyColor_Black(string name)
    {
        if(name == "Light_D")
        {
            ColorChange(dm, "Black");
            ColorChange(dsm, "Black");
            Debug.Log("D키 검은색으로 변함");

            return;
        }
        else if (name == "Light_F")
        {
            ColorChange(fm, "Black");
            ColorChange(fsm, "Black");

            return;
        }
        else if (name == "Light_G")
        {
            ColorChange(gm, "Black");
            ColorChange(gsm, "Black");

            return;
        }
        else if (name == "Light_H")
        {
            ColorChange(hm, "Black");
            ColorChange(hsm, "Black");

            return;
        }
        else if (name == "Light_J")
        {
            ColorChange(jm, "Black");
            ColorChange(jsm, "Black");

            return;
        }
        else if (name == "Light_K")
        {
            ColorChange(km, "Black");
            ColorChange(ksm, "Black");

            return;
        }
    }

    void Fkey()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            f_key.SetActive(true);

            ColorChange(fm, "Yellow");
            ColorChange(fsm, "Yellow");

            FmeshCut.SetActive(true);

            f_anim.SetTrigger("Slash");
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            f_key.SetActive(false);

            FmeshCut.SetActive(false);

            NodeCrash nc = f_key.GetComponent<NodeCrash>();
            nc.GetkeyUp();
        }
    }

    void Gkey()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            g_key.SetActive(true);

            ColorChange(gm, "Cyan");
            ColorChange(gsm, "Cyan");

            GmeshCut.SetActive(true);

            g_anim.SetTrigger("Slash");
        }
        else if (Input.GetKeyUp(KeyCode.G))
        {
            g_key.SetActive(false);

            GmeshCut.SetActive(false);

            NodeCrash nc = g_key.GetComponent<NodeCrash>();
            nc.GetkeyUp();
        }

    }

    void Hkey()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            h_key.SetActive(true);

            ColorChange(hm, "White");
            ColorChange(hsm, "White");

            HmeshCut.SetActive(true);

            h_anim.SetTrigger("Slash");
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            h_key.SetActive(false);

            HmeshCut.SetActive(false);

            NodeCrash nc = h_key.GetComponent<NodeCrash>();
            nc.GetkeyUp();
        }

    }

    void Jkey()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            j_key.SetActive(true);

            ColorChange(jm, "Red");
            ColorChange(jsm, "Red");

            JmeshCut.SetActive(true);

            j_anim.SetTrigger("Slash");
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            j_key.SetActive(false);

            JmeshCut.SetActive(false);

            NodeCrash nc = j_key.GetComponent<NodeCrash>();
            nc.GetkeyUp();
        }

    }

    void Kkey()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            k_key.SetActive(true);

            ColorChange(km, "Blue");
            ColorChange(ksm, "Blue");

            KmeshCut.SetActive(true);

            k_anim.SetTrigger("Slash");
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            k_key.SetActive(false);

            KmeshCut.SetActive(false);

            NodeCrash nc = k_key.GetComponent<NodeCrash>();
            nc.GetkeyUp();
        }

    }
}
