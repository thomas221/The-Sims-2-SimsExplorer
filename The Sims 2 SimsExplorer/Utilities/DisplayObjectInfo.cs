﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace The_Sims_2_SimsExplorer.Utilities
{
    public class DisplayObjectInfo
    {

        public static string ShowDisplayObjectInfo(Object o)
        {
            StringBuilder sb = new StringBuilder();

            // Include the type of the object
            System.Type type = o.GetType();
            sb.Append("Type: " + type.Name);

            // Include information for each Field
            sb.Append("\r\n\r\nFields:");
            System.Reflection.FieldInfo[] fi = type.GetFields();
            if (fi.Length > 0)
            {
                foreach (FieldInfo f in fi)
                {
                    sb.Append("\r\n " + f.ToString() + " = " + f.GetValue(o));
                }
            }
            else
                sb.Append("\r\n None");

            // Include information for each Property
            sb.Append("\r\n\r\nProperties:");
            System.Reflection.PropertyInfo[] pi = type.GetProperties();
            if (pi.Length > 0)
            {
                foreach (PropertyInfo p in pi)
                {
                    sb.Append("\r\n " + p.ToString() + " = " +
                              p.GetValue(o, null));
                }
            }
            else
                sb.Append("\r\n None");

            Debug.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
