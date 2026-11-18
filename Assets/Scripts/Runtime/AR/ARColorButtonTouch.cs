using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class ARColorButtonTouch : MonoBehaviour
{
    [Header("Referensi")]
    [SerializeField] private Camera arCamera;
    [SerializeField] private BombManager bombManager;

    [Header("Raycast")]
    [SerializeField, Min(0.1f)] private float maxDistance = 100f;
    [SerializeField] private LayerMask buttonLayers = ~0;

    public string LastSelectedColor { get; private set; } = "-";

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        bool handledTouch = false;

        foreach (UnityEngine.InputSystem.EnhancedTouch.Touch touch in
                 UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            if (touch.phase != UnityEngine.InputSystem.TouchPhase.Began)
                continue;

            handledTouch = true;

            if (!IsPointerOverUi(touch.touchId))
                TrySelectButton(touch.screenPosition);
        }

#if UNITY_EDITOR || UNITY_STANDALONE
        if (!handledTouch &&
            Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame &&
            !IsPointerOverUi())
        {
            TrySelectButton(Mouse.current.position.ReadValue());
        }
#endif
    }

    private void TrySelectButton(Vector2 screenPosition)
    {
        if (arCamera == null || bombManager == null)
        {
            Debug.LogError(
                "ARColorButtonTouch: AR Camera atau BombManager belum dihubungkan.",
                this);
            return;
        }

        Ray ray = arCamera.ScreenPointToRay(screenPosition);
        RaycastHit[] hits = Physics.RaycastAll(
            ray,
            maxDistance,
            buttonLayers,
            QueryTriggerInteraction.Collide);

        Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

        foreach (RaycastHit hit in hits)
        {
            string color = GetColorFromTransform(hit.transform);
            if (string.IsNullOrEmpty(color))
                continue;

            LastSelectedColor = color;
            bombManager.SelectCable(color);

            Debug.Log(
                "Tombol AR disentuh: " + color +
                " | Posisi layar: " + screenPosition,
                this);
            return;
        }
    }

    private static string GetColorFromTransform(Transform target)
    {
        Transform current = target;

        while (current != null)
        {
            switch (current.name)
            {
                case "Tombol_Merah":
                    return "Merah";
                case "Tombol_Biru":
                    return "Biru";
                case "Tombol_Hijau":
                    return "Hijau";
                case "Tombol_Kuning":
                    return "Kuning";
            }

            current = current.parent;
        }

        return null;
    }

    private static bool IsPointerOverUi(int pointerId = -1)
    {
        if (EventSystem.current == null)
            return false;

        return pointerId >= 0
            ? EventSystem.current.IsPointerOverGameObject(pointerId)
            : EventSystem.current.IsPointerOverGameObject();
    }
}
