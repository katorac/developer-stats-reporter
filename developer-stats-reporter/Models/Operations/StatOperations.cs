using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace developer_stats_reporter.Models.Operations
{
    public class StatOperations
    {
        private readonly IEnumerable<Stat> _statCollection;

        public StatOperations()
        {
            var regex = new Regex("\\\"(.*?)\\\"");
            var query = System.IO.File.ReadAllLines("2016Responses.csv")
                 .Skip(1)
                 .Where(line => line.Length > 0)
                 .Select(line =>
                 {
                     var newLine = regex.Replace(line, m => m.Value.Replace(',', ';'));
                     var column = newLine.Split(',');
                     var country = column[2];
                     var gender = column[7];
                     var selfIdentity = column[8];
                     var occupation = column[10];
                     double experience;
                     decimal salary;
                     double.TryParse(column[12], out experience);
                     decimal.TryParse(column[13], out salary);
                     string techUsing = column[15];
                     string techWanting = column[16];
                     string industry = column[20];

                     return new Stat()
                     {
                         Country = country,
                         Gender = gender,
                         SelfIdentify = selfIdentity,
                         Occupation = occupation,
                         Experience = experience,
                         Salary = salary,
                         TechUsing = techUsing,
                         TechWanting = techWanting,
                         Industry = industry
                     };
                 });


            _statCollection = query;
        }

        public IEnumerable<Gender> GetGenderStats(string country)
        {
            var genderStats = _statCollection.Where(stat => stat.Country == country && stat.Gender != "")
                .GroupBy(stat => stat.Gender)
                .Select(stat => new Gender
                {
                    GenderName = stat.Key,
                    GenderCount = stat.Count()
                }).OrderByDescending(stat => stat.GenderCount);

            return genderStats;
        }

        public IEnumerable<SelfIdentify> GetSelfIdentifyStats(string country)
        {
            var selfIdentifyStats = _statCollection.Where(stat => stat.Country == country && stat.SelfIdentify != "")
                .Select(stat => stat.SelfIdentify);

            var splitList = new List<string>();
            foreach (var line in selfIdentifyStats)
            {
                var arr = line.Split(';');
                splitList.AddRange(arr.Select(value => value.Trim()));
            }

            var newSelfIdentifyStats = splitList.GroupBy(stat => stat)
                .Select(stat => new SelfIdentify
                {
                    SelfIdentifyName = stat.Key,
                    SelfIdentifyCount = stat.Count()
                }).OrderByDescending(stat => stat.SelfIdentifyCount)
                .Take(10);

            return newSelfIdentifyStats;
        }

        public IEnumerable<Occupation> GetOccupationStats(string country)
        {
            var occupationStats = _statCollection.Where(stat => stat.Country == country && stat.Occupation != "")
                .GroupBy(stat => stat.Occupation)
                .Select(stat => new Occupation
                {
                    OccupationName = stat.Key,
                    OccupationCount = stat.Count()
                }).OrderByDescending(stat => stat.OccupationCount)
                .Take(10);

            return occupationStats;
        }

        public Experience GetExperienceStats(string country)
        {
            var experienceStats = _statCollection.Where(stat => stat.Country == country)
                .Select(stat => stat.Experience).Average();

            return new Experience
            {
                YearsAgv = experienceStats
            };
        }

        public Salary GetSalaryStats(string country)
        {
            var salaryStats = _statCollection.Where(stat => stat.Country == country)
                .Select(stat => stat.Salary).Average();

            return new Salary
            {
                SalaryAvg = salaryStats
            };
        }

        public IEnumerable<TechUsing> GetTechUsingStats(string country)
        {
            var techUsingStats = _statCollection.Where(stat => stat.Country == country)
                .Select(stat => stat.TechUsing);

            var splitList = new List<string>();
            foreach (var line in techUsingStats)
            {
                var arr = line.Split(';');
                splitList.AddRange(arr.Select(value => value.Trim()));
            }

            var newTechUsingStats = splitList.GroupBy(stat => stat)
                .Select(stat => new TechUsing
                {
                    TechUsingName = stat.Key,
                    TechUsingCount = stat.Count()
                }).OrderByDescending(stat => stat.TechUsingCount).Take(10);

            return newTechUsingStats;
        }

        public IEnumerable<TechWanting> GetTechWantingStats(string country)
        {
            var techWantingStats = _statCollection.Where(stat => stat.Country == country)
                .Select(stat => stat.TechWanting);

            var splitList = new List<string>();
            foreach (var line in techWantingStats)
            {
                var arr = line.Split(';');
                splitList.AddRange(arr.Select(value => value.Trim()));
            }

            var newTechWantingStats = splitList.GroupBy(stat => stat)
                .Select(stat => new TechWanting
                {
                    TechWantingName = stat.Key,
                    TechWantingCount = stat.Count()
                }).OrderByDescending(stat => stat.TechWantingCount).Take(10);

            return newTechWantingStats;
        }

        public IEnumerable<Industry> GetIndustryStats(string country)
        {
            var industryStats = _statCollection.Where(stat => stat.Country == country & stat.Industry != "")
                .GroupBy(stat => stat.Industry)
                .Select(stat => new Industry
                {
                    IndustryName = stat.Key,
                    IndustryCount = stat.Count()
                }).OrderByDescending(stat => stat.IndustryCount).Take(10);

            return industryStats;
        }

    }
}