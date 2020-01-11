namespace LibraryManagementApp
{
    using System;

    /// <summary>
    /// A helper class to process the format of a DateTime object.
    /// </summary>
    public static class DateHelper
    {
        /// <summary>
        /// Converts to DateTime a date given in a String format.
        /// </summary>
        /// <param name="date">The date to be converted.</param>
        /// <returns>Null or the converted date.</returns>
        public static DateTime? ConvertStringToDate(string date)
        {
            string[] nums = date.Split('/');
            try
            {
                return new DateTime(int.Parse(nums[2]), int.Parse(nums[1]), int.Parse(nums[0]));
            }
            catch (Exception ex)
            {
                int count = ex.Data.Count;
                return null;
            }
        }
    }
}
