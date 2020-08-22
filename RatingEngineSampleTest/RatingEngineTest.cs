using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RatingEngineSample;
using Newtonsoft.Json;
using System.IO;

namespace RatingEngineSampleTest
{
    [TestClass]
    public class RatingEngineTest
    {
        [TestMethod]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Auto,
                Miles = 20000,
                Year = 2000,
                Price = 10000000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            var engine = new RatingEngine();
            engine.Rate();
            var result = engine.Rating;

            Assert.AreEqual(10000, result);
        }

        //[TestMethod]
        //public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        //{
        //    var policy = new Policy
        //    {
        //        Type = PolicyType.Land,
        //        BondAmount = 200000,
        //        Valuation = 260000
        //    };
        //    string json = JsonConvert.SerializeObject(policy);
        //    File.WriteAllText("policy.json", json);

        //    var engine = new RatingEngine();
        //    engine.Rate();
        //    var result = engine.Rating;

        //    Assert.AreEqual(0, result);
        //}
    }
}
