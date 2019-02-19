using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CityTestMethod
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void switch_City_Name()
        {
            string CityName = "Delhi";
            switch (CityName)
            {
                case "Kol":
                    CityName = "Kolkatta";
                    break;
                case "Mum":
                    CityName = "Mumbai";
                    break;
                case  "Del":
                    CityName = "New Delhi";
                    break;
            }
            stringAssert.Equals(CityName, "New Dehli");
        }
    }
}
