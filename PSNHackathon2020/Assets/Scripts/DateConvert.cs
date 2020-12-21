using System;
using UnityEngine;

public static class DateConvert
{
    private static string[] months = new string[]
    {
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
    };

    public static string DateToWords(DateTime dt, bool includeOf)
    {
        string day = "";

        switch (dt.Day)
        {
            case 1:
                day = "1st";
                break;
            case 2:
                day = "2nd";
                break;
            case 3:
                day = "3rd";
                break;
            case 21:
                day = "21st";
                break;
            case 22:
                day = "22nd";
                break;
            case 23:
                day = "23rd";
                break;
            case 31:
                day = "31st";
                break;
        }

        if (string.IsNullOrEmpty(day)) day = $"{dt.Day}th";

        string month = months[dt.Month - 1];

        if (includeOf) return $"{day} of\n{month}, {dt.Year}";
        return $"{day} {month}, {dt.Year}";
    }
}
