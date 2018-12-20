using UnityEngine;
namespace System.Reflection.Simple
{
    //Static helper class that simplifies reflection by exposing field names.
    public static class Reflection
    {
        public static object GetValue(object script, string targetField)
        {
            if (HasField(script, targetField))
            {
                return script.GetType().GetField(targetField).GetValue(script);
            }
            return null;
        }

        public static object GetValue(object script, int targetFieldIndex)
        {
            return script.GetType().GetFields()[targetFieldIndex].GetValue(script);
        }

        public static bool HasField(object script, string targetField)
        {
            FieldInfo field = script.GetType().GetField(targetField);
            if (field != null)
            {
                return true;
            }

            Debug.Log("Couldn't find field " + targetField + " on " + script);
            return false;
        }

        public static string[] GetAllFieldNames(object script)
        {
            FieldInfo[] fields = script.GetType().GetFields();
            string[] variableNames = new string[fields.Length];

            for (int i = 0; i < fields.Length; i++)
            {
                variableNames[i] = fields[i].Name;
            }

            return variableNames;
        }

        public static void SetValue(object script, string targetField, object newValue)
        {
            if (HasField(script, targetField))
            {
                script.GetType().GetField(targetField).SetValue(script, newValue);
            }
        }

        public static void SetValue(object[] scripts, string targetField, object newValue)
        {
            for (int i = 0; i < scripts.Length; i++)
            {
                if (HasField(scripts[i], targetField))
                {
                    scripts[i].GetType().GetField(targetField).SetValue(scripts[i], newValue);
                }
            }
        }

        public static void SetValue(object script, string[] targetFields, object newValue)
        {
            for (int i = 0; i < targetFields.Length; i++)
            {
                if (HasField(script, targetFields[i]))
                {
                    script.GetType().GetField(targetFields[i]).SetValue(script, newValue);
                }
            }
        }

        public static void SetValue(object[] scripts, string[] targetFields, object newValue)
        {
            for (int i = 0; i < scripts.Length; i++)
            {
                for (int f = 0; f < targetFields.Length; f++)
                {
                    if (HasField(scripts[i], targetFields[f]))
                    {
                        scripts[i].GetType().GetField(targetFields[f]).SetValue(scripts[i], newValue);
                    }
                }
            }
        }

        public static void SetValue(object script, int targetFieldIndex, object newValue)
        {
            script.GetType().GetFields()[targetFieldIndex].SetValue(script, newValue);
        }

        public static void SetValue(object[] scripts, int targetFieldIndex, object newValue)
        {
            for (int i = 0; i < scripts.Length; i++)
            {
                scripts[i].GetType().GetFields()[targetFieldIndex].SetValue(scripts[i], newValue);
            }
        }
    }
}