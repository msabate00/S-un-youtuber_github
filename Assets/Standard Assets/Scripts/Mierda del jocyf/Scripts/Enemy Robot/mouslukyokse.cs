using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouslukyokse : MonoBehaviour
{
    public float XSensitivity = 3;
    public float YSensitivity = 3;
    private bool clampVerticalRotation = false;
    public Transform character;
    public Transform cameraTransform;
    private float MinimumX = 0;
    private float MaximumX = 0;
    private Quaternion m_CameraTargetRot;
    private Quaternion m_CharacterTargetRot;

    void Update()
    {
        LookRotation();
    }
    public void LookRotation()
    {
        //get the y and x rotation based on the Input manager
        float xRot = Input.GetAxisRaw("Mouse Y") * YSensitivity;
        float yRot = Input.GetAxisRaw("Mouse X") * XSensitivity;

        // calculate the rotation
        m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

        // clamp the vertical rotation if specified
        if (clampVerticalRotation)
            m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

        // actually apply the rotation to the camera / character
        character.localRotation = m_CharacterTargetRot;
        cameraTransform.localRotation = m_CameraTargetRot;
    }


    // Clamp code below, not really that relevant: 

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}