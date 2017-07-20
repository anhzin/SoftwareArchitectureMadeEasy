using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public static class DataContractExtensions
    {
        /// <summary>
        /// Copies property values from another entity with same properties to this entity. Does not copy virtual properties.
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="source"></param>
        /// <param name="copyAuditValues"></param>
        public static void CopyValuesFrom(this object dest, object source, bool copyAuditValues)
        {
            try
            {
                foreach (PropertyInfo i in dest.GetType().GetProperties())
                {
                    // Don't copy the virtual properties
                    if (i.CanWrite && i.IsVirtual() != true)
                    {
                        // Make sure they aren't base table audit properties unless we want them copied
                        if (copyAuditValues == true || (i.Name != "Status" && i.Name != "CreateDate" && i.Name != "CreatedBy" && i.Name != "ModifiedDate" && i.Name != "ModifiedBy"))
                        {
                            PropertyInfo p = source.GetType().GetProperty(i.Name);

                            if (p != null)
                            {
                                object value = p.GetValue(source, null);
                                i.SetValue(dest, value, null);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Copies property values from another entity with same properties to this entity. Does not copy virtual properties.
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="source"></param>
        /// <param name="copyAuditValues"></param>
        /// <param name="excludeId"></param>
        public static void CopyValuesFrom(this object dest, object source, bool copyAuditValues, bool excludeId)
        {
            try
            {
                // Get property names on source
                List<string> sourceProps = new List<string>();

                foreach (PropertyInfo prop in source.GetType().GetProperties())
                {
                    sourceProps.Add(prop.Name);
                }

                foreach (PropertyInfo i in dest.GetType().GetProperties())
                {
                    // Don't copy the virtual properties
                    if (i.CanWrite && i.IsVirtual() != true)
                    {
                        // Make sure they aren't base table audit properties unless we want them copied
                        if (copyAuditValues == true || (i.Name != "Status" && i.Name != "CreateDate" && i.Name != "CreatedBy" && i.Name != "ModifiedDate" && i.Name != "ModifiedBy"))
                        {
                            // Make sure we don't copy the Id if it's excluded
                            if (excludeId != true || i.Name != "Id")
                            {
                                if (sourceProps.Contains(i.Name) != false)
                                {
                                    object value = source.GetType().GetProperty(i.Name).GetValue(source, null);
                                    i.SetValue(dest, value, null);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Determines if the property is declared as a virtual property
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static bool? IsVirtual(this PropertyInfo prop)
        {
            if (prop == null)
                throw new ArgumentNullException("prop");

            bool? found = null;

            foreach (MethodInfo method in prop.GetAccessors())
            {
                if (found.HasValue)
                {
                    if (found.Value != method.IsVirtual)
                        return null;
                }
                else
                {
                    found = method.IsVirtual;
                }
            }

            return found;
        }

        /// <summary>
        /// Returns a byte array converted from a string
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this string src)
        {
            byte[] dest = new byte[src.Length * sizeof(char)];
            System.Buffer.BlockCopy(src.ToCharArray(), 0, dest, 0, dest.Length);
            return dest;
        }

        /// <summary>
        /// Returns a string converted from a byte array
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string ToStringFromBytes(this byte[] src)
        {
            char[] chars = new char[src.Length / sizeof(char)];
            System.Buffer.BlockCopy(src, 0, chars, 0, src.Length);
            return new string(chars);
        }

        /// <summary>
        /// Returns a center aligned string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CenterString(this string str, int length)
        {
            int spaces = length - str.Length;
            int padLeft = spaces / 2 + str.Length;
            return str.PadLeft(padLeft).PadRight(length);
        }
    }
}
