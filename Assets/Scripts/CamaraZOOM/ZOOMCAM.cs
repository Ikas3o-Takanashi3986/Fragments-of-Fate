using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZOOMCAM : MonoBehaviour
{
    private float m_FieldOfView;

    void Start()
    {
        m_FieldOfView = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Camera protaCamera = GameObject.FindGameObjectWithTag("prota").GetComponent<Camera>();
        protaCamera.fieldOfView = m_FieldOfView;
        Zoomcam();
    }

    void Zoomcam()
    {
        if(Input.GetMouseButton(1))
        {
            m_FieldOfView = 40.0f;
        }
        else
        {
            m_FieldOfView = 60.0f;
        }
    }


}
