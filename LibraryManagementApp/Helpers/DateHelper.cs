using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp
{
    public static class DateHelper
    {
        /// <summary>
        /// Converts to DateTime a date given in a String format.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime? ConvertStringToDate(string date)
        {
            string[] nums = date.Split('/');
            try
            {
                return new DateTime(int.Parse(nums[2]), int.Parse(nums[1]), int.Parse(nums[0]));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
