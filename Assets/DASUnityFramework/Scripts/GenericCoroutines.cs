using System;
using System.Collections;
using System.Collections.Generic;
using DASUnityFramework.Scripts.ExtensionMethods;
using UnityEngine;
using UnityEngine.UI;

namespace DASUnityFramework.Scripts
{
    public static class GenericCoroutines
    {
        public delegate bool Condition();

        public static IEnumerator DoAfterCondition(Action action, Condition condition)
        {
            if (!condition())
            {
                yield return new WaitUntil(() => condition());
            }

            action();
        }

        public static IEnumerator DoAfterSeconds(Action action, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            action();
        }

        public static IEnumerator DoAfterFrames(Action action, int numFrames = 1)
        {
            int framesWaited = 0;
            while (framesWaited < numFrames)
            {
                yield return new WaitForEndOfFrame();
                framesWaited++;
            }

            action();
        }

        public static IEnumerator MoveAwayFrom(Transform objectToMove, Vector3 myCenterPoint, Vector3 awayFrom,  
            float distance, float seconds, InterpolationType interpolationType = InterpolationType.Linear, Action doAfter = null)
        {
            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            Vector3 endPos = startingPos + (myCenterPoint - awayFrom).normalized * distance;
            while (elapsedTime < seconds)
            {
                objectToMove.position = Vector3.Lerp(startingPos, endPos, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.position = endPos;

            doAfter?.Invoke();
        }

        public static IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds, Action onFinish = null)
        {
            return MoveAndRotateOverSeconds(objectToMove, end, objectToMove.transform.rotation, seconds, onFinish);
        }
        
        public static IEnumerator MoveAndRotateOverSeconds(GameObject objectToMove, Vector3 end, Quaternion endRot, float seconds, Action onFinish = null)
        {
            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            Quaternion startingRot = objectToMove.transform.rotation;
            while (elapsedTime < seconds)
            {
                objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                objectToMove.transform.rotation = Quaternion.Lerp(startingRot, endRot, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.transform.position = end;
            objectToMove.transform.rotation = endRot;

            if (onFinish != null)
                onFinish();
        }

        public static IEnumerator FadeUI(RectTransform rootObject, float duration, float finalAlpha, float delay = 0,
            InterpolationType t = InterpolationType.Linear)
        {
            Graphic[] graphics = rootObject.GetComponentsInChildren<Graphic>();
            Dictionary<Graphic, float> startAlphas = new Dictionary<Graphic, float>();
            
            foreach (Graphic graphic in graphics)
            {
                startAlphas.Add(graphic, graphic.color.a);
            }



            float waitingTimeElapsed = 0;
            while (waitingTimeElapsed < delay)
            {
                waitingTimeElapsed += Time.deltaTime;
                yield return null;
            }
            
            
            float timeElapsed = 0;
            while (timeElapsed < duration)
            {
                float portion = timeElapsed / duration;
                foreach (Graphic graphic in graphics)
                {
                    graphic.SetAlpha(Interpolation.Interpolate(startAlphas[graphic], finalAlpha, portion, t));
                }
                
                yield return null;
                
                
                timeElapsed += Time.deltaTime;
            }

            foreach (Graphic graphic in graphics)
                graphic.SetAlpha(finalAlpha);
        }
        
        public static IEnumerator DoXThenY(IEnumerator x, IEnumerator y, float timeBetween = 0)
        {
            yield return x;
            yield return new WaitForSeconds(timeBetween);
            yield return y;
        }
    }
}