using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RichardQ{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private Camera cam;

        private Vector3 dragOrigin;

        [SerializeField]
        private SpriteRenderer MapSceneRenderer;

        private float mapMinX, mapMinY, mapMaxX, mapMaxY;

        private void Awake()
        {
            // set our min max using cam & mapScene bounds
            mapMinX = MapSceneRenderer.transform.position.x - MapSceneRenderer.bounds.size.x / 2;
            mapMaxX = MapSceneRenderer.transform.position.x + MapSceneRenderer.bounds.size.x / 2;

            mapMinY = MapSceneRenderer.transform.position.y - MapSceneRenderer.bounds.size.y / 2;
            mapMaxY = MapSceneRenderer.transform.position.y + MapSceneRenderer.bounds.size.y / 2;

        }


        void Update()
        {
            panCamera();
        }

        private void panCamera()
        {
            // record the first click of left mouse key
            if (Input.GetMouseButtonDown(0))
            {
                // save the world pos 
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

            }

            // returns true when key is held
            if (Input.GetMouseButton(0))
            {
                Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
                // update cam pos
                cam.transform.position = clampCamera(cam.transform.position + difference);
            }
        }

        // clamp the camera to our scene bound
        private Vector3 clampCamera(Vector3 camPos)
        {
            // Camera's half-size when in orthographic mode.
            float camHeight = cam.orthographicSize;
            float camWidth = cam.orthographicSize * cam.aspect;

            float minX = mapMinX + camWidth;
            float minY = mapMinY + camHeight;
            float maxX = mapMaxX - camWidth;
            float maxY = mapMaxY - camHeight;

            float newX = Mathf.Clamp(camPos.x, minX, maxX);
            float newY = Mathf.Clamp(camPos.y, minY, maxY);

            return new Vector3(newX, newY, camPos.z);
        }
    }
}


