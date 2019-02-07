using System;
/// <summary>
/// 
/// This class represent the date in the game.
/// In the game, time si represented by day, weeks and years. 
/// 
/// A week contains 5 days.
/// A year contains 12 weeks (so ... 5*12 = 60 days)
/// 
/// </summary>
public class GameDate
{
    private const int MAX_DAY_IN_WEEK = 5;
    private const int MAX_WEEK_IN_YEAR = 12;

    private int day;
    private int week;
    private int year;

    public GameDate(int _year, int _week, int _day)
    {
        if(DateIsInvalid(_year,_week, _day))
            throw new ArgumentException("Invalid GameDate Values");
        
        this.day = _day;
        this.week = _week;
        this.year = _year;
    }

    public void NextDay()
    {
        this.day += 1;
        if(day == MAX_DAY_IN_WEEK)
        {
            day = 0;
            week += 1;
            if(week == MAX_WEEK_IN_YEAR)
            {
                week = 0;
                year += 1;
            }
        }
    }

    private bool DateIsInvalid(int _year, int _week, int _day)
    {
        return _year < 0 ||
            _week < 0 || _week >= MAX_WEEK_IN_YEAR ||
            _day < 0 || _day >= MAX_DAY_IN_WEEK;
    }

    public int Year
    {
        get { return year; }
    }

    public int Week
    {
        get { return week; }
    }

    public int Day
    {
        get { return day; }
    }

    
}

