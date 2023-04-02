using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurssQueue_Half : MonoBehaviour
{
    public float m_truss_size = 10f;
    public float m_truss_width = 1f;
    public float m_truss_light_or_speaker_quantity = 10f;
    public bool isX = false;

    Queue<Vector3> Light_Or_Speaker_localPosition = new Queue<Vector3>();


    private void Start()
    {

        for (int i = 0; i < m_truss_light_or_speaker_quantity; i++)
        {
            if (isX)
            {
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(m_truss_width / 2, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size, 0));
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(-m_truss_width / 2, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size, 0));
            }
            else
            {
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(0, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size, m_truss_width / 2));
                Light_Or_Speaker_localPosition.Enqueue(new Vector3(0, i / (m_truss_light_or_speaker_quantity - 1) * m_truss_size, -m_truss_width / 2));
            }

           
          
        }

        for (int i = 0; i < m_truss_light_or_speaker_quantity; i++)
        {
            GameObject[] tempGo = { new GameObject(), new GameObject(), new GameObject(), new GameObject() };
            for (int ii = 0; ii < 2; ii++)
            {
                tempGo[ii].transform.parent = this.transform;
                tempGo[ii].transform.localPosition = Light_Or_Speaker_localPosition.Dequeue();
                TurssQueue.GameObjects.Enqueue(tempGo[ii]);
            }
        }





    }
}

