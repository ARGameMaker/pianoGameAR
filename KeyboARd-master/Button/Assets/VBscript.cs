using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Vuforia;

public class VBscript : MonoBehaviour, IVirtualButtonEventHandler
{

    public static VBscript Instance;
    //private GameObject Octave;

    public GameObject vbButtonObject;
    public GameObject D1Key;
    public GameObject E1Key;
    public GameObject F1Key;
    public GameObject G1Key;
    public GameObject A1Key;
    public GameObject B1Key;
    public GameObject C2Key;
    public GameObject D2Key;
    public GameObject E2Key;
    public GameObject F2Key;

    public GameObject CSharp;
    public GameObject DSharp;
    public GameObject FSharp;
    public GameObject GSharp;
    public GameObject ASharp;

    public GameObject CSharp2;
    public GameObject DSharp2;
    public GameObject FSharp2;

    public GameObject Octave;

    public Button ResetButton;

    private VirtualButtonBehaviour[] vbs;

    public List<GameObject> TipsGameObjects = new List<GameObject>();

    public List<GameObject> PlusCount=new List<GameObject>(); 

    //public GameObject ColorObj;

    public float Timer = 0;

    public float TimerClock = 2f;

    public bool IsStart = false;

    public Text ScroeNum;

    public Text RightScore;

    public int ScoreRight = 0;

    public int ScoreWrong = 0;

    public float speed = 0.02f;

    public float Right = 0f;

    //public int index = 0;
    // Use this for initialization


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //registers all children of Vbutton behaviour
        vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
            TipsGameObjects.Add(vbs[i].transform.GetChild(0).gameObject);
            PlusCount.Add(vbs[i].transform.GetChild(1).gameObject);
            PlusCount[i].SetActive(false);
            TipsGameObjects[i].SetActive(false);
            vbs[i].enabled = false;
        }

        Octave = GameObject.Find("CentralOctave");

        vbButtonObject = GameObject.Find("VirtualButtonC1");
        CSharp = GameObject.Find("CSharp");
        D1Key = GameObject.Find("VirtualButtonD1");
        DSharp = GameObject.Find("DSharp");
        E1Key = GameObject.Find("VirtualButtonE1");

        F1Key = GameObject.Find("VirtualButtonF1");
        FSharp = GameObject.Find("FSharp");
        G1Key = GameObject.Find("VirtualButtonG1");
        GSharp = GameObject.Find("GSharp");
        A1Key = GameObject.Find("VirtualButtonA1");
        ASharp = GameObject.Find("ASharp");
        B1Key = GameObject.Find("VirtualButtonB1");

        C2Key = GameObject.Find("VirtualButtonC2");
        CSharp2 = GameObject.Find("CSharp2");
        D2Key = GameObject.Find("VirtualButtonD2");
        DSharp2 = GameObject.Find("DSharp2");
        E2Key = GameObject.Find("VirtualButtonE2");

        F2Key = GameObject.Find("VirtualButtonF2");
        FSharp2 = GameObject.Find("FSharp2");


        ResetButton.onClick.AddListener(SetOnPlay);
    }

    private void Update()
    {
        if (IsStart)
        {
            Timer += Time.deltaTime;
            TimerClock -= Time.deltaTime*speed;
            if (Timer >= TimerClock)
            {
                Timer = 0;

                ScoreWrong++;
                //ScoreRight--;

                if (ScoreRight<=0)
                {
                    ScoreRight = 0;
                }

                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");

                

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    TipsGameObjects[i].SetActive(false);
                }

                if (Random.Range(0,9)>6)
                {
                    int index = Random.Range(0, TipsGameObjects.Count);

                    int temp = Random.Range(0, TipsGameObjects.Count);

                    TipsGameObjects[index].SetActive(true);
                    TipsGameObjects[index].transform.parent.GetComponent<VirtualButtonBehaviour>().enabled = true;

                    TipsGameObjects[temp].SetActive(true);
                    TipsGameObjects[temp].transform.parent.GetComponent<VirtualButtonBehaviour>().enabled = true;
                }
                else
                {
                    int index = Random.Range(0, TipsGameObjects.Count);
                    TipsGameObjects[index].SetActive(true);
                    TipsGameObjects[index].transform.parent.GetComponent<VirtualButtonBehaviour>().enabled = true;
                }
                

            }
        }
    }



    #region MyRegion
    private void SetOnPlay()
    {
        Application.LoadLevel(Application.loadedLevel);

    } 
    #endregion

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        int index = 0;
        switch (vb.VirtualButtonName)
        {
            case "VirtualButtonC1":
                vbButtonObject.GetComponent<AudioSource>().Play();
                //Timer = 0;

                vbButtonObject.transform.GetChild(0).gameObject.SetActive(false);
                vbButtonObject.transform.GetChild(1).gameObject.SetActive(true);
                vbButtonObject.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                vbButtonObject.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }

                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("C1");
                break;
            case "VirtualButtonD1":
                D1Key.GetComponent<AudioSource>().Play();
                //Timer = 0;
                D1Key.transform.GetChild(0).gameObject.SetActive(false);
                D1Key.transform.GetChild(1).gameObject.SetActive(true);
                D1Key.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                D1Key.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
               ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("D1");
                break;
            case "VirtualButtonE1":
                E1Key.GetComponent<AudioSource>().Play();
                //Timer = 0;

                E1Key.transform.GetChild(0).gameObject.SetActive(false);
                E1Key.transform.GetChild(1).gameObject.SetActive(true);
                E1Key.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                E1Key.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }

                ScoreRight++;
               ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("E1");
                break;
            case "VirtualButtonF1":
                F1Key.GetComponent<AudioSource>().Play();
                //Timer = 0;
                
                F1Key.transform.GetChild(0).gameObject.SetActive(false);
                F1Key.transform.GetChild(1).gameObject.SetActive(true);
                F1Key.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                F1Key.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("F1");
                break;
            case "VirtualButtonG1":
                G1Key.GetComponent<AudioSource>().Play();
                //Timer = 0;

                G1Key.transform.GetChild(0).gameObject.SetActive(false);
                G1Key.transform.GetChild(1).gameObject.SetActive(true);
                G1Key.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                G1Key.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }

                ScoreRight++;
               ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("G1");
                break;
            case "VirtualButtonA1":
                A1Key.GetComponent<AudioSource>().Play();
                //Timer = 0;

                A1Key.transform.GetChild(0).gameObject.SetActive(false);
                A1Key.transform.GetChild(1).gameObject.SetActive(true);
                A1Key.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                A1Key.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }

                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("A1");
                break;
            case "VirtualButtonB1":
                B1Key.GetComponent<AudioSource>().Play();
                //Timer = 0;

                B1Key.transform.GetChild(0).gameObject.SetActive(false);
                B1Key.transform.GetChild(1).gameObject.SetActive(true);
                B1Key.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                B1Key.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }

                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("B1");
                break;
            case "VirtualButtonC2":
                C2Key.GetComponent<AudioSource>().Play();
                //Timer = 0;

                C2Key.transform.GetChild(0).gameObject.SetActive(false);
                C2Key.transform.GetChild(1).gameObject.SetActive(true);
                C2Key.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                C2Key.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
               ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("C2");
                break;
            case "VirtualButtonD2":
                D2Key.GetComponent<AudioSource>().Play();
                //Timer = 0;

                D2Key.transform.GetChild(0).gameObject.SetActive(false);
                D2Key.transform.GetChild(1).gameObject.SetActive(true);
                D2Key.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                D2Key.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }

                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("D2");
                break;
            case "VirtualButtonE2":
                E2Key.GetComponent<AudioSource>().Play();
                //Timer = 0;

                E2Key.transform.GetChild(0).gameObject.SetActive(false);
                E2Key.transform.GetChild(1).gameObject.SetActive(true);
                E2Key.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                E2Key.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("E2");
                break;
            case "VirtualButtonF2":
                F2Key.GetComponent<AudioSource>().Play();
                //Timer = 0;

                F2Key.transform.GetChild(0).gameObject.SetActive(false);
                F2Key.transform.GetChild(1).gameObject.SetActive(true);
                F2Key.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                F2Key.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("F2");
                break;
            case "CSharp":
                CSharp.GetComponent<AudioSource>().Play();
                //Timer = 0;

                CSharp.transform.GetChild(0).gameObject.SetActive(false);
                CSharp.transform.GetChild(1).gameObject.SetActive(true);
                CSharp.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                CSharp.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("C#");
                break;
            case "DSharp":
                DSharp.GetComponent<AudioSource>().Play();
                //Timer = 0;

                DSharp.transform.GetChild(0).gameObject.SetActive(false);
                DSharp.transform.GetChild(1).gameObject.SetActive(true);
                DSharp.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                DSharp.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("D#");
                break;
            case "FSharp":
                FSharp.GetComponent<AudioSource>().Play();
                //Timer = 0;

                FSharp.transform.GetChild(0).gameObject.SetActive(false);
                FSharp.transform.GetChild(1).gameObject.SetActive(true);
                FSharp.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                FSharp.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("F#");
                break;
            case "GSharp":
                GSharp.GetComponent<AudioSource>().Play();
                //Timer = 0;

                GSharp.transform.GetChild(0).gameObject.SetActive(false);
                GSharp.transform.GetChild(1).gameObject.SetActive(true);
                GSharp.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                GSharp.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("G#");
                break;
            case "ASharp":
                ASharp.GetComponent<AudioSource>().Play();
                //Timer = 0;

                ASharp.transform.GetChild(0).gameObject.SetActive(false);
                ASharp.transform.GetChild(1).gameObject.SetActive(true);
                ASharp.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                ASharp.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("A#");
                break;
            case "CSharp2":
                CSharp2.GetComponent<AudioSource>().Play();
                //Timer = 0;

                CSharp2.transform.GetChild(0).gameObject.SetActive(false);
                CSharp2.transform.GetChild(1).gameObject.SetActive(true);
                CSharp2.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                CSharp2.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("C#");
                break;
            case "DSharp2":
                DSharp2.GetComponent<AudioSource>().Play();
                //Timer = 0;

                DSharp2.transform.GetChild(0).gameObject.SetActive(false);
                DSharp2.transform.GetChild(1).gameObject.SetActive(true);
                DSharp2.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                DSharp2.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }
                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("D#2");
                break;
            case "FSharp2":
                FSharp2.GetComponent<AudioSource>().Play();
                //Timer = 0;

                FSharp2.transform.GetChild(0).gameObject.SetActive(false);
                FSharp2.transform.GetChild(1).gameObject.SetActive(true);
                FSharp2.transform.GetChild(1).GetComponent<TipsTimer>().activeSet();
                FSharp2.GetComponent<VirtualButtonBehaviour>().enabled = false;

                for (int i = 0; i < TipsGameObjects.Count; i++)
                {
                    if (TipsGameObjects[i].activeSelf)
                    {
                        index++;
                    }
                }

                if (index<=0)
                {
                    Timer = 0;
                }

                ScoreRight++;
                ScroeNum.text = ScoreRight.ToString();

                Right = ScoreRight*1f/(ScoreWrong+ScoreRight);

                RightScore.text = Right.ToString("F2");
                Debug.Log("F#2");
                break;
        }
        //vbButtonObject.GetComponent<AudioSource>().Play();
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        //vbButtonObject.GetComponent<AudioSource>().Stop();
    }

}
