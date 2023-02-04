using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

    public static class DoTweenExtension
    {
        public static Tween DoRotateAboutZ(this Transform transform, float angle, float duration, Action action = null, float limit = 360)
        {
            return DoRotateAbout(transform, angle, duration, new Vector3(0, 0, 1), action, limit);
        }

        public static Tween DoRotateAbout(this Transform transform, float angle, float duration, Vector3 axis, Action action, float limit)
        {
            var euler = transform.eulerAngles;
            float baseAngle = Mathf.Max(axis.x * euler.x, axis.y * euler.y, axis.z * euler.z);
            return DOVirtual.Float(0, angle, duration, (value) =>
            {
                transform.localRotation = Quaternion.AngleAxis(baseAngle + value, axis);
                if (value > limit)
                {
                    action.Invoke();
                }
            });
        }
    }