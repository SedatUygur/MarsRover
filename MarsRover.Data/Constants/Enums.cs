using System;

namespace MarsRover.Data.Constants
{
    /// <summary>Enum Extension</summary>
    public static class EnumExtension
    {
        /// <summary>To enum val method</summary>
        /// <typeparam name="T">Enum type for casting</typeparam>
        /// <param name="value">Value</param>
        /// <returns></returns>
        public static T ToEnumVal<T>(this string value) where T : System.Enum
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                return default;
            }
        }
    }

    /// <summary>
    /// Directions
    /// </summary>
    public enum Directions
    {
        N,//North
        W,//West
        E,//East
        S,//South
    }
}
