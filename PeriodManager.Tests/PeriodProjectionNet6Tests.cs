using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeriodProjectionSrc;
using System;
using System.Diagnostics;

namespace PeriodProjection_Net6_Tests
{
    [TestClass]
    public class PeriodProjectionNet6Tests
    {
        [TestMethod]
        public void Test_Date_In_The_Past_No_Input()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2022, 04, 24);
            string pastPeriodConstraints = "";
            string futurePeriodConstraints = "";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item1, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Past_Invalid_Input()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2022, 04, 24);
            string pastPeriodConstraints = "+15X-9Z";
            string futurePeriodConstraints = "";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item1, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Past_All_Upper()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2020, 06, 19);
            string pastPeriodConstraints = "2M-2Y-1W+2D";
            string futurePeriodConstraints = "";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item1, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Past_All_Upper_Sanitize()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2022, 06, 26);
            string pastPeriodConstraints = "2M-&2Y-1;W+2D-3X";
            string futurePeriodConstraints = "";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item1, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Past_All_Lower()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2020, 06, 19);
            string pastPeriodConstraints = "2m-2y-1w+2d";
            string futurePeriodConstraints = "";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item1, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Past_Mixed_Case_1()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2020, 06, 19);
            string pastPeriodConstraints = "2m-2Y-1w+2D";
            string futurePeriodConstraints = "";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item1, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Past_Mixed_Case_2()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2020, 06, 19);
            string pastPeriodConstraints = "2M-2y-1W+2d";
            string futurePeriodConstraints = "";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item1, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Past_No_Signs()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2024, 07, 03);
            string pastPeriodConstraints = "2M2Y1W2D";
            string futurePeriodConstraints = "";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item1, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Future_No_Input()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2022, 04, 24);
            string pastPeriodConstraints = "";
            string futurePeriodConstraints = "";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item2, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Future_Invalid_Input()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2022, 04, 24);
            string pastPeriodConstraints = "";
            string futurePeriodConstraints = "+15X-9Z";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item2, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Future_All_Upper()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2024, 06, 19);
            string pastPeriodConstraints = "";
            string futurePeriodConstraints = "2M+2Y-1W+2D";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item2, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Future_All_Upper_Sanitize()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2022, 06, 26);
            string pastPeriodConstraints = "";
            string futurePeriodConstraints = "2M+2&Y-1;W+2D+3X";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item2, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Future_All_Lower()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2024, 06, 19);
            string pastPeriodConstraints = "";
            string futurePeriodConstraints = "2m+2y-1w+2d";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item2, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Future_Mixed_Case_1()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2024, 06, 19);
            string pastPeriodConstraints = "";
            string futurePeriodConstraints = "2m+2Y-1w+2D";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item2, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Future_Mixed_Case_2()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2024, 06, 19);
            string pastPeriodConstraints = "";
            string futurePeriodConstraints = "2M+2y-1W+2d";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item2, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Date_In_The_Future_No_Signs()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate = new DateOnly(2024, 07, 03);
            string pastPeriodConstraints = "";
            string futurePeriodConstraints = "2M2Y1W2D";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item2, expectedFinalDate, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Both_Dates()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate1 = new DateOnly(2020, 06, 19);
            DateOnly expectedFinalDate2 = new DateOnly(2024, 06, 19);
            string pastPeriodConstraints = "2M-2Y-1W+2D";
            string futurePeriodConstraints = "2M+2Y-1W+2D";

            PeriodProjection periodProjection = new PeriodProjection();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);

            Assert.AreEqual(finalDates.Item1, expectedFinalDate1, "0", "Wrong final date");
            Assert.AreEqual(finalDates.Item2, expectedFinalDate2, "0", "Wrong final date");
        }

        [TestMethod]
        public void Test_Both_Dates_Performance()
        {
            DateOnly initialDate = new DateOnly(2022, 04, 24);
            DateOnly expectedFinalDate1 = new DateOnly(2020, 06, 19);
            DateOnly expectedFinalDate2 = new DateOnly(2024, 06, 19);
            string pastPeriodConstraints = "2M-2Y-1W+2D";
            string futurePeriodConstraints = "2M+2Y-1W+2D";

            PeriodProjection periodProjection = new PeriodProjection();

            var timer = Stopwatch.StartNew();
            var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);
            timer.Stop();

            Assert.IsTrue(timer.ElapsedMilliseconds < 1);
        }
    }
}