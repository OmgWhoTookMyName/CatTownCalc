namespace CatTownCalc.DataAccess;

using CatTownCalc.Model;
//Script responsible for calculating time till next cat creation

public class Meowculator
{
    public static DateTime CalculateNextTimeToSell(int floof, int cats, float bonusPercent)
    {
        if(floof <= 0 || cats <= 0)
            return new DateTime();//TODO: Return some info to the user
        
        float floofCats = floof / 8640000f;
        
        float fractionKitties = floofCats - (float)Math.Truncate(floofCats);
        
        float neededfractionalKitties = 1 - fractionKitties;
        
        float neededFloofs = neededfractionalKitties * 8640000f;

        float floofsPerSecond = cats + (bonusPercent * .01f * cats);//Bonuses are reported in ints so need to be converted
        
        float secondsTillNextFullCat = neededFloofs / floofsPerSecond;

        int seconds = (int)Math.Truncate((secondsTillNextFullCat));
        
        // Get the current time
        DateTime currentTime = DateTime.Now.ToUniversalTime();

        // Add seconds to the current time
        DateTime newTime = currentTime.AddSeconds(seconds);
        
        return newTime;
    }

    public static TimeSpan CalculateTimeTillTony()
    {
        DateTime currentTime = DateTime.Now;
        
        DateTime tonyClosingTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 19, 00, 00);
        
        bool isTonyOpen = tonyClosingTime > currentTime;

        if (isTonyOpen)
        {
            return tonyClosingTime.Subtract(currentTime);
        }
        else
        {
            DateTime tomorrowTony = tonyClosingTime.AddDays(1);
            return tomorrowTony.Subtract(currentTime);
        }
    }


    public static List<TimeZones> GetAllTimezones(DateTime currentTime)
    {
        List<TimeZones> majorZones = new List<TimeZones>();
    
        // UTC
        TimeZones utcTimeZone = new TimeZones()
        {
            timeZoneName = "UTC",
            time = currentTime
        };
        majorZones.Add(utcTimeZone);
    
        // Eastern Standard Time (EST)
        TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        TimeZones estTimeZone = new TimeZones()
        {
            timeZoneName = "EST",
            time = TimeZoneInfo.ConvertTimeFromUtc(currentTime, easternZone)
        };
        majorZones.Add(estTimeZone);
    
        // Central European Time (CET)
        TimeZoneInfo cetZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
        TimeZones cetTimeZone = new TimeZones()
        {
            timeZoneName = "CET",
            time = TimeZoneInfo.ConvertTimeFromUtc(currentTime, cetZone)
        };
        majorZones.Add(cetTimeZone);
    
        // Japan Standard Time (JST)
        TimeZoneInfo jstZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
        TimeZones jstTimeZone = new TimeZones()
        {
            timeZoneName = "JST",
            time = TimeZoneInfo.ConvertTimeFromUtc(currentTime, jstZone)
        };
        majorZones.Add(jstTimeZone);

        return majorZones;
    }
}