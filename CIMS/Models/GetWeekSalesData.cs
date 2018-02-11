using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIMS.Models
{
    public class GetWeekSalesData
    {
        public List<WeekSales> getWeekSalesData()
        {
            List<WeekSales> weekdata = null;
            List<DailySales> dailyData = GetSalesFromDatabase();
            if (dailyData != null)
            {
                weekdata = (from d in dailyData
                            group d by new
                            {
                                week = GetWeek(d.salesdate),
                                year = d.salesdate.Year
                            }
                            into grpsales
                            select new WeekSales()
                            {
                                weekname = "Week " + GetWeek(grpsales.Select(d=>d.salesdate).First()).ToString(),
                                weelsalescount = grpsales.Sum(d=>d.Bookings)
                            }).ToList();
            }

            return weekdata;
        }

        private int GetWeek(DateTime day)
        {
            return System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(day, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        private List<DailySales>  GetSalesFromDatabase()
        {
            return new List<DailySales> {
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-21),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-20),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-19),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-18),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-17),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-16),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-15),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-14),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-13),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-12),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-11),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-10),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-9),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-8),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-7),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-6),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-5),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-4),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-3),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-2),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now.AddDays(-1),Bookings = 10},
                new DailySales() {salesdate = System.DateTime.Now,Bookings = 10},
            };
        }
    }

    public class DailySales
    {
        public DateTime salesdate { get; set; }
        public int Bookings { get; set; }
    }

    public class WeekSales
    {
        public string weekname { get; set; }
        public int weelsalescount { get; set; }
    }
}