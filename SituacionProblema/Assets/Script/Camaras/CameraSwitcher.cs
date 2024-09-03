using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera; // La cámara principal
    public Camera[] thirdPersonCameras; // Array de cámaras en tercera persona

    void Start()
    {
        // Desactivar todas las cámaras en tercera persona al inicio
        foreach (Camera cam in thirdPersonCameras)
        {
            cam.gameObject.SetActive(false);
        }
        mainCamera.gameObject.SetActive(true); // Activar la cámara principal
    }

    void Update()
    {
        // Cambiar a la cámara principal cuando se presione la tecla 0
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ActivateMainCamera();
        }

        // Cambiar a las cámaras en tercera persona cuando se presionen las teclas 1 a 6
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
        // Activar la cámara principal y desactivar las demás
        mainCamera.gameObject.SetActive(true);
        foreach (Camera cam in thirdPersonCameras)
        {
            cam.gameObject.SetActive(false);
        }
    }

    void ActivateThirdPersonCamera(int index)
    {
        // Asegurarse de que el índice está dentro del rango
        if (index >= 0 && index < thirdPersonCameras.Length)
        {
            // Activar la cámara seleccionada y desactivar las demás
            mainCamera.gameObject.SetActive(false);
            for (int i = 0; i < thirdPersonCameras.Length; i++)
            {
                thirdPersonCameras[i].gameObject.SetActive(i == index);
            }
        }
    }
}
