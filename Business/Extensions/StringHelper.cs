using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;

namespace System
{
    public static class StringHelper
    {

        #region To Int List

        public static List<int> ToIntList(this string str)
        {
            List<int> ret = new List<int>();

            if (!string.IsNullOrEmpty(str))
            {
                string[] idList = str.Split('-');
                if (idList.Count() > 0)
                {
                    int nextId = 0;
                    foreach (string id in idList)
                    {
                        if (int.TryParse(id, out nextId))
                        {
                            ret.Add(nextId);
                        }
                    }
                }
            }

            return ret;
        }

        #endregion

        #region To Int

        public static int ToInt(this string str)
        {
            return str.ToInt(-1);
        }

        public static int ToInt(this string str, int defaultReturn)
        {
            if (string.IsNullOrEmpty(str))
            {
                return defaultReturn;
            }
            else
            {
                int testInt = -1;
                if (int.TryParse(str, out testInt))
                {
                    return testInt;
                }
                else
                {
                    return defaultReturn;
                }
            }
        }
        #endregion

        #region To Date

        public static DateTime ToDate(this string str)
        {
            return str.ToDate(new DateTime(1900, 1, 1));
        }

        public static DateTime ToDate(this string str, DateTime defaultReturn)
        {
            if (string.IsNullOrEmpty(str))
            {
                return defaultReturn;
            }

            DateTime dt = new DateTime(defaultReturn.Ticks);

            if (DateTime.TryParse(str, out dt))
            {
                if (dt > defaultReturn)
                {
                    return dt;
                }
                else
                {
                    return defaultReturn;
                }
            }
            else
            {
                return defaultReturn;
            }



        }

        #endregion

        #region To Bool
        public static bool ToBool(this string str, bool emptyVal = false)
        {
            bool ret = emptyVal;
            bool.TryParse(str, out ret);
            return ret;
        }
        #endregion

        #region Apply Format

        public static string ApplyFormat(this string str, params object[] formatAgrs)
        {
            return string.Format(str, formatAgrs);
        }
        #endregion
   
    }
}
