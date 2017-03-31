using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using developer_stats_reporter.Models.Operations;

namespace developer_stats_reporter.Controllers
{
    [Route("api/stat")]
    public class StatController : ApiController
    {
        private readonly StatOperations _statOperations;

        public StatController()
        {
            _statOperations = new StatOperations();
        }

        public IHttpActionResult Get()
        {
            return Ok("Hello");
        }

        [Route("api/stat/getGenderStats/{country}")]
        public IHttpActionResult GetGenderStats(string country)
        {
            var genderStats = _statOperations.GetGenderStats(country);

            return Ok(genderStats);
        }

        [Route("api/stat/getSelfIdentifyStats/{country}")]
        public IHttpActionResult GetSelfIdentifyStats(string country)
        {
            var selfIdentifyStats = _statOperations.GetSelfIdentifyStats(country);

            return Ok(selfIdentifyStats);
        }

        [Route("api/stat/getOccupationStats/{country}")]
        public IHttpActionResult GetOccupationStats(string country)
        {
            var occupationStats = _statOperations.GetOccupationStats(country);

            return Ok(occupationStats);
        }

        [Route("api/stat/getExperienceStats/{country}")]
        public IHttpActionResult GetExperienceStats(string country)
        {
            var experienceStats = _statOperations.GetExperienceStats(country);

            return Ok(experienceStats);
        }

        [Route("api/stat/getSalaryStats/{country}")]
        public IHttpActionResult GetSalaryStats(string country)
        {
            var salaryStats = _statOperations.GetSalaryStats(country);

            return Ok(salaryStats);
        }

        [Route("api/stat/getTechUsingStats/{country}")]
        public IHttpActionResult GetTechUsingStats(string country)
        {
            var techUsingStats = _statOperations.GetTechUsingStats(country);

            return Ok(techUsingStats);
        }

        [Route("api/stat/getTechWantingStats/{country}")]
        public IHttpActionResult GetTechWantingStats(string country)
        {
            var techWantingStats = _statOperations.GetTechWantingStats(country);

            return Ok(techWantingStats);
        }

        [Route("api/stat/getIndustryStats/{country}")]
        public IHttpActionResult GetIndustryStats(string country)
        {
            var industryStats = _statOperations.GetIndustryStats(country);

            return Ok(industryStats);
        }

    }
}
