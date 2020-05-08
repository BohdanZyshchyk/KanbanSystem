using System;

namespace KanbanSystemDAL.AdditionalClasses.Helpers
{
    public static class CheckNullHelper<T> where T : class
    {
        /// <summary>
        /// Check if <paramref name="obj"/> is null and compares with <paramref name="mustBeNull"/>.
        /// Returns <paramref name="obj"/> if comparison was successful.
        /// Throws exception with <paramref name="msg"/> if not.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        /// <param name="mustBeNull"></param>
        /// <returns><paramref name="obj"/> if check passed throws esception with <paramref name="msg"/> if not</returns>
        public static T CheckNullable(T obj, string msg, bool mustBeNull)
        {
            if (mustBeNull)
            {
                return obj == null ? obj : throw new Exception(msg);
            }
            else
            {
                return obj != null ? obj : throw new Exception(msg);
            }
        }
    }
}
