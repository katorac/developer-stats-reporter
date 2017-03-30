using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developer_stats_reporter.Models.Operations
{
    public interface IStatOperations
    {
        IEnumerable<Gender> GetGenderStats(string country);
        IEnumerable<SelfIdentify> GetSelfIdentifyStats(string country);
        IEnumerable<Occupation> GetOccupationStats(string country);
        Experience GetExperienceStats(string country);
        Salary GetSalaryStats(string country);
        IEnumerable<TechUsing> GetTechUsingStats(string country);
        IEnumerable<TechWanting> GetTechWantingStats(string country);
        IEnumerable<Industry> GetIndustryStats(string country);
        IEnumerable<string> GetCountries();
    }
}
