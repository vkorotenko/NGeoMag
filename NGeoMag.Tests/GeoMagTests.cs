#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  10.07.2020 21:10
#endregion

using System;
using Xunit;

namespace NGeoMag.Tests
{


    /*                     <p><center>PUBLIC DOMAIN NOTICE</center></p><p>
	This program was prepared by Los Alamos National Security, LLC 
	at Los Alamos National Laboratory (LANL) under contract No. 
	DE-AC52-06NA25396 with the U.S. Department of Energy (DOE). 
	All rights in the program are reserved by the DOE and 
	Los Alamos National Security, LLC.  Permission is granted to the 
	public to copy and use this software without charge, 
	provided that this Notice and any statement of authorship are 
	reproduced on all copies.  Neither the U.S. Government nor LANS 
	makes any warranty, express or implied, or assumes any liability 
	or responsibility for the use of this software.
	 */



    /**<p>
	 *  Test values from
	 *  <a href ="http://www.ngdc.noaa.gov/geomag/WMM/soft.shtml"> the National GeoPhysical Data Center.</a>.
	 *  Click on the WMM2015testvalues.pdf link.
	 *  </p><p>
	 *  You have to run this test twice. Once with the WMM.COF
	 *  file present, and then with it missing. Otherwise the
	 *  setCoeff method is never tested.</p>
	 *  
	 * @version 1.0 Apr 14, 2006
	 * @author John St. Ledger
	 * @version 1.1 Jan 28, 2009
	 * <p>Added 2006 test values.</p>
	 * @version 1.2 Jan 5, 2010
	 * <p>Updated with the test values for the 2010 WMM.COF coefficients. From page 18 of
	 * <i>The US/UK World Magnetic Model for 2010-2015, Preliminary online version containing
	 * WMM2010 model coefficients</i></p>
	 * @version 1.3 Jan 15, 2015
	 * <p>Updated with the test values for the 2015 WMM.COF coefficients. From the test values WMM2015testvalues.pdf
	 * from the WMM web site.</p> * @version 1.4 May 26, 2015
	 * <p>Fixed the East-West, North-South bug discovered by Martin Frassl.</p>
	 * <p>Updated with the test values for the 2015 WMM.COF coefficients using the 2018 update. From the test values WMM2015testvalues.pdf
	 * from the WMM web site.</p> * @version 1.4 May 26, 2015</p>
	 * <p>Updated with the test values for the 2020 WMM.COF coefficients using the Dec 2019 update. From the test values WMM2020_TEST_VALUES.txt
	 * from the WMM web site.</p> * @version 1.5 Jan 6, 2020</p>
	 */
    public class GeoMagTests
    {
        GeoMag magModel = new GeoMag("WMM.COF");
        /**
		 * Test method for {@link d3.env.TSAGeoMag#getDeclination(double, double, double, double)}
		 */
        [Fact]
        public void GetDeclination()
        {
            magModel.GetType();
            Assert.Equal(-112.41, magModel.GetDeclination(89, -121, 2020.0, 28), 2);
            Assert.Equal(-112.41, magModel.GetDeclination(89, -121, 2020.0, 28),2);
            Assert.Equal(-112.41, magModel.GetDeclination(89, -121, 2020.0, 28),2);
            Assert.Equal(-112.39, magModel.GetDeclination(89, -121, 2020.0, 27),2);
            Assert.Equal(-37.40, magModel.GetDeclination(80, -96, 2020.0, 48),2);
            Assert.Equal(51.30, magModel.GetDeclination(82, 87, 2020.0, 54),2);
            Assert.Equal(0.71, magModel.GetDeclination(43, 93, 2020.0, 65),2);
            Assert.Equal(-5.78, magModel.GetDeclination(-33, 109, 2020.0, 51),2);
            Assert.Equal(-15.79, magModel.GetDeclination(-59, -8, 2020.0, 39),2);
            Assert.Equal(28.10, magModel.GetDeclination(-50, -103, 2020.0, 3),2);
            Assert.Equal(15.82, magModel.GetDeclination(-29, -110, 2020.0, 94),2);
            Assert.Equal(0.12, magModel.GetDeclination(14, 143, 2020.0, 66),2);
            Assert.Equal(1.05, magModel.GetDeclination(0, 21, 2020.0, 18),2);

            Assert.Equal(20.16, magModel.GetDeclination(-36, -137, 2020.5, 6),2);
            Assert.Equal(0.43, magModel.GetDeclination(26, 81, 2020.5, 63),2);
            Assert.Equal(13.39, magModel.GetDeclination(38, -144, 2020.5, 69),2);
            Assert.Equal(57.40, magModel.GetDeclination(-70, -133, 2020.5, 50),2);
            Assert.Equal(15.39, magModel.GetDeclination(-52, -75, 2020.5, 8),2);
            Assert.Equal(-32.56, magModel.GetDeclination(-66, 17, 2020.5, 8),2);
            Assert.Equal(9.15, magModel.GetDeclination(-37, 140, 2020.5, 22),2);
            Assert.Equal(10.83, magModel.GetDeclination(-12, -129, 2020.5, 40),2);
            Assert.Equal(11.46, magModel.GetDeclination(33, -118, 2020.5, 44),2);
            Assert.Equal(28.65, magModel.GetDeclination(-81, -67, 2020.5, 50),2);

            Assert.Equal(-22.29, magModel.GetDeclination(-57, 3, 2021.0, 74),2);
            Assert.Equal(14.02, magModel.GetDeclination(-24, -122, 2021.0, 46),2);
            Assert.Equal(1.08, magModel.GetDeclination(23, 63, 2021.0, 69),2);
            Assert.Equal(9.74, magModel.GetDeclination(-3, -147, 2021.0, 33),2);
            Assert.Equal(-6.05, magModel.GetDeclination(-72, -22, 2021.0, 47),2);
            Assert.Equal(-1.71, magModel.GetDeclination(-14, 99, 2021.0, 62),2);
            Assert.Equal(-36.71, magModel.GetDeclination(86, -46, 2021.0, 83),2);
            Assert.Equal(-80.81, magModel.GetDeclination(-64, 87, 2021.0, 82),2);
            Assert.Equal(-14.32, magModel.GetDeclination(-19, 43, 2021.0, 34),2);
            Assert.Equal(-59.03, magModel.GetDeclination(-81, 40, 2021.0, 56),2);

            Assert.Equal(-3.41, magModel.GetDeclination(0, 80, 2021.5, 14),2);
            Assert.Equal(30.36, magModel.GetDeclination(-82, -68, 2021.5, 12),2);
            Assert.Equal(-11.54, magModel.GetDeclination(-46, -42, 2021.5, 44),2);
            Assert.Equal(1.23, magModel.GetDeclination(17, 52, 2021.5, 43),2);
            Assert.Equal(-1.71, magModel.GetDeclination(10, 78, 2021.5, 64),2);
            Assert.Equal(12.36, magModel.GetDeclination(33, -145, 2021.5, 12),2);
            Assert.Equal(-136.34, magModel.GetDeclination(-79, 115, 2021.5, 12),2);
            Assert.Equal(18.10, magModel.GetDeclination(-33, -114, 2021.5, 14),2);
            Assert.Equal(2.13, magModel.GetDeclination(29, 66, 2021.5, 19),2);
            Assert.Equal(10.11, magModel.GetDeclination(-11, 167, 2021.5, 86),2);

            Assert.Equal(-16.99, magModel.GetDeclination(-66, -5, 2022.0, 37),2);
            Assert.Equal(15.47, magModel.GetDeclination(72, -115, 2022.0, 67),2);
            Assert.Equal(6.56, magModel.GetDeclination(22, 174, 2022.0, 44),2);
            Assert.Equal(1.43, magModel.GetDeclination(54, 178, 2022.0, 54),2);
            Assert.Equal(-47.43, magModel.GetDeclination(-43, 50, 2022.0, 57),2);
            Assert.Equal(24.32, magModel.GetDeclination(-43, -111, 2022.0, 44),2);
            Assert.Equal(57.08, magModel.GetDeclination(-63, 178, 2022.0, 12),2);
            Assert.Equal(8.76, magModel.GetDeclination(27, -169, 2022.0, 38),2);
            Assert.Equal(-17.63, magModel.GetDeclination(59, -77, 2022.0, 61),2);
            Assert.Equal(-14.09, magModel.GetDeclination(-47, -32, 2022.0, 67),2);

            Assert.Equal(18.95, magModel.GetDeclination(62, 53, 2022.5, 8),2);
            Assert.Equal(-15.94, magModel.GetDeclination(-68, -7, 2022.5, 77),2);
            Assert.Equal(7.79, magModel.GetDeclination(-5, 159, 2022.5, 98),2);
            Assert.Equal(15.68, magModel.GetDeclination(-29, -107, 2022.5, 34),2);
            Assert.Equal(1.78, magModel.GetDeclination(27, 65, 2022.5, 60),2);
            Assert.Equal(-101.49, magModel.GetDeclination(-72, 95, 2022.5, 73),2);
            Assert.Equal(18.38, magModel.GetDeclination(-46, -85, 2022.5, 96),2);
            Assert.Equal(-16.65, magModel.GetDeclination(-13, -59, 2022.5, 0),2);
            Assert.Equal(1.92, magModel.GetDeclination(66, -178, 2022.5, 16),2);
            Assert.Equal(-64.66, magModel.GetDeclination(-87, 38, 2022.5, 72),2);

            Assert.Equal(5.20, magModel.GetDeclination(20, 167, 2023.0, 49),2);
            Assert.Equal(-7.26, magModel.GetDeclination(5, -13, 2023.0, 71),2);
            Assert.Equal(-0.56, magModel.GetDeclination(14, 65, 2023.0, 95),2);
            Assert.Equal(41.76, magModel.GetDeclination(-85, -79, 2023.0, 86),2);
            Assert.Equal(-3.87, magModel.GetDeclination(-36, -64, 2023.0, 30),2);
            Assert.Equal(-14.54, magModel.GetDeclination(79, 125, 2023.0, 75),2);
            Assert.Equal(-15.22, magModel.GetDeclination(6, -32, 2023.0, 21),2);
            Assert.Equal(30.36, magModel.GetDeclination(-76, -75, 2023.0, 1),2);
            Assert.Equal(-11.94, magModel.GetDeclination(-46, -41, 2023.0, 45),2);
            Assert.Equal(-24.12, magModel.GetDeclination(-22, -21, 2023.0, 11),2);

            Assert.Equal(16.20, magModel.GetDeclination(54, -120, 2023.5, 28),2);
            Assert.Equal(40.48, magModel.GetDeclination(-58, 156, 2023.5, 68),2);
            Assert.Equal(29.86, magModel.GetDeclination(-65, -88, 2023.5, 39),2);
            Assert.Equal(-13.98, magModel.GetDeclination(-23, 81, 2023.5, 27),2);
            Assert.Equal(1.08, magModel.GetDeclination(34, 0, 2023.5, 11),2);
            Assert.Equal(-66.98, magModel.GetDeclination(-62, 65, 2023.5, 72),2);
            Assert.Equal(61.19, magModel.GetDeclination(86, 70, 2023.5, 55),2);
            Assert.Equal(0.36, magModel.GetDeclination(32, 163, 2023.5, 59),2);
            Assert.Equal(-9.39, magModel.GetDeclination(48, 148, 2023.5, 65),2);
            Assert.Equal(4.49, magModel.GetDeclination(30, 28, 2023.5, 95),2);

            Assert.Equal(8.86, magModel.GetDeclination(-60, -59, 2024.0, 95),2);
            Assert.Equal(-54.29, magModel.GetDeclination(-70, 42, 2024.0, 95),2);
            Assert.Equal(-82.22, magModel.GetDeclination(87, -154, 2024.0, 50),2);
            Assert.Equal(3.94, magModel.GetDeclination(32, 19, 2024.0, 58),2);
            Assert.Equal(-2.62, magModel.GetDeclination(34, -13, 2024.0, 57),2);
            Assert.Equal(-63.51, magModel.GetDeclination(-76, 49, 2024.0, 38),2);
            Assert.Equal(31.57, magModel.GetDeclination(-50, -179, 2024.0, 49),2);
            Assert.Equal(38.07, magModel.GetDeclination(-55, -171, 2024.0, 90),2);
            Assert.Equal(-5.00, magModel.GetDeclination(42, -19, 2024.0, 41),2);
            Assert.Equal(-6.60, magModel.GetDeclination(46, -22, 2024.0, 19),2);

            Assert.Equal(9.21, magModel.GetDeclination(13, -132, 2024.5, 31),2);
            Assert.Equal(7.16, magModel.GetDeclination(-2, 158, 2024.5, 93),2);
            Assert.Equal(-55.63, magModel.GetDeclination(-76, 40, 2024.5, 51),2);
            Assert.Equal(10.52, magModel.GetDeclination(22, -132, 2024.5, 64),2);
            Assert.Equal(-62.60, magModel.GetDeclination(-65, 55, 2024.5, 26),2);
            Assert.Equal(-13.34, magModel.GetDeclination(-21, 32, 2024.5, 66),2);
            Assert.Equal(9.39, magModel.GetDeclination(9, -172, 2024.5, 18),2);
            Assert.Equal(29.81, magModel.GetDeclination(88, 26, 2024.5, 63),2);
            Assert.Equal(0.61, magModel.GetDeclination(17, 5, 2024.5, 33),2);
            Assert.Equal(4.63, magModel.GetDeclination(-18, 138, 2024.5, 77),2);

        }

        /**
		 * Test method for {@link d3.env.TSAGeoMag#getDipAngle(double, double, double, double)}
		 */
        [Fact]
        public void GetDipAngle()
        {
            Assert.Equal(88.46, magModel.GetDipAngle(89, -121, 2020.0, 28),2);
            Assert.Equal(88.03, magModel.GetDipAngle(80, -96, 2020.0, 48),2);
            Assert.Equal(87.48, magModel.GetDipAngle(82, 87, 2020.0, 54),2);
            Assert.Equal(63.87, magModel.GetDipAngle(43, 93, 2020.0, 65),2);
            Assert.Equal(-67.64, magModel.GetDipAngle(-33, 109, 2020.0, 51),2);
            Assert.Equal(-58.82, magModel.GetDipAngle(-59, -8, 2020.0, 39),2);
            Assert.Equal(-55.01, magModel.GetDipAngle(-50, -103, 2020.0, 3),2);
            Assert.Equal(-38.38, magModel.GetDipAngle(-29, -110, 2020.0, 94),2);
            Assert.Equal(13.08, magModel.GetDipAngle(14, 143, 2020.0, 66),2);
            Assert.Equal(-26.46, magModel.GetDipAngle(0, 21, 2020.0, 18),2);

            Assert.Equal(-52.21, magModel.GetDipAngle(-36, -137, 2020.5, 6),2);
            Assert.Equal(40.84, magModel.GetDipAngle(26, 81, 2020.5, 63),2);
            Assert.Equal(56.99, magModel.GetDipAngle(38, -144, 2020.5, 69),2);
            Assert.Equal(-72.18, magModel.GetDipAngle(-70, -133, 2020.5, 50),2);
            Assert.Equal(-49.50, magModel.GetDipAngle(-52, -75, 2020.5, 8),2);
            Assert.Equal(-59.78, magModel.GetDipAngle(-66, 17, 2020.5, 8),2);
            Assert.Equal(-68.61, magModel.GetDipAngle(-37, 140, 2020.5, 22),2);
            Assert.Equal(-15.68, magModel.GetDipAngle(-12, -129, 2020.5, 40),2);
            Assert.Equal(57.97, magModel.GetDipAngle(33, -118, 2020.5, 44),2);
            Assert.Equal(-67.74, magModel.GetDipAngle(-81, -67, 2020.5, 50),2);

            Assert.Equal(-59.07, magModel.GetDipAngle(-57, 3, 2021.0, 74),2);
            Assert.Equal(-34.29, magModel.GetDipAngle(-24, -122, 2021.0, 46),2);
            Assert.Equal(35.82, magModel.GetDipAngle(23, 63, 2021.0, 69),2);
            Assert.Equal(-2.35, magModel.GetDipAngle(-3, -147, 2021.0, 33),2);
            Assert.Equal(-61.27, magModel.GetDipAngle(-72, -22, 2021.0, 47),2);
            Assert.Equal(-45.11, magModel.GetDipAngle(-14, 99, 2021.0, 62),2);
            Assert.Equal(86.83, magModel.GetDipAngle(86, -46, 2021.0, 83),2);
            Assert.Equal(-75.25, magModel.GetDipAngle(-64, 87, 2021.0, 82),2);
            Assert.Equal(-52.47, magModel.GetDipAngle(-19, 43, 2021.0, 34),2);
            Assert.Equal(-68.54, magModel.GetDipAngle(-81, 40, 2021.0, 56),2);

            Assert.Equal(-17.32, magModel.GetDipAngle(0, 80, 2021.5, 14),2);
            Assert.Equal(-68.18, magModel.GetDipAngle(-82, -68, 2021.5, 12),2);
            Assert.Equal(-53.82, magModel.GetDipAngle(-46, -42, 2021.5, 44),2);
            Assert.Equal(23.87, magModel.GetDipAngle(17, 52, 2021.5, 43),2);
            Assert.Equal(7.37, magModel.GetDipAngle(10, 78, 2021.5, 64),2);
            Assert.Equal(52.51, magModel.GetDipAngle(33, -145, 2021.5, 12),2);
            Assert.Equal(-77.43, magModel.GetDipAngle(-79, 115, 2021.5, 12),2);
            Assert.Equal(-44.23, magModel.GetDipAngle(-33, -114, 2021.5, 14),2);
            Assert.Equal(45.97, magModel.GetDipAngle(29, 66, 2021.5, 19),2);
            Assert.Equal(-31.45, magModel.GetDipAngle(-11, 167, 2021.5, 86),2);

            Assert.Equal(-59.27, magModel.GetDipAngle(-66, -5, 2022.0, 37),2);
            Assert.Equal(85.19, magModel.GetDipAngle(72, -115, 2022.0, 67),2);
            Assert.Equal(31.91, magModel.GetDipAngle(22, 174, 2022.0, 44),2);
            Assert.Equal(65.41, magModel.GetDipAngle(54, 178, 2022.0, 54),2);
            Assert.Equal(-62.96, magModel.GetDipAngle(-43, 50, 2022.0, 57),2);
            Assert.Equal(-52.71, magModel.GetDipAngle(-43, -111, 2022.0, 44),2);
            Assert.Equal(-79.33, magModel.GetDipAngle(-63, 178, 2022.0, 12),2);
            Assert.Equal(42.60, magModel.GetDipAngle(27, -169, 2022.0, 38),2);
            Assert.Equal(79.04, magModel.GetDipAngle(59, -77, 2022.0, 61),2);
            Assert.Equal(-57.63, magModel.GetDipAngle(-47, -32, 2022.0, 67),2);

            Assert.Equal(76.54, magModel.GetDipAngle(62, 53, 2022.5, 8),2);
            Assert.Equal(-60.00, magModel.GetDipAngle(-68, -7, 2022.5, 77),2);
            Assert.Equal(-23.04, magModel.GetDipAngle(-5, 159, 2022.5, 98),2);
            Assert.Equal(-37.65, magModel.GetDipAngle(-29, -107, 2022.5, 34),2);
            Assert.Equal(42.84, magModel.GetDipAngle(27, 65, 2022.5, 60),2);
            Assert.Equal(-76.44, magModel.GetDipAngle(-72, 95, 2022.5, 73),2);
            Assert.Equal(-47.38, magModel.GetDipAngle(-46, -85, 2022.5, 96),2);
            Assert.Equal(-13.41, magModel.GetDipAngle(-13, -59, 2022.5, 0),2);
            Assert.Equal(75.67, magModel.GetDipAngle(66, -178, 2022.5, 16),2);
            Assert.Equal(-71.05, magModel.GetDipAngle(-87, 38, 2022.5, 72),2);

            Assert.Equal(26.85, magModel.GetDipAngle(20, 167, 2023.0, 49),2);
            Assert.Equal(-17.38, magModel.GetDipAngle(5, -13, 2023.0, 71),2);
            Assert.Equal(17.52, magModel.GetDipAngle(14, 65, 2023.0, 95),2);
            Assert.Equal(-70.36, magModel.GetDipAngle(-85, -79, 2023.0, 86),2);
            Assert.Equal(-39.40, magModel.GetDipAngle(-36, -64, 2023.0, 30),2);
            Assert.Equal(87.30, magModel.GetDipAngle(79, 125, 2023.0, 75),2);
            Assert.Equal(-7.26, magModel.GetDipAngle(6, -32, 2023.0, 21),2);
            Assert.Equal(-65.32, magModel.GetDipAngle(-76, -75, 2023.0, 1),2);
            Assert.Equal(-54.45, magModel.GetDipAngle(-46, -41, 2023.0, 45),2);
            Assert.Equal(-56.82, magModel.GetDipAngle(-22, -21, 2023.0, 11),2);

            Assert.Equal(74.02, magModel.GetDipAngle(54, -120, 2023.5, 28),2);
            Assert.Equal(-81.60, magModel.GetDipAngle(-58, 156, 2023.5, 68),2);
            Assert.Equal(-60.29, magModel.GetDipAngle(-65, -88, 2023.5, 39),2);
            Assert.Equal(-58.52, magModel.GetDipAngle(-23, 81, 2023.5, 27),2);
            Assert.Equal(46.69, magModel.GetDipAngle(34, 0, 2023.5, 11),2);
            Assert.Equal(-68.38, magModel.GetDipAngle(-62, 65, 2023.5, 72),2);
            Assert.Equal(87.51, magModel.GetDipAngle(86, 70, 2023.5, 55),2);
            Assert.Equal(43.05, magModel.GetDipAngle(32, 163, 2023.5, 59),2);
            Assert.Equal(61.70, magModel.GetDipAngle(48, 148, 2023.5, 65),2);
            Assert.Equal(44.12, magModel.GetDipAngle(30, 28, 2023.5, 95),2);

            Assert.Equal(-55.03, magModel.GetDipAngle(-60, -59, 2024.0, 95),2);
            Assert.Equal(-64.59, magModel.GetDipAngle(-70, 42, 2024.0, 95),2);
            Assert.Equal(89.39, magModel.GetDipAngle(87, -154, 2024.0, 50),2);
            Assert.Equal(45.89, magModel.GetDipAngle(32, 19, 2024.0, 58),2);
            Assert.Equal(45.83, magModel.GetDipAngle(34, -13, 2024.0, 57),2);
            Assert.Equal(-67.40, magModel.GetDipAngle(-76, 49, 2024.0, 38),2);
            Assert.Equal(-71.40, magModel.GetDipAngle(-50, -179, 2024.0, 49),2);
            Assert.Equal(-72.91, magModel.GetDipAngle(-55, -171, 2024.0, 90),2);
            Assert.Equal(56.57, magModel.GetDipAngle(42, -19, 2024.0, 41),2);
            Assert.Equal(61.04, magModel.GetDipAngle(46, -22, 2024.0, 19),2);

            Assert.Equal(31.51, magModel.GetDipAngle(13, -132, 2024.5, 31),2);
            Assert.Equal(-17.78, magModel.GetDipAngle(-2, 158, 2024.5, 93),2);
            Assert.Equal(-66.27, magModel.GetDipAngle(-76, 40, 2024.5, 51),2);
            Assert.Equal(43.88, magModel.GetDipAngle(22, -132, 2024.5, 64),2);
            Assert.Equal(-65.67, magModel.GetDipAngle(-65, 55, 2024.5, 26),2);
            Assert.Equal(-56.95, magModel.GetDipAngle(-21, 32, 2024.5, 66),2);
            Assert.Equal(15.78, magModel.GetDipAngle(9, -172, 2024.5, 18),2);
            Assert.Equal(87.38, magModel.GetDipAngle(88, 26, 2024.5, 63),2);
            Assert.Equal(13.58, magModel.GetDipAngle(17, 5, 2024.5, 33),2);
            Assert.Equal(-47.71, magModel.GetDipAngle(-18, 138, 2024.5, 77),2);
        }
        /**
		 * Test method for {@link d3.env.TSAGeoMag#getHorizontalIntensity(double, double, double, double)} in nT
		 * and {@link d3.env.TSAGeoMag#getHorizontalIntensity(double, double)} in nT
		 */
        [Fact]
        public
            void GetHorizontalIntensity()
        {
            Assert.Equal(1510.0, magModel.GetHorizontalIntensity(89, -121, 2020.0, 28),1);
            Assert.Equal(1910.8, magModel.GetHorizontalIntensity(80, -96, 2020.0, 48),1);
            Assert.Equal(2487.8, magModel.GetHorizontalIntensity(82, 87, 2020.0, 54),1);
            Assert.Equal(24377.2, magModel.GetHorizontalIntensity(43, 93, 2020.0, 65),1);
            Assert.Equal(21666.6, magModel.GetHorizontalIntensity(-33, 109, 2020.0, 51),1);
            Assert.Equal(14933.4, magModel.GetHorizontalIntensity(-59, -8, 2020.0, 39),1);
            Assert.Equal(22315.5, magModel.GetHorizontalIntensity(-50, -103, 2020.0, 3),1);
            Assert.Equal(24392.0, magModel.GetHorizontalIntensity(-29, -110, 2020.0, 94),1);
            Assert.Equal(34916.9, magModel.GetHorizontalIntensity(14, 143, 2020.0, 66),1);
            Assert.Equal(29316.1, magModel.GetHorizontalIntensity(0, 21, 2020.0, 18),1);

            Assert.Equal(25511.4, magModel.GetHorizontalIntensity(-36, -137, 2020.5, 6),1);
            Assert.Equal(34738.7, magModel.GetHorizontalIntensity(26, 81, 2020.5, 63),1);
            Assert.Equal(23279.9, magModel.GetHorizontalIntensity(38, -144, 2020.5, 69),1);
            Assert.Equal(16597.2, magModel.GetHorizontalIntensity(-70, -133, 2020.5, 50),1);
            Assert.Equal(20299.7, magModel.GetHorizontalIntensity(-52, -75, 2020.5, 8),1);
            Assert.Equal(18089.7, magModel.GetHorizontalIntensity(-66, 17, 2020.5, 8),1);
            Assert.Equal(21705.2, magModel.GetHorizontalIntensity(-37, 140, 2020.5, 22),1);
            Assert.Equal(29295.6, magModel.GetHorizontalIntensity(-12, -129, 2020.5, 40),1);
            Assert.Equal(23890.9, magModel.GetHorizontalIntensity(33, -118, 2020.5, 44),1);
            Assert.Equal(18332.1, magModel.GetHorizontalIntensity(-81, -67, 2020.5, 50),1);

            Assert.Equal(14296.6, magModel.GetHorizontalIntensity(-57, 3, 2021.0, 74),1);
            Assert.Equal(26836.5, magModel.GetHorizontalIntensity(-24, -122, 2021.0, 46),1);
            Assert.Equal(34456.5, magModel.GetHorizontalIntensity(23, 63, 2021.0, 69),1);
            Assert.Equal(31138.6, magModel.GetHorizontalIntensity(-3, -147, 2021.0, 33),1);
            Assert.Equal(18455.7, magModel.GetHorizontalIntensity(-72, -22, 2021.0, 47),1);
            Assert.Equal(33227.7, magModel.GetHorizontalIntensity(-14, 99, 2021.0, 62),1);
            Assert.Equal(3004.8, magModel.GetHorizontalIntensity(86, -46, 2021.0, 83),1);
            Assert.Equal(14087.8, magModel.GetHorizontalIntensity(-64, 87, 2021.0, 82),1);
            Assert.Equal(19947.3, magModel.GetHorizontalIntensity(-19, 43, 2021.0, 34),1);
            Assert.Equal(17872.0, magModel.GetHorizontalIntensity(-81, 40, 2021.0, 56),1);

            Assert.Equal(39316.2, magModel.GetHorizontalIntensity(0, 80, 2021.5, 14),1);
            Assert.Equal(18536.8, magModel.GetHorizontalIntensity(-82, -68, 2021.5, 12),1);
            Assert.Equal(14450.9, magModel.GetHorizontalIntensity(-46, -42, 2021.5, 44),1);
            Assert.Equal(35904.4, magModel.GetHorizontalIntensity(17, 52, 2021.5, 43),1);
            Assert.Equal(39311.5, magModel.GetHorizontalIntensity(10, 78, 2021.5, 64),1);
            Assert.Equal(24878.3, magModel.GetHorizontalIntensity(33, -145, 2021.5, 12),1);
            Assert.Equal(12997.3, magModel.GetHorizontalIntensity(-79, 115, 2021.5, 12),1);
            Assert.Equal(24820.9, magModel.GetHorizontalIntensity(-33, -114, 2021.5, 14),1);
            Assert.Equal(32640.6, magModel.GetHorizontalIntensity(29, 66, 2021.5, 19),1);
            Assert.Equal(33191.7, magModel.GetHorizontalIntensity(-11, 167, 2021.5, 86),1);

            Assert.Equal(17152.6, magModel.GetHorizontalIntensity(-66, -5, 2022.0, 37),1);
            Assert.Equal(4703.2, magModel.GetHorizontalIntensity(72, -115, 2022.0, 67),1);
            Assert.Equal(28859.7, magModel.GetHorizontalIntensity(22, 174, 2022.0, 44),1);
            Assert.Equal(20631.2, magModel.GetHorizontalIntensity(54, 178, 2022.0, 54),1);
            Assert.Equal(16769.3, magModel.GetHorizontalIntensity(-43, 50, 2022.0, 57),1);
            Assert.Equal(22656.4, magModel.GetHorizontalIntensity(-43, -111, 2022.0, 44),1);
            Assert.Equal(11577.2, magModel.GetHorizontalIntensity(-63, 178, 2022.0, 12),1);
            Assert.Equal(26202.3, magModel.GetHorizontalIntensity(27, -169, 2022.0, 38),1);
            Assert.Equal(10595.8, magModel.GetHorizontalIntensity(59, -77, 2022.0, 61),1);
            Assert.Equal(13056.5, magModel.GetHorizontalIntensity(-47, -32, 2022.0, 67),1);

            Assert.Equal(13043.3, magModel.GetHorizontalIntensity(62, 53, 2022.5, 8),1);
            Assert.Equal(17268.3, magModel.GetHorizontalIntensity(-68, -7, 2022.5, 77),1);
            Assert.Equal(33927.0, magModel.GetHorizontalIntensity(-5, 159, 2022.5, 98),1);
            Assert.Equal(24657.0, magModel.GetHorizontalIntensity(-29, -107, 2022.5, 34),1);
            Assert.Equal(32954.8, magModel.GetHorizontalIntensity(27, 65, 2022.5, 60),1);
            Assert.Equal(13362.8, magModel.GetHorizontalIntensity(-72, 95, 2022.5, 73),1);
            Assert.Equal(20165.1, magModel.GetHorizontalIntensity(-46, -85, 2022.5, 96),1);
            Assert.Equal(22751.7, magModel.GetHorizontalIntensity(-13, -59, 2022.5, 0),1);
            Assert.Equal(13812.2, magModel.GetHorizontalIntensity(66, -178, 2022.5, 16),1);
            Assert.Equal(16666.4, magModel.GetHorizontalIntensity(-87, 38, 2022.5, 72),1);

            Assert.Equal(30223.6, magModel.GetHorizontalIntensity(20, 167, 2023.0, 49),1);
            Assert.Equal(28445.5, magModel.GetHorizontalIntensity(5, -13, 2023.0, 71),1);
            Assert.Equal(36805.8, magModel.GetHorizontalIntensity(14, 65, 2023.0, 95),1);
            Assert.Equal(16888.7, magModel.GetHorizontalIntensity(-85, -79, 2023.0, 86),1);
            Assert.Equal(17735.3, magModel.GetHorizontalIntensity(-36, -64, 2023.0, 30),1);
            Assert.Equal(2692.1, magModel.GetHorizontalIntensity(79, 125, 2023.0, 75),1);
            Assert.Equal(28634.3, magModel.GetHorizontalIntensity(6, -32, 2023.0, 21),1);
            Assert.Equal(19700.9, magModel.GetHorizontalIntensity(-76, -75, 2023.0, 1),1);
            Assert.Equal(14187.4, magModel.GetHorizontalIntensity(-46, -41, 2023.0, 45),1);
            Assert.Equal(13972.9, magModel.GetHorizontalIntensity(-22, -21, 2023.0, 11),1);

            Assert.Equal(15158.8, magModel.GetHorizontalIntensity(54, -120, 2023.5, 28),1);
            Assert.Equal(9223.1, magModel.GetHorizontalIntensity(-58, 156, 2023.5, 68),1);
            Assert.Equal(20783.0, magModel.GetHorizontalIntensity(-65, -88, 2023.5, 39),1);
            Assert.Equal(25568.2, magModel.GetHorizontalIntensity(-23, 81, 2023.5, 27),1);
            Assert.Equal(29038.8, magModel.GetHorizontalIntensity(34, 0, 2023.5, 11),1);
            Assert.Equal(17485.0, magModel.GetHorizontalIntensity(-62, 65, 2023.5, 72),1);
            Assert.Equal(2424.9, magModel.GetHorizontalIntensity(86, 70, 2023.5, 55),1);
            Assert.Equal(28170.6, magModel.GetHorizontalIntensity(32, 163, 2023.5, 59),1);
            Assert.Equal(23673.8, magModel.GetHorizontalIntensity(48, 148, 2023.5, 65),1);
            Assert.Equal(29754.7, magModel.GetHorizontalIntensity(30, 28, 2023.5, 95),1);

            Assert.Equal(18317.9, magModel.GetHorizontalIntensity(-60, -59, 2024.0, 95),1);
            Assert.Equal(18188.3, magModel.GetHorizontalIntensity(-70, 42, 2024.0, 95),1);
            Assert.Equal(597.9, magModel.GetHorizontalIntensity(87, -154, 2024.0, 50),1);
            Assert.Equal(29401.0, magModel.GetHorizontalIntensity(32, 19, 2024.0, 58),1);
            Assert.Equal(28188.3, magModel.GetHorizontalIntensity(34, -13, 2024.0, 57),1);
            Assert.Equal(18425.8, magModel.GetHorizontalIntensity(-76, 49, 2024.0, 38),1);
            Assert.Equal(18112.2, magModel.GetHorizontalIntensity(-50, -179, 2024.0, 49),1);
            Assert.Equal(16409.7, magModel.GetHorizontalIntensity(-55, -171, 2024.0, 90),1);
            Assert.Equal(24410.2, magModel.GetHorizontalIntensity(42, -19, 2024.0, 41),1);
            Assert.Equal(22534.0, magModel.GetHorizontalIntensity(46, -22, 2024.0, 19),1);

            Assert.Equal(28413.4, magModel.GetHorizontalIntensity(13, -132, 2024.5, 31),1);
            Assert.Equal(34124.3, magModel.GetHorizontalIntensity(-2, 158, 2024.5, 93),1);
            Assert.Equal(18529.2, magModel.GetHorizontalIntensity(-76, 40, 2024.5, 51),1);
            Assert.Equal(26250.1, magModel.GetHorizontalIntensity(22, -132, 2024.5, 64),1);
            Assert.Equal(18702.1, magModel.GetHorizontalIntensity(-65, 55, 2024.5, 26),1);
            Assert.Equal(15940.8, magModel.GetHorizontalIntensity(-21, 32, 2024.5, 66),1);
            Assert.Equal(31031.6, magModel.GetHorizontalIntensity(9, -172, 2024.5, 18),1);
            Assert.Equal(2523.6, magModel.GetHorizontalIntensity(88, 26, 2024.5, 63),1);
            Assert.Equal(34062.9, magModel.GetHorizontalIntensity(17, 5, 2024.5, 33),1);
            Assert.Equal(31825.9, magModel.GetHorizontalIntensity(-18, 138, 2024.5, 77),1);
        }
        /**
		 * Test method for d3.env.TSAGeoMag.getNorthIntensity() in nT
		 */
        [Fact]
        public void
            GetNorthIntensity()
        {
            Assert.Equal(-575.7, magModel.GetNorthIntensity(89, -121, 2020.0, 28),1);
            Assert.Equal(1518.0, magModel.GetNorthIntensity(80, -96, 2020.0, 48),1);
            Assert.Equal(1555.6, magModel.GetNorthIntensity(82, 87, 2020.0, 54),1);
            Assert.Equal(24375.3, magModel.GetNorthIntensity(43, 93, 2020.0, 65),1);
            Assert.Equal(21556.3, magModel.GetNorthIntensity(-33, 109, 2020.0, 51),1);
            Assert.Equal(14369.9, magModel.GetNorthIntensity(-59, -8, 2020.0, 39),1);
            Assert.Equal(19684.4, magModel.GetNorthIntensity(-50, -103, 2020.0, 3),1);
            Assert.Equal(23467.8, magModel.GetNorthIntensity(-29, -110, 2020.0, 94),1);
            Assert.Equal(34916.8, magModel.GetNorthIntensity(14, 143, 2020.0, 66),1);
            Assert.Equal(29311.2, magModel.GetNorthIntensity(0, 21, 2020.0, 18),1);

            Assert.Equal(23948.6, magModel.GetNorthIntensity(-36, -137, 2020.5, 6),1);
            Assert.Equal(34737.7, magModel.GetNorthIntensity(26, 81, 2020.5, 63),1);
            Assert.Equal(22647.3, magModel.GetNorthIntensity(38, -144, 2020.5, 69),1);
            Assert.Equal(8943.1, magModel.GetNorthIntensity(-70, -133, 2020.5, 50),1);
            Assert.Equal(19571.7, magModel.GetNorthIntensity(-52, -75, 2020.5, 8),1);
            Assert.Equal(15247.0, magModel.GetNorthIntensity(-66, 17, 2020.5, 8),1);
            Assert.Equal(21429.0, magModel.GetNorthIntensity(-37, 140, 2020.5, 22),1);
            Assert.Equal(28773.9, magModel.GetNorthIntensity(-12, -129, 2020.5, 40),1);
            Assert.Equal(23414.3, magModel.GetNorthIntensity(33, -118, 2020.5, 44),1);
            Assert.Equal(16087.9, magModel.GetNorthIntensity(-81, -67, 2020.5, 50),1);

            Assert.Equal(13228.0, magModel.GetNorthIntensity(-57, 3, 2021.0, 74),1);
            Assert.Equal(26037.0, magModel.GetNorthIntensity(-24, -122, 2021.0, 46),1);
            Assert.Equal(34450.4, magModel.GetNorthIntensity(23, 63, 2021.0, 69),1);
            Assert.Equal(30690.1, magModel.GetNorthIntensity(-3, -147, 2021.0, 33),1);
            Assert.Equal(18352.8, magModel.GetNorthIntensity(-72, -22, 2021.0, 47),1);
            Assert.Equal(33213.0, magModel.GetNorthIntensity(-14, 99, 2021.0, 62),1);
            Assert.Equal(2408.8, magModel.GetNorthIntensity(86, -46, 2021.0, 83),1);
            Assert.Equal(2249.5, magModel.GetNorthIntensity(-64, 87, 2021.0, 82),1);
            Assert.Equal(19327.6, magModel.GetNorthIntensity(-19, 43, 2021.0, 34),1);
            Assert.Equal(9198.0, magModel.GetNorthIntensity(-81, 40, 2021.0, 56),1);

            Assert.Equal(39246.6, magModel.GetNorthIntensity(0, 80, 2021.5, 14),1);
            Assert.Equal(15995.1, magModel.GetNorthIntensity(-82, -68, 2021.5, 12),1);
            Assert.Equal(14159.0, magModel.GetNorthIntensity(-46, -42, 2021.5, 44),1);
            Assert.Equal(35896.1, magModel.GetNorthIntensity(17, 52, 2021.5, 43),1);
            Assert.Equal(39294.0, magModel.GetNorthIntensity(10, 78, 2021.5, 64),1);
            Assert.Equal(24301.2, magModel.GetNorthIntensity(33, -145, 2021.5, 12),1);
            Assert.Equal(-9403.6, magModel.GetNorthIntensity(-79, 115, 2021.5, 12),1);
            Assert.Equal(23592.3, magModel.GetNorthIntensity(-33, -114, 2021.5, 14),1);
            Assert.Equal(32618.0, magModel.GetNorthIntensity(29, 66, 2021.5, 19),1);
            Assert.Equal(32676.0, magModel.GetNorthIntensity(-11, 167, 2021.5, 86),1);

            Assert.Equal(16404.3, magModel.GetNorthIntensity(-66, -5, 2022.0, 37),1);
            Assert.Equal(4532.7, magModel.GetNorthIntensity(72, -115, 2022.0, 67),1);
            Assert.Equal(28671.0, magModel.GetNorthIntensity(22, 174, 2022.0, 44),1);
            Assert.Equal(20624.8, magModel.GetNorthIntensity(54, 178, 2022.0, 54),1);
            Assert.Equal(11344.6, magModel.GetNorthIntensity(-43, 50, 2022.0, 57),1);
            Assert.Equal(20646.1, magModel.GetNorthIntensity(-43, -111, 2022.0, 44),1);
            Assert.Equal(6292.0, magModel.GetNorthIntensity(-63, 178, 2022.0, 12),1);
            Assert.Equal(25896.5, magModel.GetNorthIntensity(27, -169, 2022.0, 38),1);
            Assert.Equal(10098.3, magModel.GetNorthIntensity(59, -77, 2022.0, 61),1);
            Assert.Equal(12663.7, magModel.GetNorthIntensity(-47, -32, 2022.0, 67),1);

            Assert.Equal(12336.1, magModel.GetNorthIntensity(62, 53, 2022.5, 8),1);
            Assert.Equal(16604.7, magModel.GetNorthIntensity(-68, -7, 2022.5, 77),1);
            Assert.Equal(33613.6, magModel.GetNorthIntensity(-5, 159, 2022.5, 98),1);
            Assert.Equal(23739.9, magModel.GetNorthIntensity(-29, -107, 2022.5, 34),1);
            Assert.Equal(32938.8, magModel.GetNorthIntensity(27, 65, 2022.5, 60),1);
            Assert.Equal(-2661.0, magModel.GetNorthIntensity(-72, 95, 2022.5, 73),1);
            Assert.Equal(19136.4, magModel.GetNorthIntensity(-46, -85, 2022.5, 96),1);
            Assert.Equal(21797.3, magModel.GetNorthIntensity(-13, -59, 2022.5, 0),1);
            Assert.Equal(13804.5, magModel.GetNorthIntensity(66, -178, 2022.5, 16),1);
            Assert.Equal(7132.3, magModel.GetNorthIntensity(-87, 38, 2022.5, 72),1);

            Assert.Equal(30099.4, magModel.GetNorthIntensity(20, 167, 2023.0, 49),1);
            Assert.Equal(28217.7, magModel.GetNorthIntensity(5, -13, 2023.0, 71),1);
            Assert.Equal(36804.1, magModel.GetNorthIntensity(14, 65, 2023.0, 95),1);
            Assert.Equal(12598.0, magModel.GetNorthIntensity(-85, -79, 2023.0, 86),1);
            Assert.Equal(17694.8, magModel.GetNorthIntensity(-36, -64, 2023.0, 30),1);
            Assert.Equal(2605.8, magModel.GetNorthIntensity(79, 125, 2023.0, 75),1);
            Assert.Equal(27630.5, magModel.GetNorthIntensity(6, -32, 2023.0, 21),1);
            Assert.Equal(16998.9, magModel.GetNorthIntensity(-76, -75, 2023.0, 1),1);
            Assert.Equal(13880.3, magModel.GetNorthIntensity(-46, -41, 2023.0, 45),1);
            Assert.Equal(12752.8, magModel.GetNorthIntensity(-22, -21, 2023.0, 11),1);

            Assert.Equal(14556.6, magModel.GetNorthIntensity(54, -120, 2023.5, 28),1);
            Assert.Equal(7015.1, magModel.GetNorthIntensity(-58, 156, 2023.5, 68),1);
            Assert.Equal(18024.0, magModel.GetNorthIntensity(-65, -88, 2023.5, 39),1);
            Assert.Equal(24811.0, magModel.GetNorthIntensity(-23, 81, 2023.5, 27),1);
            Assert.Equal(29033.7, magModel.GetNorthIntensity(34, 0, 2023.5, 11),1);
            Assert.Equal(6836.8, magModel.GetNorthIntensity(-62, 65, 2023.5, 72),1);
            Assert.Equal(1168.7, magModel.GetNorthIntensity(86, 70, 2023.5, 55),1);
            Assert.Equal(28170.0, magModel.GetNorthIntensity(32, 163, 2023.5, 59),1);
            Assert.Equal(23356.8, magModel.GetNorthIntensity(48, 148, 2023.5, 65),1);
            Assert.Equal(29663.3, magModel.GetNorthIntensity(30, 28, 2023.5, 95),1);

            Assert.Equal(18099.3, magModel.GetNorthIntensity(-60, -59, 2024.0, 95),1);
            Assert.Equal(10615.3, magModel.GetNorthIntensity(-70, 42, 2024.0, 95),1);
            Assert.Equal(80.9, magModel.GetNorthIntensity(87, -154, 2024.0, 50),1);
            Assert.Equal(29331.6, magModel.GetNorthIntensity(32, 19, 2024.0, 58),1);
            Assert.Equal(28158.7, magModel.GetNorthIntensity(34, -13, 2024.0, 57),1);
            Assert.Equal(8218.0, magModel.GetNorthIntensity(-76, 49, 2024.0, 38),1);
            Assert.Equal(15431.4, magModel.GetNorthIntensity(-50, -179, 2024.0, 49),1);
            Assert.Equal(12918.7, magModel.GetNorthIntensity(-55, -171, 2024.0, 90),1);
            Assert.Equal(24317.3, magModel.GetNorthIntensity(42, -19, 2024.0, 41),1);
            Assert.Equal(22384.7, magModel.GetNorthIntensity(46, -22, 2024.0, 19),1);

            Assert.Equal(28046.9, magModel.GetNorthIntensity(13, -132, 2024.5, 31),1);
            Assert.Equal(33858.1, magModel.GetNorthIntensity(-2, 158, 2024.5, 93),1);
            Assert.Equal(10459.6, magModel.GetNorthIntensity(-76, 40, 2024.5, 51),1);
            Assert.Equal(25808.9, magModel.GetNorthIntensity(22, -132, 2024.5, 64),1);
            Assert.Equal(8607.6, magModel.GetNorthIntensity(-65, 55, 2024.5, 26),1);
            Assert.Equal(15510.7, magModel.GetNorthIntensity(-21, 32, 2024.5, 66),1);
            Assert.Equal(30615.4, magModel.GetNorthIntensity(9, -172, 2024.5, 18),1);
            Assert.Equal(2189.6, magModel.GetNorthIntensity(88, 26, 2024.5, 63),1);
            Assert.Equal(34060.9, magModel.GetNorthIntensity(17, 5, 2024.5, 33),1);
            Assert.Equal(31722.0, magModel.GetNorthIntensity(-18, 138, 2024.5, 77),1);
        }
        /**
		 * Test method for d3.env.TSAGeoMag.getEastIntensity() in nT
		 */
        [Fact]
        public void GetEastIntensity()
        {
            Assert.Equal(-1396.0, magModel.GetEastIntensity(89, -121, 2020.0, 28),1);
            Assert.Equal(-1160.5, magModel.GetEastIntensity(80, -96, 2020.0, 48),1);
            Assert.Equal(1941.4, magModel.GetEastIntensity(82, 87, 2020.0, 54),1);
            Assert.Equal(303.2, magModel.GetEastIntensity(43, 93, 2020.0, 65),1);
            Assert.Equal(-2183.2, magModel.GetEastIntensity(-33, 109, 2020.0, 51),1);
            Assert.Equal(-4063.3, magModel.GetEastIntensity(-59, -8, 2020.0, 39),1);
            Assert.Equal(10512.2, magModel.GetEastIntensity(-50, -103, 2020.0, 3),1);
            Assert.Equal(6650.9, magModel.GetEastIntensity(-29, -110, 2020.0, 94),1);
            Assert.Equal(70.2, magModel.GetEastIntensity(14, 143, 2020.0, 66),1);
            Assert.Equal(536.0, magModel.GetEastIntensity(0, 21, 2020.0, 18),1);

            Assert.Equal(8791.9, magModel.GetEastIntensity(-36, -137, 2020.5, 6),1);
            Assert.Equal(259.2, magModel.GetEastIntensity(26, 81, 2020.5, 63),1);
            Assert.Equal(5390.0, magModel.GetEastIntensity(38, -144, 2020.5, 69),1);
            Assert.Equal(13981.7, magModel.GetEastIntensity(-70, -133, 2020.5, 50),1);
            Assert.Equal(5387.5, magModel.GetEastIntensity(-52, -75, 2020.5, 8),1);
            Assert.Equal(-9734.8, magModel.GetEastIntensity(-66, 17, 2020.5, 8),1);
            Assert.Equal(3451.3, magModel.GetEastIntensity(-37, 140, 2020.5, 22),1);
            Assert.Equal(5503.9, magModel.GetEastIntensity(-12, -129, 2020.5, 40),1);
            Assert.Equal(4748.3, magModel.GetEastIntensity(33, -118, 2020.5, 44),1);
            Assert.Equal(8788.9, magModel.GetEastIntensity(-81, -67, 2020.5, 50),1);

            Assert.Equal(-5423.3, magModel.GetEastIntensity(-57, 3, 2021.0, 74),1);
            Assert.Equal(6501.8, magModel.GetEastIntensity(-24, -122, 2021.0, 46),1);
            Assert.Equal(646.9, magModel.GetEastIntensity(23, 63, 2021.0, 69),1);
            Assert.Equal(5265.7, magModel.GetEastIntensity(-3, -147, 2021.0, 33),1);
            Assert.Equal(-1946.6, magModel.GetEastIntensity(-72, -22, 2021.0, 47),1);
            Assert.Equal(-990.3, magModel.GetEastIntensity(-14, 99, 2021.0, 62),1);
            Assert.Equal(-1796.2, magModel.GetEastIntensity(86, -46, 2021.0, 83),1);
            Assert.Equal(-13907.0, magModel.GetEastIntensity(-64, 87, 2021.0, 82),1);
            Assert.Equal(-4933.5, magModel.GetEastIntensity(-19, 43, 2021.0, 34),1);
            Assert.Equal(-15323.4, magModel.GetEastIntensity(-81, 40, 2021.0, 56),1);

            Assert.Equal(-2338.9, magModel.GetEastIntensity(0, 80, 2021.5, 14),1);
            Assert.Equal(9368.5, magModel.GetEastIntensity(-82, -68, 2021.5, 12),1);
            Assert.Equal(-2889.8, magModel.GetEastIntensity(-46, -42, 2021.5, 44),1);
            Assert.Equal(773.7, magModel.GetEastIntensity(17, 52, 2021.5, 43),1);
            Assert.Equal(-1172.2, magModel.GetEastIntensity(10, 78, 2021.5, 64),1);
            Assert.Equal(5327.4, magModel.GetEastIntensity(33, -145, 2021.5, 12),1);
            Assert.Equal(-8972.3, magModel.GetEastIntensity(-79, 115, 2021.5, 12),1);
            Assert.Equal(7712.3, magModel.GetEastIntensity(-33, -114, 2021.5, 14),1);
            Assert.Equal(1215.2, magModel.GetEastIntensity(29, 66, 2021.5, 19),1);
            Assert.Equal(5828.1, magModel.GetEastIntensity(-11, 167, 2021.5, 86),1);

            Assert.Equal(-5011.2, magModel.GetEastIntensity(-66, -5, 2022.0, 37),1);
            Assert.Equal(1254.7, magModel.GetEastIntensity(72, -115, 2022.0, 67),1);
            Assert.Equal(3294.9, magModel.GetEastIntensity(22, 174, 2022.0, 44),1);
            Assert.Equal(514.8, magModel.GetEastIntensity(54, 178, 2022.0, 54),1);
            Assert.Equal(-12349.5, magModel.GetEastIntensity(-43, 50, 2022.0, 57),1);
            Assert.Equal(9330.1, magModel.GetEastIntensity(-43, -111, 2022.0, 44),1);
            Assert.Equal(9718.1, magModel.GetEastIntensity(-63, 178, 2022.0, 12),1);
            Assert.Equal(3991.3, magModel.GetEastIntensity(27, -169, 2022.0, 38),1);
            Assert.Equal(-3208.9, magModel.GetEastIntensity(59, -77, 2022.0, 61),1);
            Assert.Equal(-3178.2, magModel.GetEastIntensity(-47, -32, 2022.0, 67),1);

            Assert.Equal(4236.6, magModel.GetEastIntensity(62, 53, 2022.5, 8),1);
            Assert.Equal(-4741.2, magModel.GetEastIntensity(-68, -7, 2022.5, 77),1);
            Assert.Equal(4601.1, magModel.GetEastIntensity(-5, 159, 2022.5, 98),1);
            Assert.Equal(6662.3, magModel.GetEastIntensity(-29, -107, 2022.5, 34),1);
            Assert.Equal(1025.8, magModel.GetEastIntensity(27, 65, 2022.5, 60),1);
            Assert.Equal(-13095.2, magModel.GetEastIntensity(-72, 95, 2022.5, 73),1);
            Assert.Equal(6358.2, magModel.GetEastIntensity(-46, -85, 2022.5, 96),1);
            Assert.Equal(-6520.6, magModel.GetEastIntensity(-13, -59, 2022.5, 0),1);
            Assert.Equal(463.2, magModel.GetEastIntensity(66, -178, 2022.5, 16),1);
            Assert.Equal(-15063.2, magModel.GetEastIntensity(-87, 38, 2022.5, 72),1);

            Assert.Equal(2737.4, magModel.GetEastIntensity(20, 167, 2023.0, 49),1);
            Assert.Equal(-3592.6, magModel.GetEastIntensity(5, -13, 2023.0, 71),1);
            Assert.Equal(-356.8, magModel.GetEastIntensity(14, 65, 2023.0, 95),1);
            Assert.Equal(11248.0, magModel.GetEastIntensity(-85, -79, 2023.0, 86),1);
            Assert.Equal(-1198.1, magModel.GetEastIntensity(-36, -64, 2023.0, 30),1);
            Assert.Equal(-676.0, magModel.GetEastIntensity(79, 125, 2023.0, 75),1);
            Assert.Equal(-7515.0, magModel.GetEastIntensity(6, -32, 2023.0, 21),1);
            Assert.Equal(9958.1, magModel.GetEastIntensity(-76, -75, 2023.0, 1),1);
            Assert.Equal(-2936.1, magModel.GetEastIntensity(-46, -41, 2023.0, 45),1);
            Assert.Equal(-5710.4, magModel.GetEastIntensity(-22, -21, 2023.0, 11),1);

            Assert.Equal(4230.3, magModel.GetEastIntensity(54, -120, 2023.5, 28),1);
            Assert.Equal(5987.8, magModel.GetEastIntensity(-58, 156, 2023.5, 68),1);
            Assert.Equal(10347.2, magModel.GetEastIntensity(-65, -88, 2023.5, 39),1);
            Assert.Equal(-6176.1, magModel.GetEastIntensity(-23, 81, 2023.5, 27),1);
            Assert.Equal(545.3, magModel.GetEastIntensity(34, 0, 2023.5, 11),1);
            Assert.Equal(-16092.9, magModel.GetEastIntensity(-62, 65, 2023.5, 72),1);
            Assert.Equal(2124.7, magModel.GetEastIntensity(86, 70, 2023.5, 55),1);
            Assert.Equal(176.0, magModel.GetEastIntensity(32, 163, 2023.5, 59),1);
            Assert.Equal(-3861.2, magModel.GetEastIntensity(48, 148, 2023.5, 65),1);
            Assert.Equal(2331.2, magModel.GetEastIntensity(30, 28, 2023.5, 95),1);

            Assert.Equal(2821.2, magModel.GetEastIntensity(-60, -59, 2024.0, 95),1);
            Assert.Equal(-14769.3, magModel.GetEastIntensity(-70, 42, 2024.0, 95),1);
            Assert.Equal(-592.4, magModel.GetEastIntensity(87, -154, 2024.0, 50),1);
            Assert.Equal(2019.5, magModel.GetEastIntensity(32, 19, 2024.0, 58),1);
            Assert.Equal(-1290.8, magModel.GetEastIntensity(34, -13, 2024.0, 57),1);
            Assert.Equal(-16491.7, magModel.GetEastIntensity(-76, 49, 2024.0, 38),1);
            Assert.Equal(9482.7, magModel.GetEastIntensity(-50, -179, 2024.0, 49),1);
            Assert.Equal(10118.6, magModel.GetEastIntensity(-55, -171, 2024.0, 90),1);
            Assert.Equal(-2127.0, magModel.GetEastIntensity(42, -19, 2024.0, 41),1);
            Assert.Equal(-2590.4, magModel.GetEastIntensity(46, -22, 2024.0, 19),1);

            Assert.Equal(4548.8, magModel.GetEastIntensity(13, -132, 2024.5, 31),1);
            Assert.Equal(4253.5, magModel.GetEastIntensity(-2, 158, 2024.5, 93),1);
            Assert.Equal(-15294.7, magModel.GetEastIntensity(-76, 40, 2024.5, 51),1);
            Assert.Equal(4792.5, magModel.GetEastIntensity(22, -132, 2024.5, 64),1);
            Assert.Equal(-16603.5, magModel.GetEastIntensity(-65, 55, 2024.5, 26),1);
            Assert.Equal(-3677.9, magModel.GetEastIntensity(-21, 32, 2024.5, 66),1);
            Assert.Equal(5065.5, magModel.GetEastIntensity(9, -172, 2024.5, 18),1);
            Assert.Equal(1254.6, magModel.GetEastIntensity(88, 26, 2024.5, 63),1);
            Assert.Equal(362.9, magModel.GetEastIntensity(17, 5, 2024.5, 33),1);
            Assert.Equal(2569.6, magModel.GetEastIntensity(-18, 138, 2024.5, 77),1);
        }
        /**
		 * Test method for d3.env.TSAGeoMag.getVerticalIntensity()
		 */
        [Fact]
        public void GetVerticalIntensity()
        {


            Assert.Equal(56082.3, magModel.GetVerticalIntensity(89, -121, 2020.0, 28),1);
            Assert.Equal(55671.9, magModel.GetVerticalIntensity(80, -96, 2020.0, 48),1);
            Assert.Equal(56520.5, magModel.GetVerticalIntensity(82, 87, 2020.0, 54),1);
            Assert.Equal(49691.4, magModel.GetVerticalIntensity(43, 93, 2020.0, 65),1);
            Assert.Equal(-52676.0, magModel.GetVerticalIntensity(-33, 109, 2020.0, 51),1);
            Assert.Equal(-24679.0, magModel.GetVerticalIntensity(-59, -8, 2020.0, 39),1);
            Assert.Equal(-31883.6, magModel.GetVerticalIntensity(-50, -103, 2020.0, 3),1);
            Assert.Equal(-19320.7, magModel.GetVerticalIntensity(-29, -110, 2020.0, 94),1);
            Assert.Equal(8114.9, magModel.GetVerticalIntensity(14, 143, 2020.0, 66),1);
            Assert.Equal(-14589.0, magModel.GetVerticalIntensity(0, 21, 2020.0, 18),1);

            Assert.Equal(-32897.6, magModel.GetVerticalIntensity(-36, -137, 2020.5, 6),1);
            Assert.Equal(30023.4, magModel.GetVerticalIntensity(26, 81, 2020.5, 63),1);
            Assert.Equal(35831.9, magModel.GetVerticalIntensity(38, -144, 2020.5, 69),1);
            Assert.Equal(-51628.5, magModel.GetVerticalIntensity(-70, -133, 2020.5, 50),1);
            Assert.Equal(-23769.0, magModel.GetVerticalIntensity(-52, -75, 2020.5, 8),1);
            Assert.Equal(-31062.0, magModel.GetVerticalIntensity(-66, 17, 2020.5, 8),1);
            Assert.Equal(-55415.6, magModel.GetVerticalIntensity(-37, 140, 2020.5, 22),1);
            Assert.Equal(-8221.8, magModel.GetVerticalIntensity(-12, -129, 2020.5, 40),1);
            Assert.Equal(38184.5, magModel.GetVerticalIntensity(33, -118, 2020.5, 44),1);
            Assert.Equal(-44780.8, magModel.GetVerticalIntensity(-81, -67, 2020.5, 50),1);

            Assert.Equal(-23859.2, magModel.GetVerticalIntensity(-57, 3, 2021.0, 74),1);
            Assert.Equal(-18297.4, magModel.GetVerticalIntensity(-24, -122, 2021.0, 46),1);
            Assert.Equal(24869.2, magModel.GetVerticalIntensity(23, 63, 2021.0, 69),1);
            Assert.Equal(-1277.4, magModel.GetVerticalIntensity(-3, -147, 2021.0, 33),1);
            Assert.Equal(-33665.0, magModel.GetVerticalIntensity(-72, -22, 2021.0, 47),1);
            Assert.Equal(-33354.0, magModel.GetVerticalIntensity(-14, 99, 2021.0, 62),1);
            Assert.Equal(54184.7, magModel.GetVerticalIntensity(86, -46, 2021.0, 83),1);
            Assert.Equal(-53526.9, magModel.GetVerticalIntensity(-64, 87, 2021.0, 82),1);
            Assert.Equal(-25969.5, magModel.GetVerticalIntensity(-19, 43, 2021.0, 34),1);
            Assert.Equal(-45453.8, magModel.GetVerticalIntensity(-81, 40, 2021.0, 56),1);

            Assert.Equal(-12258.0, magModel.GetVerticalIntensity(0, 80, 2021.5, 14),1);
            Assert.Equal(-46308.7, magModel.GetVerticalIntensity(-82, -68, 2021.5, 12),1);
            Assert.Equal(-19762.2, magModel.GetVerticalIntensity(-46, -42, 2021.5, 44),1);
            Assert.Equal(15885.6, magModel.GetVerticalIntensity(17, 52, 2021.5, 43),1);
            Assert.Equal(5088.1, magModel.GetVerticalIntensity(10, 78, 2021.5, 64),1);
            Assert.Equal(32429.3, magModel.GetVerticalIntensity(33, -145, 2021.5, 12),1);
            Assert.Equal(-58271.0, magModel.GetVerticalIntensity(-79, 115, 2021.5, 12),1);
            Assert.Equal(-24163.1, magModel.GetVerticalIntensity(-33, -114, 2021.5, 14),1);
            Assert.Equal(33763.7, magModel.GetVerticalIntensity(29, 66, 2021.5, 19),1);
            Assert.Equal(-20299.1, magModel.GetVerticalIntensity(-11, 167, 2021.5, 86),1);

            Assert.Equal(-28849.5, magModel.GetVerticalIntensity(-66, -5, 2022.0, 37),1);
            Assert.Equal(55923.4, magModel.GetVerticalIntensity(72, -115, 2022.0, 67),1);
            Assert.Equal(17967.2, magModel.GetVerticalIntensity(22, 174, 2022.0, 44),1);
            Assert.Equal(45076.8, magModel.GetVerticalIntensity(54, 178, 2022.0, 54),1);
            Assert.Equal(-32850.3, magModel.GetVerticalIntensity(-43, 50, 2022.0, 57),1);
            Assert.Equal(-29747.5, magModel.GetVerticalIntensity(-43, -111, 2022.0, 44),1);
            Assert.Equal(-61429.1, magModel.GetVerticalIntensity(-63, 178, 2022.0, 12),1);
            Assert.Equal(24097.4, magModel.GetVerticalIntensity(27, -169, 2022.0, 38),1);
            Assert.Equal(54735.3, magModel.GetVerticalIntensity(59, -77, 2022.0, 61),1);
            Assert.Equal(-20600.9, magModel.GetVerticalIntensity(-47, -32, 2022.0, 67),1);

            Assert.Equal(54498.1, magModel.GetVerticalIntensity(62, 53, 2022.5, 8),1);
            Assert.Equal(-29908.6, magModel.GetVerticalIntensity(-68, -7, 2022.5, 77),1);
            Assert.Equal(-14426.9, magModel.GetVerticalIntensity(-5, 159, 2022.5, 98),1);
            Assert.Equal(-19023.5, magModel.GetVerticalIntensity(-29, -107, 2022.5, 34),1);
            Assert.Equal(30561.3, magModel.GetVerticalIntensity(27, 65, 2022.5, 60),1);
            Assert.Equal(-55423.4, magModel.GetVerticalIntensity(-72, 95, 2022.5, 73),1);
            Assert.Equal(-21915.4, magModel.GetVerticalIntensity(-46, -85, 2022.5, 96),1);
            Assert.Equal(-5425.9, magModel.GetVerticalIntensity(-13, -59, 2022.5, 0),1);
            Assert.Equal(54055.4, magModel.GetVerticalIntensity(66, -178, 2022.5, 16),1);
            Assert.Equal(-48550.5, magModel.GetVerticalIntensity(-87, 38, 2022.5, 72),1);

            Assert.Equal(15301.2, magModel.GetVerticalIntensity(20, 167, 2023.0, 49),1);
            Assert.Equal(-8905.8, magModel.GetVerticalIntensity(5, -13, 2023.0, 71),1);
            Assert.Equal(11616.0, magModel.GetVerticalIntensity(14, 65, 2023.0, 95),1);
            Assert.Equal(-47331.2, magModel.GetVerticalIntensity(-85, -79, 2023.0, 86),1);
            Assert.Equal(-14566.5, magModel.GetVerticalIntensity(-36, -64, 2023.0, 30),1);
            Assert.Equal(57085.9, magModel.GetVerticalIntensity(79, 125, 2023.0, 75),1);
            Assert.Equal(-3646.9, magModel.GetVerticalIntensity(6, -32, 2023.0, 21),1);
            Assert.Equal(-42873.8, magModel.GetVerticalIntensity(-76, -75, 2023.0, 1),1);
            Assert.Equal(-19853.0, magModel.GetVerticalIntensity(-46, -41, 2023.0, 45),1);
            Assert.Equal(-21372.4, magModel.GetVerticalIntensity(-22, -21, 2023.0, 11),1);

            Assert.Equal(52945.6, magModel.GetVerticalIntensity(54, -120, 2023.5, 28),1);
            Assert.Equal(-62459.5, magModel.GetVerticalIntensity(-58, 156, 2023.5, 68),1);
            Assert.Equal(-36415.6, magModel.GetVerticalIntensity(-65, -88, 2023.5, 39),1);
            Assert.Equal(-41759.2, magModel.GetVerticalIntensity(-23, 81, 2023.5, 27),1);
            Assert.Equal(30807.0, magModel.GetVerticalIntensity(34, 0, 2023.5, 11),1);
            Assert.Equal(-44111.8, magModel.GetVerticalIntensity(-62, 65, 2023.5, 72),1);
            Assert.Equal(55750.6, magModel.GetVerticalIntensity(86, 70, 2023.5, 55),1);
            Assert.Equal(26318.3, magModel.GetVerticalIntensity(32, 163, 2023.5, 59),1);
            Assert.Equal(43968.0, magModel.GetVerticalIntensity(48, 148, 2023.5, 65),1);
            Assert.Equal(28857.6, magModel.GetVerticalIntensity(30, 28, 2023.5, 95),1);

            Assert.Equal(-26193.2, magModel.GetVerticalIntensity(-60, -59, 2024.0, 95),1);
            Assert.Equal(-38293.4, magModel.GetVerticalIntensity(-70, 42, 2024.0, 95),1);
            Assert.Equal(55904.6, magModel.GetVerticalIntensity(87, -154, 2024.0, 50),1);
            Assert.Equal(30329.8, magModel.GetVerticalIntensity(32, 19, 2024.0, 58),1);
            Assert.Equal(29015.5, magModel.GetVerticalIntensity(34, -13, 2024.0, 57),1);
            Assert.Equal(-44260.7, magModel.GetVerticalIntensity(-76, 49, 2024.0, 38),1);
            Assert.Equal(-53818.3, magModel.GetVerticalIntensity(-50, -179, 2024.0, 49),1);
            Assert.Equal(-53373.5, magModel.GetVerticalIntensity(-55, -171, 2024.0, 90),1);
            Assert.Equal(36981.3, magModel.GetVerticalIntensity(42, -19, 2024.0, 41),1);
            Assert.Equal(40713.3, magModel.GetVerticalIntensity(46, -22, 2024.0, 19),1);

            Assert.Equal(17417.2, magModel.GetVerticalIntensity(13, -132, 2024.5, 31),1);
            Assert.Equal(-10940.3, magModel.GetVerticalIntensity(-2, 158, 2024.5, 93),1);
            Assert.Equal(-42141.5, magModel.GetVerticalIntensity(-76, 40, 2024.5, 51),1);
            Assert.Equal(25239.1, magModel.GetVerticalIntensity(22, -132, 2024.5, 64),1);
            Assert.Equal(-41366.0, magModel.GetVerticalIntensity(-65, 55, 2024.5, 26),1);
            Assert.Equal(-24502.7, magModel.GetVerticalIntensity(-21, 32, 2024.5, 66),1);
            Assert.Equal(8768.5, magModel.GetVerticalIntensity(9, -172, 2024.5, 18),1);
            Assert.Equal(55156.1, magModel.GetVerticalIntensity(88, 26, 2024.5, 63),1);
            Assert.Equal(8230.6, magModel.GetVerticalIntensity(17, 5, 2024.5, 33),1);
            Assert.Equal(-34986.2, magModel.GetVerticalIntensity(-18, 138, 2024.5, 77),1);
        }
        /**
		 * Test method for d3.env.TSAGeoMag.getIntensity()
		 */
        [Fact]
        public void GetIntensity()
        {
            Assert.Equal(56102.7, magModel.GetIntensity(89, -121, 2020.0, 28),1);
            Assert.Equal(55704.7, magModel.GetIntensity(80, -96, 2020.0, 48),1);
            Assert.Equal(56575.2, magModel.GetIntensity(82, 87, 2020.0, 54),1);
            Assert.Equal(55348.7, magModel.GetIntensity(43, 93, 2020.0, 65),1);
            Assert.Equal(56957.9, magModel.GetIntensity(-33, 109, 2020.0, 51),1);
            Assert.Equal(28845.4, magModel.GetIntensity(-59, -8, 2020.0, 39),1);
            Assert.Equal(38917.2, magModel.GetIntensity(-50, -103, 2020.0, 3),1);
            Assert.Equal(31116.9, magModel.GetIntensity(-29, -110, 2020.0, 94),1);
            Assert.Equal(35847.5, magModel.GetIntensity(14, 143, 2020.0, 66),1);
            Assert.Equal(32745.6, magModel.GetIntensity(0, 21, 2020.0, 18),1);

            Assert.Equal(41630.3, magModel.GetIntensity(-36, -137, 2020.5, 6),1);
            Assert.Equal(45914.9, magModel.GetIntensity(26, 81, 2020.5, 63),1);
            Assert.Equal(42730.3, magModel.GetIntensity(38, -144, 2020.5, 69),1);
            Assert.Equal(54230.7, magModel.GetIntensity(-70, -133, 2020.5, 50),1);
            Assert.Equal(31257.7, magModel.GetIntensity(-52, -75, 2020.5, 8),1);
            Assert.Equal(35945.6, magModel.GetIntensity(-66, 17, 2020.5, 8),1);
            Assert.Equal(59514.7, magModel.GetIntensity(-37, 140, 2020.5, 22),1);
            Assert.Equal(30427.4, magModel.GetIntensity(-12, -129, 2020.5, 40),1);
            Assert.Equal(45042.6, magModel.GetIntensity(33, -118, 2020.5, 44),1);
            Assert.Equal(48387.8, magModel.GetIntensity(-81, -67, 2020.5, 50),1);

            Assert.Equal(27814.7, magModel.GetIntensity(-57, 3, 2021.0, 74),1);
            Assert.Equal(32480.6, magModel.GetIntensity(-24, -122, 2021.0, 46),1);
            Assert.Equal(42493.9, magModel.GetIntensity(23, 63, 2021.0, 69),1);
            Assert.Equal(31164.8, magModel.GetIntensity(-3, -147, 2021.0, 33),1);
            Assert.Equal(38392.0, magModel.GetIntensity(-72, -22, 2021.0, 47),1);
            Assert.Equal(47080.5, magModel.GetIntensity(-14, 99, 2021.0, 62),1);
            Assert.Equal(54268.0, magModel.GetIntensity(86, -46, 2021.0, 83),1);
            Assert.Equal(55349.8, magModel.GetIntensity(-64, 87, 2021.0, 82),1);
            Assert.Equal(32746.2, magModel.GetIntensity(-19, 43, 2021.0, 34),1);
            Assert.Equal(48841.2, magModel.GetIntensity(-81, 40, 2021.0, 56),1);

            Assert.Equal(41182.8, magModel.GetIntensity(0, 80, 2021.5, 14),1);
            Assert.Equal(49880.9, magModel.GetIntensity(-82, -68, 2021.5, 12),1);
            Assert.Equal(24482.1, magModel.GetIntensity(-46, -42, 2021.5, 44),1);
            Assert.Equal(39261.7, magModel.GetIntensity(17, 52, 2021.5, 43),1);
            Assert.Equal(39639.4, magModel.GetIntensity(10, 78, 2021.5, 64),1);
            Assert.Equal(40872.8, magModel.GetIntensity(33, -145, 2021.5, 12),1);
            Assert.Equal(59702.9, magModel.GetIntensity(-79, 115, 2021.5, 12),1);
            Assert.Equal(34640.0, magModel.GetIntensity(-33, -114, 2021.5, 14),1);
            Assert.Equal(46961.7, magModel.GetIntensity(29, 66, 2021.5, 19),1);
            Assert.Equal(38906.8, magModel.GetIntensity(-11, 167, 2021.5, 86),1);

            Assert.Equal(33563.5, magModel.GetIntensity(-66, -5, 2022.0, 37),1);
            Assert.Equal(56120.8, magModel.GetIntensity(72, -115, 2022.0, 67),1);
            Assert.Equal(33995.6, magModel.GetIntensity(22, 174, 2022.0, 44),1);
            Assert.Equal(49573.8, magModel.GetIntensity(54, 178, 2022.0, 54),1);
            Assert.Equal(36883.0, magModel.GetIntensity(-43, 50, 2022.0, 57),1);
            Assert.Equal(37392.8, magModel.GetIntensity(-43, -111, 2022.0, 44),1);
            Assert.Equal(62510.5, magModel.GetIntensity(-63, 178, 2022.0, 12),1);
            Assert.Equal(35598.4, magModel.GetIntensity(27, -169, 2022.0, 38),1);
            Assert.Equal(55751.4, magModel.GetIntensity(59, -77, 2022.0, 61),1);
            Assert.Equal(24389.9, magModel.GetIntensity(-47, -32, 2022.0, 67),1);

            Assert.Equal(56037.2, magModel.GetIntensity(62, 53, 2022.5, 8),1);
            Assert.Equal(34535.8, magModel.GetIntensity(-68, -7, 2022.5, 77),1);
            Assert.Equal(36867.1, magModel.GetIntensity(-5, 159, 2022.5, 98),1);
            Assert.Equal(31142.6, magModel.GetIntensity(-29, -107, 2022.5, 34),1);
            Assert.Equal(44944.6, magModel.GetIntensity(27, 65, 2022.5, 60),1);
            Assert.Equal(57011.5, magModel.GetIntensity(-72, 95, 2022.5, 73),1);
            Assert.Equal(29781.1, magModel.GetIntensity(-46, -85, 2022.5, 96),1);
            Assert.Equal(23389.8, magModel.GetIntensity(-13, -59, 2022.5, 0),1);
            Assert.Equal(55792.1, magModel.GetIntensity(66, -178, 2022.5, 16),1);
            Assert.Equal(51331.5, magModel.GetIntensity(-87, 38, 2022.5, 72),1);

            Assert.Equal(33876.1, magModel.GetIntensity(20, 167, 2023.0, 49),1);
            Assert.Equal(29807.1, magModel.GetIntensity(5, -13, 2023.0, 71),1);
            Assert.Equal(38595.3, magModel.GetIntensity(14, 65, 2023.0, 95),1);
            Assert.Equal(50254.0, magModel.GetIntensity(-85, -79, 2023.0, 86),1);
            Assert.Equal(22950.5, magModel.GetIntensity(-36, -64, 2023.0, 30),1);
            Assert.Equal(57149.3, magModel.GetIntensity(79, 125, 2023.0, 75),1);
            Assert.Equal(28865.6, magModel.GetIntensity(6, -32, 2023.0, 21),1);
            Assert.Equal(47183.6, magModel.GetIntensity(-76, -75, 2023.0, 1),1);
            Assert.Equal(24401.3, magModel.GetIntensity(-46, -41, 2023.0, 45),1);
            Assert.Equal(25534.7, magModel.GetIntensity(-22, -21, 2023.0, 11),1);

            Assert.Equal(55072.9, magModel.GetIntensity(54, -120, 2023.5, 28),1);
            Assert.Equal(63136.8, magModel.GetIntensity(-58, 156, 2023.5, 68),1);
            Assert.Equal(41928.8, magModel.GetIntensity(-65, -88, 2023.5, 39),1);
            Assert.Equal(48965.0, magModel.GetIntensity(-23, 81, 2023.5, 27),1);
            Assert.Equal(42335.9, magModel.GetIntensity(34, 0, 2023.5, 11),1);
            Assert.Equal(47450.8, magModel.GetIntensity(-62, 65, 2023.5, 72),1);
            Assert.Equal(55803.4, magModel.GetIntensity(86, 70, 2023.5, 55),1);
            Assert.Equal(38551.7, magModel.GetIntensity(32, 163, 2023.5, 59),1);
            Assert.Equal(49936.3, magModel.GetIntensity(48, 148, 2023.5, 65),1);
            Assert.Equal(41450.1, magModel.GetIntensity(30, 28, 2023.5, 95),1);

            Assert.Equal(31962.9, magModel.GetIntensity(-60, -59, 2024.0, 95),1);
            Assert.Equal(42393.4, magModel.GetIntensity(-70, 42, 2024.0, 95),1);
            Assert.Equal(55907.8, magModel.GetIntensity(87, -154, 2024.0, 50),1);
            Assert.Equal(42241.2, magModel.GetIntensity(32, 19, 2024.0, 58),1);
            Assert.Equal(40453.4, magModel.GetIntensity(34, -13, 2024.0, 57),1);
            Assert.Equal(47942.9, magModel.GetIntensity(-76, 49, 2024.0, 38),1);
            Assert.Equal(56784.4, magModel.GetIntensity(-50, -179, 2024.0, 49),1);
            Assert.Equal(55839.2, magModel.GetIntensity(-55, -171, 2024.0, 90),1);
            Assert.Equal(44311.1, magModel.GetIntensity(42, -19, 2024.0, 41),1);
            Assert.Equal(46533.4, magModel.GetIntensity(46, -22, 2024.0, 19),1);

            Assert.Equal(33326.9, magModel.GetIntensity(13, -132, 2024.5, 31),1);
            Assert.Equal(35835.1, magModel.GetIntensity(-2, 158, 2024.5, 93),1);
            Assert.Equal(46035.2, magModel.GetIntensity(-76, 40, 2024.5, 51),1);
            Assert.Equal(36415.3, magModel.GetIntensity(22, -132, 2024.5, 64),1);
            Assert.Equal(45397.3, magModel.GetIntensity(-65, 55, 2024.5, 26),1);
            Assert.Equal(29231.7, magModel.GetIntensity(-21, 32, 2024.5, 66),1);
            Assert.Equal(32246.7, magModel.GetIntensity(9, -172, 2024.5, 18),1);
            Assert.Equal(55213.8, magModel.GetIntensity(88, 26, 2024.5, 63),1);
            Assert.Equal(35043.1, magModel.GetIntensity(17, 5, 2024.5, 33),1);
            Assert.Equal(47296.1, magModel.GetIntensity(-18, 138, 2024.5, 77),1);
        }

        /**
		 *  test method for {@link d3.env.TSAGeoMag#decimalYear(GregorianCalendar)}
		 */
        [Fact]
        public void DecimalYear()
        {

            var mag = new GeoMag();

            var cal = new DateTime(2010, 1, 1);
            Assert.Equal(2010.0, mag.DecimalYear(cal), 1);

            var cal2 = new DateTime(2012, 6, 1);  // the full day of July 1, 0 hours into 2 July
            Assert.True(DateTime.IsLeapYear(2012));
            Assert.Equal(2012.5, mag.DecimalYear(cal2), 0);
            cal2 = new DateTime(2013, 4, 13);
            Assert.False(DateTime.IsLeapYear(2013));
            Assert.Equal(2013.282, mag.DecimalYear(cal2), 3);
        }
    }

}
