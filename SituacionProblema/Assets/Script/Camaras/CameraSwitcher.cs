using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera; // La c�mara principal
    public Camera[] thirdPersonCameras; // Array de c�maras en tercera persona

    void Start()
    {
        // Desactivar todas las c�maras en tercera persona al inicio
        foreach (Camera cam in thirdPersonCameras)
        {
            cam.gameObject.SetActive(false);
        }
        mainCamera.gameObject.SetActive(true); // Activar la c�mara principal
    }

    void Update()
    {
        // Cambiar a la c�mara principal cuando se presione la tecla 0
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ActivateMainCamera();
        }

        // Cambiar a las c�maras en tercera persona cuando se presionen las teclas 1 a 6
        for (int i = 0; i < thirdPersonCameras.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                ActivateThirdPersonCamera(i);
            }
        }
    }

    void ActivateMainCamera()
    {
        // Activar la c�mara principal y desactivar las dem�s
        mainCamera.gameObject.SetActive(true);
        foreach (Camera cam in thirdPersonCameras)
        {
            cam.gameObject.SetActive(false);
        }
    }

    void ActivateThirdPersonCamera(int index)
    {
        // Asegurarse de que el �ndice est� dentro del rango
        if (index >= 0 && index < thirdPersonCameras.Length)
        {
            // Activar la c�mara seleccionada y desactivar las dem�s
            mainCamera.gameObject.SetActive(false);
            for (int i = 0; i < thirdPersonCameras.Length; i++)
            {
                thirdPersonCameras[i].gameObject.SetActive(i == index);
            }
        }
    }
}
