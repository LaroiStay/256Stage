using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurssQueue : MonoBehaviour
{
    public float m_truss_size = 10f;
    public float m_truss_width = 1f;
    public float m_truss_light_or_speaker_quantity = 10f;
    public bool AlreadyMade = true;
    public bool isZ = true;

    Queue<Vector3> Light_Or_Speaker_localPosition = new Queue<Vector3>();

    static public Queue<GameObject> GameObjects = new Queue<GameObject>();
    string UpPath = "Stage/Truss/TrussHelp/UpTruss";
    string DownPath = "Stage/Truss/TrussHelp/DownTruss";

    private void Start()
    {
        
        if (isZ)
        {
            for (int i = 0; i < m_truss_light_or_speaker_quantity; i++)
            {
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(m_truss_width / 2, m_truss_width / 2, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size));
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(-m_truss_width / 2, m_truss_width / 2, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size));
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(m_truss_width / 2, -m_truss_width / 2, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size));
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(-m_truss_width / 2, -m_truss_width / 2, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size));
            }
        }
        else
        {
            for (int i = 0; i < m_truss_light_or_speaker_quantity; i++)
            {
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(m_truss_width / 2, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size, m_truss_width / 2));
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(-m_truss_width / 2, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size, m_truss_width / 2));
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(m_truss_width / 2, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size, -m_truss_width / 2));
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(-m_truss_width / 2, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size, -m_truss_width / 2));
            }
        }
        GameObject go1 = Manager.Resource_Instance.Instantiate(UpPath);
        go1.transform.SetParent(this.transform);
        if (!isZ)
            go1.transform.localPosition = new Vector3(0, m_truss_size, 0);
        else
            go1.transform.localPosition = new Vector3(0, 0, m_truss_size);

        if (!AlreadyMade)
        {
            GameObject go = Manager.Resource_Instance.Instantiate(DownPath);
            go.transform.SetParent(this.transform);
            go.transform.localPosition = Vector3.zero;
        }
       
       


        for (int i = 0; i < m_truss_light_or_speaker_quantity; i++)
        {

            GameObject[] tempGo = { new GameObject(), new GameObject(), new GameObject(), new GameObject()};
            for(int ii = 0; ii<4; ii++)
            {
                tempGo[ii].transform.parent = this.transform;
                tempGo[ii].transform.localPosition = Light_Or_Speaker_localPosition.Dequeue();
                GameObjects.Enqueue(tempGo[ii]);
            }
        }





    }
}
