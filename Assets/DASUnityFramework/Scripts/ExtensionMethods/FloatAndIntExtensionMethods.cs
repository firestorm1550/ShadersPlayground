using System;
using System.Collections.Generic;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class FloatAndIntExtensionMethods
    {
        //=============== int Extensions ==========================================
        public static int? GetClosestHigher(this IEnumerable<int> list, int value)
        {
            int? best = null;
            foreach (int d in list)
            {
                if (d > value && (best.HasValue == false || d < best.Value))
                    best = d;
            }

            return best;
        }
        
        public static int? GetClosestLower(this IEnumerable<int> list, int value)
        {
            int? best = null;
            foreach (int d in list)
            {
                if (d < value && (best.HasValue == false || d > best.Value))
                    best = d;
            }

            return best;
        }
        
        public static string As2Digits(this int i)
        {
            if (i < 10)
            {
                return "0" + i;
            }
            else
            {
                return i + "";
            }
        }
        
        //=============== float Extensions ==========================================

        public static float RoundToNearest(this float f, float modulo)
        {
            if (modulo <= 0)
                throw new Exception("Please don't use negative numbers as your modulo. It's probably not going to work.");

            float retval;

            float amountLeftOver = f % modulo;

            //.25 to nearest 1
            //.25 left over
            // we subtract .25 
            //Good

            //-.25 to nearest 1
            // -.25 left over
            //Good

            //.75 to nearest 1
            //.75 left over
            // add 1-.75f
            // = 1 good

            //-.75 to nearest 1
            //-.75 left over
            // retval = -.75 - 1 + .75
            //  = -1. Good

            if (amountLeftOver > 0)
            {
                if (amountLeftOver > modulo / 2)
                    retval = f + modulo - amountLeftOver;
                else
                    retval = f - amountLeftOver;
            }
            else
            {
                if (Mathf.Abs(amountLeftOver) > modulo / 2)
                    retval = f - modulo - amountLeftOver;
                else
                    retval = f - amountLeftOver;
            }

            return retval;
        }
        
        public static string ToRoundedString(this float f, int digitsAfterDecimalPoint)
        {
            int powerOfTen = (int) Mathf.Pow(10, digitsAfterDecimalPoint);
            
            int temp = Mathf.RoundToInt(f * powerOfTen);

            int beforeDecimalPoint = temp / powerOfTen;
            int afterDecimalPoint = Mathf.Abs(temp - beforeDecimalPoint * powerOfTen);

            string roundedString = beforeDecimalPoint + ".";
            for (int i = afterDecimalPoint.ToString().Length; i < digitsAfterDecimalPoint; i++)
                roundedString += "0";
            roundedString += afterDecimalPoint;

            return roundedString;
        }
    }
}