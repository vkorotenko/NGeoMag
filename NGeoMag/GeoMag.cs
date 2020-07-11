#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  10.07.2020 21:02
#endregion

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace NGeoMag
{
    /// <summary>
    /// Geo magnetic calculator.
    /// </summary>
    public class GeoMag : IDisposable
    {
        /// <summary>
        /// The input string array which contains each line of input for the
        ///	wmm.cof input file.Added so that all data was internal, so that 
        ///	applications do not have to mess with carrying around a data file.
        /// In the TSAGeoMag Class, the columns in this file are as follows:
        /// n, m, gnm, hnm, dgnm, dhnm
        /// </summary>
        private readonly string[] _input =
        {       "   2020.0            WMM-2020        12/10/2019",
        "  1  0  -29404.5       0.0        6.7        0.0",
        "  1  1   -1450.7    4652.9        7.7      -25.1",
        "  2  0   -2500.0       0.0      -11.5        0.0",
        "  2  1    2982.0   -2991.6       -7.1      -30.2",
        "  2  2    1676.8    -734.8       -2.2      -23.9",
        "  3  0    1363.9       0.0        2.8        0.0",
        "  3  1   -2381.0     -82.2       -6.2        5.7",
        "  3  2    1236.2     241.8        3.4       -1.0",
        "  3  3     525.7    -542.9      -12.2        1.1",
        "  4  0     903.1       0.0       -1.1        0.0",
        "  4  1     809.4     282.0       -1.6        0.2",
        "  4  2      86.2    -158.4       -6.0        6.9",
        "  4  3    -309.4     199.8        5.4        3.7",
        "  4  4      47.9    -350.1       -5.5       -5.6",
        "  5  0    -234.4       0.0       -0.3        0.0",
        "  5  1     363.1      47.7        0.6        0.1",
        "  5  2     187.8     208.4       -0.7        2.5",
        "  5  3    -140.7    -121.3        0.1       -0.9",
        "  5  4    -151.2      32.2        1.2        3.0",
        "  5  5      13.7      99.1        1.0        0.5",
        "  6  0      65.9       0.0       -0.6        0.0",
        "  6  1      65.6     -19.1       -0.4        0.1",
        "  6  2      73.0      25.0        0.5       -1.8",
        "  6  3    -121.5      52.7        1.4       -1.4",
        "  6  4     -36.2     -64.4       -1.4        0.9",
        "  6  5      13.5       9.0       -0.0        0.1",
        "  6  6     -64.7      68.1        0.8        1.0",
        "  7  0      80.6       0.0       -0.1        0.0",
        "  7  1     -76.8     -51.4       -0.3        0.5",
        "  7  2      -8.3     -16.8       -0.1        0.6",
        "  7  3      56.5       2.3        0.7       -0.7",
        "  7  4      15.8      23.5        0.2       -0.2",
        "  7  5       6.4      -2.2       -0.5       -1.2",
        "  7  6      -7.2     -27.2       -0.8        0.2",
        "  7  7       9.8      -1.9        1.0        0.3",
        "  8  0      23.6       0.0       -0.1        0.0",
        "  8  1       9.8       8.4        0.1       -0.3",
        "  8  2     -17.5     -15.3       -0.1        0.7",
        "  8  3      -0.4      12.8        0.5       -0.2",
        "  8  4     -21.1     -11.8       -0.1        0.5",
        "  8  5      15.3      14.9        0.4       -0.3",
        "  8  6      13.7       3.6        0.5       -0.5",
        "  8  7     -16.5      -6.9        0.0        0.4",
        "  8  8      -0.3       2.8        0.4        0.1",
        "  9  0       5.0       0.0       -0.1        0.0",
        "  9  1       8.2     -23.3       -0.2       -0.3",
        "  9  2       2.9      11.1       -0.0        0.2",
        "  9  3      -1.4       9.8        0.4       -0.4",
        "  9  4      -1.1      -5.1       -0.3        0.4",
        "  9  5     -13.3      -6.2       -0.0        0.1",
        "  9  6       1.1       7.8        0.3       -0.0",
        "  9  7       8.9       0.4       -0.0       -0.2",
        "  9  8      -9.3      -1.5       -0.0        0.5",
        "  9  9     -11.9       9.7       -0.4        0.2",
        " 10  0      -1.9       0.0        0.0        0.0",
        " 10  1      -6.2       3.4       -0.0       -0.0",
        " 10  2      -0.1      -0.2       -0.0        0.1",
        " 10  3       1.7       3.5        0.2       -0.3",
        " 10  4      -0.9       4.8       -0.1        0.1",
        " 10  5       0.6      -8.6       -0.2       -0.2",
        " 10  6      -0.9      -0.1       -0.0        0.1",
        " 10  7       1.9      -4.2       -0.1       -0.0",
        " 10  8       1.4      -3.4       -0.2       -0.1",
        " 10  9      -2.4      -0.1       -0.1        0.2",
        " 10 10      -3.9      -8.8       -0.0       -0.0",
        " 11  0       3.0       0.0       -0.0        0.0",
        " 11  1      -1.4      -0.0       -0.1       -0.0",
        " 11  2      -2.5       2.6       -0.0        0.1",
        " 11  3       2.4      -0.5        0.0        0.0",
        " 11  4      -0.9      -0.4       -0.0        0.2",
        " 11  5       0.3       0.6       -0.1       -0.0",
        " 11  6      -0.7      -0.2        0.0        0.0",
        " 11  7      -0.1      -1.7       -0.0        0.1",
        " 11  8       1.4      -1.6       -0.1       -0.0",
        " 11  9      -0.6      -3.0       -0.1       -0.1",
        " 11 10       0.2      -2.0       -0.1        0.0",
        " 11 11       3.1      -2.6       -0.1       -0.0",
        " 12  0      -2.0       0.0        0.0        0.0",
        " 12  1      -0.1      -1.2       -0.0       -0.0",
        " 12  2       0.5       0.5       -0.0        0.0",
        " 12  3       1.3       1.3        0.0       -0.1",
        " 12  4      -1.2      -1.8       -0.0        0.1",
        " 12  5       0.7       0.1       -0.0       -0.0",
        " 12  6       0.3       0.7        0.0        0.0",
        " 12  7       0.5      -0.1       -0.0       -0.0",
        " 12  8      -0.2       0.6        0.0        0.1",
        " 12  9      -0.5       0.2       -0.0       -0.0",
        " 12 10       0.1      -0.9       -0.0       -0.0",
        " 12 11      -1.1      -0.0       -0.0        0.0",
        " 12 12      -0.3       0.5       -0.1       -0.1"
    };

        ///<summary>Geodetic altitude in km. An input,
        /// but set to zero in this class.  Changed
        /// back to an input in version 5.  If not specified,
        /// then is 0.
        /// </summary>
        private double _alt = 0;
        ///<summary>Geodetic latitude in deg.  An input.</summary>
        private double _glat = 0;
        ///<summary>Geodetic longitude in deg.  An input.</summary>
        private double _glon = 0;
        ///<summary>Time in decimal years.  An input.</summary>
        private double _time = 0;

        ///<summary>Geomagnetic declination in deg.
        ///	East is positive, West is negative.
        /// (The negative of variation.)</summary>
        private double _dec = 0;

        ///<summary>Geomagnetic inclination in deg.
        ///	Down is positive, up is negative.</summary>
        private double _dip = 0;
        ///<summary>Geomagnetic total intensity, in nano Teslas.</summary>
        private double _ti = 0;

        ///<summary>The maximum number of degrees of the spherical harmonic model.</summary>
        private readonly int _maxdeg = 12;
        ///<summary>The maximum order of spherical harmonic model.</summary>
        private int _maxord;

        ///<summary>
        /// Added in version 5.  In earlier versions the date for the calculation was held as a
        /// constant.  Now the default date is set to 2.5 years plus the epoch read from the
        /// input file.</summary>
        private double _defaultDate = 2022.5;


        ///<summary>
        /// Added in version 5.  In earlier versions the altitude for the calculation was held as a
        /// constant at 0.  In version 5, if no altitude is specified in the calculation, this
        /// altitude is used by default.</summary>
        private readonly double _defaultAltitude = 0;

        ///<summary>The Gauss coefficients of main geomagnetic model (nt).</summary>
        private readonly double[,] _c = new double[13, 13];

        ///<summary>The Gauss coefficients of secular geomagnetic model (nt/yr).</summary>
        private readonly double[,] _cd = new double[13, 13];
        ///<summary>The time adjusted geomagnetic gauss coefficients (nt).</summary>
        private readonly double[,] _tc = new double[13, 13];
        ///<summary>The theta derivative of p(n,m) (unnormalized).</summary>
        private readonly double[,] _dp = new double[13, 13];
        ///<summary>The Schmidt normalization factors.</summary>
        private readonly double[] _snorm = new double[169];
        ///<summary>The sine of (m*spherical coord. longitude).</summary>
        private readonly double[] _sp = new double[13];
        ///<summary>The cosine of (m*spherical coord. longitude).</summary>
        private readonly double[] _cp = new double[13];
        private readonly double[] _fn = new double[13];
        private readonly double[] _fm = new double[13];
        ///<summary>The associated Legendre polynomials for m=1 (unnormalized).</summary>
        private readonly double[] _pp = new double[13];

        private readonly double[,] _k = new double[13, 13];

        ///<summary>
        ///The variables otime (old time), oalt (old altitude),
        /// olat(old latitude), olon(old longitude), are used to
        /// store the values used from the previous calculation to
        /// save on calculation time if some inputs don't change.
        /// </summary>
        private double _otime, _oalt, _olat, _olon;


        ///<summary>The date in years, for the start of the valid time of the fit coefficients</summary>
        private double _epoch;

        ///<summary>
        /// bx is the north south field intensity
        /// by is the east west field intensity
        /// bz is the vertical field intensity positive downward
        /// bh is the horizontal field intensity
        /// </summary>
        private double _bx, _by, _bz, _bh;

        ///<summary>
        /// re is the Mean radius of IAU-66 ellipsoid, in km.
        /// a2 is the Semi-major axis of WGS-84 ellipsoid, in km, squared.
        /// b2 is the Semi-minor axis of WGS-84 ellipsoid, in km, squared.
        /// c2 is c2 = a2 - b2
        /// a4 is a2 squared.
        /// b4 is b2 squared.
        /// c4 is c4 = a4 - b4.
        ///</summary>
        private double _re, _a2, _b2, _c2, _a4, _b4, _c4;

        /// <summary>
        /// even though these only occur in one method, they must be
        /// created here, or won't have correct values calculated
        /// These values are only recalculated if the altitude changes.
        /// </summary>
        private double _r, _d, _ca, _sa, _ct, _st;

        private readonly string _filePath;
        private StreamReader _reader;
        private CultureInfo _usCulture = new CultureInfo("en_US");
        ///<summary>Instantiates object by calling initModel() with file.</summary>
        /// <param name="path">Path to WMM.COF</param>
        public GeoMag(string path)
        {
            _filePath = path;
            InitModel();
        }
        public GeoMag()
        {
            InitModel();
        }

        ///<summary>
        /// Reads data from file and initializes magnetic model.  If
        /// the file is not present, or an IO exception occurs, then the internal
        /// values valid for 2015 will be used. Note that the last line of the
        /// WMM.COF file must be 9999... for this method to read in the input
        /// file properly.
        /// </summary>
        private void InitModel()
        {
            _glat = 0;
            _glon = 0;

            // INITIALIZE CONSTANTS
            _maxord = _maxdeg;
            _sp[0] = 0.0;
            _cp[0] = _snorm[0] = _pp[0] = 1.0;
            _dp[0, 0] = 0.0;
            /**
             *	Semi-major axis of WGS-84 ellipsoid, in km.
             */
            const double a = 6378.137d;
            /**
             *	Semi-minor axis of WGS-84 ellipsoid, in km.
             */
            const double b = 6356.7523142d;
            /**
             *	Mean radius of IAU-66 ellipsoid, in km.
             */
            _re = 6371.2;
            _a2 = a * a;
            _b2 = b * b;
            _c2 = _a2 - _b2;
            _a4 = _a2 * _a2;
            _b4 = _b2 * _b2;
            _c4 = _a4 - _b4;

            try
            {
                if (_reader == null)
                {
                    if (string.IsNullOrWhiteSpace(_filePath)) throw new FileNotFoundException($"{_filePath} not found");
                    var stream = new FileStream(_filePath,FileMode.Open);
                    _reader = new StreamReader(stream);
                }
                if (_input == null) throw new FileNotFoundException($"{_filePath} not found");


                // READ WORLD MAGNETIC MODEL SPHERICAL HARMONIC COEFFICIENTS 
                _c[0, 0] = 0.0;
                _cd[0, 0] = 0.0;
                // str.NextToken();
                var epochStr = _reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                _epoch = double.Parse(epochStr[0], _usCulture);
                _defaultDate = _epoch + 2.5;
                //loop to get data from file
                while (true)
                {
                    var val = _reader.ReadLine();
                    if (val.Contains("999999999999999999999999999999999999999999999999"))
                        break;
                    var values = val.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var n = int.Parse(values[0]);
                    var m = int.Parse(values[1]);
                    var gnm = double.Parse(values[2], _usCulture);
                    var hnm = double.Parse(values[3], _usCulture);
                    var dgnm = double.Parse(values[4], _usCulture);
                    var dhnm = double.Parse(values[5], _usCulture);

                    if (m <= n)
                    {
                        _c[m, n] = gnm;
                        _cd[m, n] = dgnm;

                        if (m != 0)
                        {
                            _c[n, m - 1] = hnm;
                            _cd[n, m - 1] = dhnm;
                        }
                    }

                }
            }
            catch (FileNotFoundException e)
            {
                const string msg = "\nNOTICE      NOTICE      NOTICE      \n" +
                                   "WMMCOF file not found in TSAGeoMag.InitModel()\n" +
                                   "The input file WMM.COF was not found in the same\n" +
                                   "directory as the application.\n" +
                                   "The magnetic field components are set to internal values.\n";
                Debug.WriteLine(msg);
                Debug.WriteLine(e.Message);
                SetCoeff();
            }

            catch (IOException e)
            {
                var msg = "\nNOTICE      NOTICE      NOTICE      \n" +
                    "Problem reading the WMMCOF file in TSAGeoMag.InitModel()\n" +
                    "The input file WMM.COF was found, but there was a problem \n" +
                    "reading the data.\n" +
                    "The magnetic field components are set to internal values.";

                Debug.WriteLine(msg);
                Debug.WriteLine(e.Message);
                SetCoeff();
            }
            // CONVERT SCHMIDT NORMALIZED GAUSS COEFFICIENTS TO UNNORMALIZED
            _snorm[0] = 1.0;
            for (var n = 1; n <= _maxord; n++)
            {

                _snorm[n] = _snorm[n - 1] * (2 * n - 1) / n;
                var j = 2;

                for (int m = 0, d1 = 1, d2 = (n - m + d1) / d1; d2 > 0; d2--, m += d1)
                {
                    _k[m, n] = (double)(((n - 1) * (n - 1)) - (m * m)) / (double)((2 * n - 1) * (2 * n - 3));
                    if (m > 0)
                    {
                        var flnmj = ((n - m + 1) * j) / (double)(n + m);
                        _snorm[n + m * 13] = _snorm[n + (m - 1) * 13] * Math.Sqrt(flnmj);
                        j = 1;
                        _c[n, m - 1] = _snorm[n + m * 13] * _c[n, m - 1];
                        _cd[n, m - 1] = _snorm[n + m * 13] * _cd[n, m - 1];
                    }
                    _c[m, n] = _snorm[n + m * 13] * _c[m, n];
                    _cd[m, n] = _snorm[n + m * 13] * _cd[m, n];
                }

                _fn[n] = (n + 1);
                _fm[n] = n;

            }

            _k[1, 1] = 0.0;

            _otime = _oalt = _olat = _olon = -1000.0;


        }

        ///<summary>     <p><b>PURPOSE:</b>  THIS ROUTINE COMPUTES THE DECLINATION (DEC),
        ///               INCLINATION (DIP), TOTAL INTENSITY (TI) AND
        ///               GRID VARIATION (GV - POLAR REGIONS ONLY, REFERENCED
        ///               TO GRID NORTH OF POLAR STEREOGRAPHIC PROJECTION) OF
        ///               THE EARTH'S MAGNETIC FIELD IN GEODETIC COORDINATES
        ///               FROM THE COEFFICIENTS OF THE CURRENT OFFICIAL
        ///               DEPARTMENT OF DEFENSE (DOD) SPHERICAL HARMONIC WORLD
        ///               MAGNETIC MODEL (WMM-2010).  THE WMM SERIES OF MODELS IS
        ///               UPDATED EVERY 5 YEARS ON JANUARY 1'ST OF THOSE YEARS
        ///               WHICH ARE DIVISIBLE BY 5 (I.E. 1980, 1985, 1990 ETC.)
        ///               BY THE NAVAL OCEANOGRAPHIC OFFICE IN COOPERATION
        ///               WITH THE BRITISH GEOLOGICAL SURVEY (BGS).  THE MODEL
        ///               IS BASED ON GEOMAGNETIC SURVEY MEASUREMENTS FROM
        ///               AIRCRAFT, SATELLITE AND GEOMAGNETIC OBSERVATORIES.</p><p>
        ///
        ///
        ///
        ///     <b>ACCURACY:</b>  IN OCEAN AREAS AT THE EARTH'S SURFACE OVER THE
        ///                ENTIRE 5 YEAR LIFE OF A DEGREE AND ORDER 12
        ///                SPHERICAL HARMONIC MODEL SUCH AS WMM-95, THE ESTIMATED
        ///                RMS ERRORS FOR THE VARIOUS MAGENTIC COMPONENTS ARE:</p>
        ///<ul>
        ///                DEC  -   0.5 Degrees<br/>
        ///                DIP  -   0.5 Degrees<br/>
        ///                TI   - 280.0 nanoTeslas (nT)<br/>
        ///                GV   -   0.5 Degrees<br/></ul>
        ///
        ///                <p>OTHER MAGNETIC COMPONENTS THAT CAN BE DERIVED FROM
        ///                THESE FOUR BY SIMPLE TRIGONOMETRIC RELATIONS WILL
        ///                HAVE THE FOLLOWING APPROXIMATE ERRORS OVER OCEAN AREAS:</p>
        ///<ul>
        ///                X    - 140 nT (North)<br/>
        ///                Y    - 140 nT (East)<br/>
        ///                Z    - 200 nT (Vertical)  Positive is down<br/>
        ///                H    - 200 nT (Horizontal)<br/></ul>
        ///
        ///                <p>OVER LAND THE RMS ERRORS ARE EXPECTED TO BE SOMEWHAT
        ///                HIGHER, ALTHOUGH THE RMS ERRORS FOR DEC, DIP AND GV
        ///                ARE STILL ESTIMATED TO BE LESS THAN 0.5 DEGREE, FOR
        ///                THE ENTIRE 5-YEAR LIFE OF THE MODEL AT THE EARTH's
        ///                SURFACE.  THE OTHER COMPONENT ERRORS OVER LAND ARE
        ///                MORE DIFFICULT TO ESTIMATE AND SO ARE NOT GIVEN.</p><p>
        ///
        ///                THE ACCURACY AT ANY GIVEN TIME OF ALL FOUR
        ///                GEOMAGNETIC PARAMETERS DEPENDS ON THE GEOMAGNETIC
        ///                LATITUDE.  THE ERRORS ARE LEAST AT THE EQUATOR AND
        ///                GREATEST AT THE MAGNETIC POLES.</p><p>
        ///
        ///                IT IS VERY IMPORTANT TO NOTE THAT A DEGREE AND
        ///                ORDER 12 MODEL, SUCH AS WMM-2010 DESCRIBES ONLY
        ///                THE LONG WAVELENGTH SPATIAL MAGNETIC FLUCTUATIONS
        ///                DUE TO EARTH'S CORE.  NOT INCLUDED IN THE WMM SERIES
        ///                MODELS ARE INTERMEDIATE AND SHORT WAVELENGTH
        ///                SPATIAL FLUCTUATIONS OF THE GEOMAGNETIC FIELD
        ///                WHICH ORIGINATE IN THE EARTH'S MANTLE AND CRUST.
        ///                CONSEQUENTLY, ISOLATED ANGULAR ERRORS AT VARIOUS
        ///                POSITIONS ON THE SURFACE (PRIMARILY OVER LAND, IN
        ///                CONTINENTAL MARGINS AND OVER OCEANIC SEAMOUNTS,
        ///                RIDGES AND TRENCHES) OF SEVERAL DEGREES MAY BE
        ///                EXPECTED. ALSO NOT INCLUDED IN THE MODEL ARE
        ///                NONSECULAR TEMPORAL FLUCTUATIONS OF THE GEOMAGNETIC
        ///                FIELD OF MAGNETOSPHERIC AND IONOSPHERIC ORIGIN.
        ///                DURING MAGNETIC STORMS, TEMPORAL FLUCTUATIONS CAN
        ///                CAUSE SUBSTANTIAL DEVIATIONS OF THE GEOMAGNETIC
        ///                FIELD FROM MODEL VALUES.  IN ARCTIC AND ANTARCTIC
        ///                REGIONS, AS WELL AS IN EQUATORIAL REGIONS, DEVIATIONS
        ///                FROM MODEL VALUES ARE BOTH FREQUENT AND PERSISTENT.</p><p>
        ///
        ///                IF THE REQUIRED DECLINATION ACCURACY IS MORE
        ///                STRINGENT THAN THE WMM SERIES OF MODELS PROVIDE, THEN
        ///                THE USER IS ADVISED TO REQUEST SPECIAL (REGIONAL OR
        ///                LOCAL) SURVEYS BE PERFORMED AND MODELS PREPARED BY
        ///                THE USGS, WHICH OPERATES THE US GEOMAGNETIC
        ///                OBSERVATORIES.  REQUESTS OF THIS NATURE SHOULD
        ///                BE MADE THROUGH NIMA AT THE ADDRESS ABOVE.</p><p>
        ///
        ///
        ///
        ///     NOTE:  THIS VERSION OF GEOMAG USES THE WMM-2010 GEOMAGNETIC
        ///            MODEL REFERENCED TO THE WGS-84 GRAVITY MODEL ELLIPSOID</p>
        ///</summary>
        /// <param name="fLat">The latitude in decimal degrees.</param>
        /// <param	name="fLon">The longitude in decimal degrees.</param>			
        /// <param	name="year">The date as a decimal year.</param>			
        /// <param	name="altitude">The altitude in kilometers.</param>		
        private void CalcGeoMag(double fLat, double fLon, double year, double altitude)
        {

            _glat = fLat;
            _glon = fLon;
            _alt = altitude;

            // The date in decimal years for calculating the magnetic field components.
            _time = year;

            var dt = _time - _epoch;


            const double pi = Math.PI;
            const double dtr = (pi / 180.0);
            var rlon = _glon * dtr;
            var rlat = _glat * dtr;
            var srlon = Math.Sin(rlon);
            var srlat = Math.Sin(rlat);
            var crlon = Math.Cos(rlon);
            var crlat = Math.Cos(rlat);
            var srlat2 = srlat * srlat;
            var crlat2 = crlat * crlat;
            _sp[1] = srlon;
            _cp[1] = crlon;

            // CONVERT FROM GEODETIC COORDS. TO SPHERICAL COORDS.
            if (_alt != _oalt || _glat != _olat)
            {
                var q = Math.Sqrt(_a2 - _c2 * srlat2);
                var q1 = _alt * q;
                var q2 = ((q1 + _a2) / (q1 + _b2)) * ((q1 + _a2) / (q1 + _b2));
                _ct = srlat / Math.Sqrt(q2 * crlat2 + srlat2);
                _st = Math.Sqrt(1.0 - (_ct * _ct));
                var r2 = ((_alt * _alt) + 2.0 * q1 + (_a4 - _c4 * srlat2) / (q * q));
                _r = Math.Sqrt(r2);
                _d = Math.Sqrt(_a2 * crlat2 + _b2 * srlat2);
                _ca = (_alt + _d) / _r;
                _sa = _c2 * crlat * srlat / (_r * _d);
            }
            if (_glon != _olon)
            {
                for (var m = 2; m <= _maxord; m++)
                {
                    _sp[m] = _sp[1] * _cp[m - 1] + _cp[1] * _sp[m - 1];
                    _cp[m] = _cp[1] * _cp[m - 1] - _sp[1] * _sp[m - 1];
                }
            }
            var aor = _re / _r;
            var ar = aor * aor;
            double br = 0, bt = 0, bp = 0, bpp = 0;

            for (var n = 1; n <= _maxord; n++)
            {
                ar *= aor;
                for (int m = 0, d3 = 1, d4 = (n + m + d3) / d3; d4 > 0; d4--, m += d3)
                {

                    //COMPUTE UNNORMALIZED ASSOCIATED LEGENDRE POLYNOMIALS
                    //AND DERIVATIVES VIA RECURSION RELATIONS
                    if (_alt != _oalt || _glat != _olat)
                    {
                        if (n == m)
                        {
                            _snorm[n + m * 13] = _st * _snorm[n - 1 + (m - 1) * 13];
                            _dp[m, n] = _st * _dp[m - 1, n - 1] + _ct * _snorm[n - 1 + (m - 1) * 13];
                        }
                        if (n == 1 && m == 0)
                        {
                            _snorm[n + m * 13] = _ct * _snorm[n - 1 + m * 13];
                            _dp[m, n] = _ct * _dp[m, n - 1] - _st * _snorm[n - 1 + m * 13];
                        }
                        if (n > 1 && n != m)
                        {
                            if (m > n - 2)
                                _snorm[n - 2 + m * 13] = 0.0;
                            if (m > n - 2)
                                _dp[m, n - 2] = 0.0;
                            _snorm[n + m * 13] = _ct * _snorm[n - 1 + m * 13] - _k[m, n] * _snorm[n - 2 + m * 13];
                            _dp[m, n] = _ct * _dp[m, n - 1] - _st * _snorm[n - 1 + m * 13] - _k[m, n] * _dp[m, n - 2];
                        }
                    }

                    //TIME ADJUST THE GAUSS COEFFICIENTS

                    if (_time != _otime)
                    {
                        _tc[m, n] = _c[m, n] + dt * _cd[m, n];

                        if (m != 0)
                            _tc[n, m - 1] = _c[n, m - 1] + dt * _cd[n, m - 1];
                    }

                    //ACCUMULATE TERMS OF THE SPHERICAL HARMONIC EXPANSIONS
                    double temp1, temp2;
                    var par = ar * _snorm[n + m * 13];
                    if (m == 0)
                    {
                        temp1 = _tc[m, n] * _cp[m];
                        temp2 = _tc[m, n] * _sp[m];
                    }
                    else
                    {
                        temp1 = _tc[m, n] * _cp[m] + _tc[n, m - 1] * _sp[m];
                        temp2 = _tc[m, n] * _sp[m] - _tc[n, m - 1] * _cp[m];
                    }

                    bt = bt - ar * temp1 * _dp[m, n];
                    bp += (_fm[m] * temp2 * par);
                    br += (_fn[n] * temp1 * par);

                    //SPECIAL CASE:  NORTH/SOUTH GEOGRAPHIC POLES

                    if (_st == 0.0 && m == 1)
                    {
                        if (n == 1)
                            _pp[n] = _pp[n - 1];
                        else
                            _pp[n] = _ct * _pp[n - 1] - _k[m, n] * _pp[n - 2];
                        var parp = ar * _pp[n];
                        bpp += (_fm[m] * temp2 * parp);
                    }

                }   //for(m...)

            }   //for(n...)


            if (_st == 0.0)
                bp = bpp;
            else
                bp /= _st;

            //ROTATE MAGNETIC VECTOR COMPONENTS FROM SPHERICAL TO
            //GEODETIC COORDINATES
            // by is the east-west field component
            // bx is the north-south field component
            // bz is the vertical field component.
            _bx = -bt * _ca - br * _sa;
            _by = bp;
            _bz = bt * _sa - br * _ca;

            //COMPUTE DECLINATION (DEC), INCLINATION (DIP) AND
            //TOTAL INTENSITY (TI)

            _bh = Math.Sqrt((_bx * _bx) + (_by * _by));
            _ti = Math.Sqrt((_bh * _bh) + (_bz * _bz));
            //	Calculate the declination.
            _dec = (Math.Atan2(_by, _bx) / dtr);
            // logger.debug("Dec is: " + dec);
            Debug.WriteLine("Dec is: " + _dec);
            _dip = (Math.Atan2(_bz, _bh) / dtr);

            //	This is the variation for grid navigation.
            //	Not used at this time.  See St. Ledger for explanation.
            //COMPUTE MAGNETIC GRID VARIATION IF THE CURRENT
            //GEODETIC POSITION IS IN THE ARCTIC OR ANTARCTIC
            //(I.E. GLAT > +55 DEGREES OR GLAT < -55 DEGREES)
            // Grid North is referenced to the 0 Meridian of a polar
            // stereographic projection.

            //OTHERWISE, SET MAGNETIC GRID VARIATION TO -999.0
            /*
                 gv = -999.0;
                 if (Math.abs(glat) >= 55.){
                 if (glat > 0.0 && glon >= 0.0) 
                 gv = dec-glon;
                 if (glat > 0.0 && glon < 0.0) 
                 gv = dec + Math.abs(glon);
                 if (glat < 0.0 && glon >= 0.0) 
                 gv = dec+glon;
                 if (glat < 0.0 && glon < 0.0) 
                 gv = dec - Math.abs(glon);
                 if (gv > +180.0) 
                 gv -= 360.0;
                 if (gv < -180.0) 
                 gv += 360.0;
                 }
             */
            _otime = _time;
            _oalt = _alt;
            _olat = _glat;
            _olon = _glon;

        }

        /// <summary>
        /// Returns the declination from the Department of
        ///	Defense geomagnetic model and data, in degrees.The
        /// magnetic heading + declination = true heading.The date and
        /// altitude are the defaults, of half way through the valid 
        /// 5 year period, and 0 elevation.
        /// (True heading + variation = magnetic heading.)
        /// </summary>
        /// <param name="dlat">Latitude in decimal degrees.</param>
        /// <param name="dlong">Longitude in decimal degrees.</param>
        /// <returns>The declination in degrees.</returns>
        public double GetDeclination(double dlat, double dlong)
        {
            CalcGeoMag(dlat, dlong, _defaultDate, _defaultAltitude);
            return _dec;
        }

        /// <summary>
        /// Returns the declination from the Department of
        ///  Defense geomagnetic model and data, in degrees.  The
        /// magnetic heading + declination = true heading.
        /// (True heading + variation = magnetic heading.)
        /// </summary>
        /// <param name="dlat">Latitude in decimal degrees.</param>
        /// <param name="dlong">Longitude in decimal degrees.</param>
        /// <param name="year">The date as a decimal year.</param>
        /// <param name="altitude">The altitude in kilometers.</param>
        /// <returns>The declination in degrees.</returns>
        public double GetDeclination(double dlat, double dlong, double year, double altitude)
        {
            CalcGeoMag(dlat, dlong, year, altitude);
            return _dec;
        }
        ///<summary>
        ///	Returns the magnetic field intensity from the
        ///	Department of Defense geomagnetic model and data
        ///	in nano Tesla. The date and
        /// altitude are the defaults, of half way through the valid 
        /// 5 year period, and 0 elevation.
        ///</summary>
        /// <param	name="dlat">Latitude in decimal degrees.</param>	
        /// <param 	name="dlong">Longitude in decimal degrees.</param>	
        /// 
        /// <return>Magnetic field strength in nano Tesla.</return>  
        public double GetIntensity(double dlat, double dlong)
        {
            CalcGeoMag(dlat, dlong, _defaultDate, _defaultAltitude);
            return _ti;
        }

        ///<summary>
        ///	Returns the magnetic field intensity from the 
        ///	Department of Defense geomagnetic model and data
        ///	in nano Tesla.</summary>
        /// <param	name="dlat">Latitude in decimal degrees.</param>	 	
        /// <param name="dlong">Longitude in decimal degrees.</param>		
        /// <param	name="year">Date of the calculation in decimal years.</param>		
        /// <param	name="altitude">Altitude of the calculation in kilometers.</param>	
        ///<return>Magnetic field strength in nano Tesla.</return>  

        public double GetIntensity(double dlat, double dlong, double year, double altitude)
        {
            CalcGeoMag(dlat, dlong, year, altitude);
            return _ti;
        }
        ///<summary>
        ///	Returns the horizontal magnetic field intensity from the
        ///	Department of Defense geomagnetic model and data
        ///	in nano Tesla. The date and
        ///  altitude are the defaults, of half way through the valid 
        ///  5 year period, and 0 elevation.</summary>
        /// <param	name="dlat">Latitude in decimal degrees.</param>	
        /// <param 	name="dlong">Longitude in decimal degrees.</param>	
        /// <return></return>  The horizontal magnetic field strength in nano Tesla.

        public double GetHorizontalIntensity(double dlat, double dlong)
        {
            CalcGeoMag(dlat, dlong, _defaultDate, _defaultAltitude);
            return _bh;
        }

        ///<summary>
        ///	Returns the horizontal magnetic field intensity from the
        ///	Department of Defense geomagnetic model and data
        ///	in nano Tesla.</summary>
        /// <param	name="dlat">Latitude in decimal degrees.</param>	 	
        /// <param 	name="dlong">Longitude in decimal degrees.</param>		
        /// <param	name="year">Date of the calculation in decimal years.</param>		
        /// <param	name="altitude">Altitude of the calculation in kilometers.</param>	
        /// <return></return>  The horizontal magnetic field strength in nano Tesla.

        public double GetHorizontalIntensity(double dlat, double dlong, double year, double altitude)
        {
            CalcGeoMag(dlat, dlong, year, altitude);
            return _bh;
        }

        /// <summary>
        ///	Returns the vertical magnetic field intensity from the
        ///	Department of Defense geomagnetic model and data
        ///	in nano Tesla. The date and
        ///  altitude are the defaults, of half way through the valid 
        ///  5 year period, and 0 elevation.
        /// </summary>
        /// <param	name="dlat">Latitude in decimal degrees.</param>	
        /// <param 	name="dlong">Longitude in decimal degrees.</param>	
        /// <return> The vertical magnetic field strength in nano Tesla.</return> 

        public double GetVerticalIntensity(double dlat, double dlong)
        {
            CalcGeoMag(dlat, dlong, _defaultDate, _defaultAltitude);
            return _bz;
        }

        ///<summary>
        ///	Returns the vertical magnetic field intensity from the
        ///	Department of Defense geomagnetic model and data
        ///	in nano Tesla.</summary>
        /// <param name="dlat">Latitude in decimal degrees.</param>	 	
        /// <param name="dlong">Longitude in decimal degrees.</param>		
        /// <param	name="year">Date of the calculation in decimal years.</param>		
        /// <param	name="altitude">Altitude of the calculation in kilometers.</param>	
        /// <return>The vertical magnetic field strength in nano Tesla.</return>  
        public double GetVerticalIntensity(double dlat, double dlong, double year, double altitude)
        {
            CalcGeoMag(dlat, dlong, year, altitude);
            return _bz;
        }
        ///<summary>
        /// Returns the northerly magnetic field intensity from the
        /// Department of Defense geomagnetic model and data
        /// in nano Tesla. The date and
        /// altitude are the defaults, of half way through the valid 
        /// 5 year period, and 0 elevation.
        ///</summary>
        /// <param	name="dlat">Latitude in decimal degrees.</param>	
        /// <param name="dlong">Longitude in decimal degrees.</param>	
        /// <return>The northerly component of the magnetic field strength in nano Tesla.</return>  

        public double GetNorthIntensity(double dlat, double dlong)
        {
            CalcGeoMag(dlat, dlong, _defaultDate, _defaultAltitude);
            return _bx;
        }

        ///<summary>
        /// Returns the northerly magnetic field intensity from the
        /// Department of Defense geomagnetic model and data
        /// in nano Tesla.
        ///</summary>
        /// <param name="dlat">Latitude in decimal degrees.</param>	 	
        /// <param name="dlong">Longitude in decimal degrees.</param>		
        /// <param name="year">Date of the calculation in decimal years.</param>		
        /// <param name="altitude">Altitude of the calculation in kilometers.</param>		
        /// 
        /// <return>The northerly component of the magnetic field strength in nano Tesla.</return>  

        public double GetNorthIntensity(double dlat, double dlong, double year, double altitude)
        {
            CalcGeoMag(dlat, dlong, year, altitude);
            return _bx;
        }
        ///<summary>
        /// Returns the easterly magnetic field intensity from the
        /// Department of Defense geomagnetic model and data
        /// in nano Tesla. The date and
        /// altitude are the defaults, of half way through the valid 
        /// 5 year period, and 0 elevation.
        ///</summary>
        /// <param	name="dlat">Latitude in decimal degrees.</param>		
        /// <param name="dlong">Longitude in decimal degrees.</param>	
        /// <return>The easterly component of the magnetic field strength in nano Tesla.</return>  

        public double GetEastIntensity(double dlat, double dlong)
        {
            CalcGeoMag(dlat, dlong, _defaultDate, _defaultAltitude);
            return _by;
        }

        ///<summary>
        ///	Returns the easterly magnetic field intensity from the
        ///	Department of Defense geomagnetic model and data
        ///	in nano Tesla.
        ///</summary>
        /// <param	name="dlat">Latitude in decimal degrees.</param>	 	
        /// <param 	name="dlong">Longitude in decimal degrees.</param>		
        /// <param	name="year">Date of the calculation in decimal years.</param>		
        /// <param	name="altitude">Altitude of the calculation in kilometers.</param>	
        ///
        /// <return>The easterly component of the magnetic field strength in nano Tesla.</return>  

        public double GetEastIntensity(double dlat, double dlong, double year, double altitude)
        {
            CalcGeoMag(dlat, dlong, year, altitude);
            return _by;
        }
        ///<summary>
        ///	Returns the magnetic field dip angle from the
        ///	Department of Defense geomagnetic model and data,
        ///	in degrees.  The date and
        /// altitude are the defaults, of half way through the valid 
        /// 5 year period, and 0 elevation.
        ///</summary>
        /// <param	name="lat">Latitude in decimal degrees.</param>	
        /// <param 	name="lon">Longitude in decimal degrees.</param>	
        /// <return>The magnetic field dip angle, in degrees.</return>  

        public double GetDipAngle(double lat, double lon)
        {
            CalcGeoMag(lat, lon, _defaultDate, _defaultAltitude);
            return _dip;
        }

        ///<summary>
        /// Returns the magnetic field dip angle from the
        /// Department of Defense geomagnetic model and data,
        /// in degrees.
        ///</summary>
        /// <param	name="dlat"	>Latitude in decimal degrees.</param>		
        /// <param name="	dlong">Longitude in decimal degrees.</param>		
        /// <param	name="year">Date of the calculation in decimal years.</param>			
        /// <param	name="altitude">Altitude of the calculation in kilometers.</param>		
        ///
        /// <return>The magnetic field dip angle, in degrees.</return>  
        public double GetDipAngle(double dlat, double dlong, double year, double altitude)
        {
            CalcGeoMag(dlat, dlong, year, altitude);
            return _dip;
        }

        ///<summary>	This method sets the input data to the internal fit coefficents.
        ///	If there is an exception reading the input file WMM.COF, these values 
        ///	are used.
        ///
        ///  NOTE:  This method is not tested by the JUnit test, unless the WMM.COF file
        ///         is missing.
        /// </summary>
        private void SetCoeff()
        {
            _c[0, 0] = 0.0;
            _cd[0, 0] = 0.0;
            var firstLine = _input[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            _epoch = double.Parse(firstLine[0], _usCulture);
            _defaultDate = _epoch + 2.5;

            //loop to get data from internal values
            for (var i = 1; i < _input.Length; i++)
            {
                var tokens = _input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var n = int.Parse(tokens[0], _usCulture);
                var m = int.Parse(tokens[1], _usCulture);
                var gnm = double.Parse(tokens[2], _usCulture);
                var hnm = double.Parse(tokens[3], _usCulture);
                var dgnm = double.Parse(tokens[4], _usCulture);
                var dhnm = double.Parse(tokens[5], _usCulture);

                if (m <= n)
                {
                    _c[m, n] = gnm;
                    _cd[m, n] = dgnm;

                    if (m != 0)
                    {
                        _c[n, m - 1] = hnm;
                        _cd[n, m - 1] = dhnm;
                    }
                }
            }
        }

        ///<summary><p>  
        ///   Given a Gregorian Calendar object, this returns the decimal year
        ///   value for the calendar, accurate to the day of the input calendar.
        ///   The hours, minutes, and seconds of the date are ignored.</p><p>
        ///   
        ///   If the input Gregorian Calendar is new GregorianCalendar(2012, 6, 1), all of
        ///   the first of July is counted, and this returns 2012.5. (183 days out of 366)</p><p>
        ///   
        ///   If the input Gregorian Calendar is new GregorianCalendar(2010, 0, 0), the first
        ///   of January is not counted, and this returns 2010.0</p><p>
        ///</summary>   
        /// <param name="cal">Has the date (year, month, and day of the month)</param>  
        /// <returns>The date in decimal years</returns>	   
        public double DecimalYear(DateTime cal)
        {
            var year = cal.Year;
            var daysInYear = DateTime.IsLeapYear(year) ? 366.0 : 365.0;
            return year + (cal.DayOfYear) / daysInYear;

        }

        public void Dispose()
        {
            _reader?.Dispose();
        }
    }

}
