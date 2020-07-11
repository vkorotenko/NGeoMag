# NGeoMag

## Description
Port of Java library "John St. Ledger	Java implementation with tests." https://www.ngdc.noaa.gov/geomag/data/WMM/TSAGeoMag.zip

Base page to see other lang.
https://www.ngdc.noaa.gov/geomag/WMM/thirdpartycontributions.shtml

## Usage
```lang='C#'
// Initialize with file
GeoMag magFileModel = new GeoMag("WMM.COF");
// Use internal constant
GeoMag magModel = new GeoMag();


// -112.41
var declination  = magModel.GetDeclination(89, -121, 2020.0, 28);

```

## Авторы

* **Vladimir N. Korotenko** 

## Сотрудничество
https://t.me/vkorotenko

По возникшим вопросам обращайтесь по электронной почте [koroten@ya.ru](mailto:koroten@ya.ru)
или в Telegram [@vkorotenko](https://t.me/vkorotenko) 

## License

This project is licensed under the CC License - see the [LICENSE](https://github.com/vkorotenko/NGeoMag/blob/master/LICENSE) file for details
