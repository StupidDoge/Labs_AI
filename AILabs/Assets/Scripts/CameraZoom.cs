using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private float _zoomDuration;
    [SerializeField] private float _dialogueCameraZoom;

    private float _standardCameraZoom;

    private void Start()
    {
        _standardCameraZoom = _cinemachineVirtualCamera.m_Lens.OrthographicSize;
    }

    private void OnEnable()
    {
        PlayerDialogueState.OnDialogueStarted += ZoomIn;
        DialogueManager.OnDialogueEnded += ZoomOut;
    }

    private void OnDisable()
    {
        PlayerDialogueState.OnDialogueStarted -= ZoomIn;
        DialogueManager.OnDialogueEnded -= ZoomOut;
    }

    private void ZoomIn()
    {
        StartCoroutine(Zoom(_standardCameraZoom, _dialogueCameraZoom));
    }

    private void ZoomOut()
    {
        StartCoroutine(Zoom(_dialogueCameraZoom, _standardCameraZoom));
    }

    private IEnumerator Zoom(float start, float end)
    {
        float counter = 0f;

        while (counter < _zoomDuration)
        {
            counter += Time.deltaTime;
            _cinemachineVirtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(start, end, counter / _zoomDuration);

            yield return null;
        }
    }
}
