namespace WebSharper.DateFNS.Extension

open WebSharper
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator

module Definition =

    let Num = T<int> + T<float>

    let Interval =
        Pattern.Config "Interval" {
            Required = [
                "start", T<Date> + Num
                "end", T<Date> + Num
            ]
            Optional = []
        }

    let Localize =
        Pattern.Config "Localize" {
            Required = []
            Optional = [
                "ordinalNumber", T<JavaScript.Function>
                "era", T<JavaScript.Function>
                "quarter", T<JavaScript.Function>
                "month", T<JavaScript.Function>
                "day", T<JavaScript.Function>
                "dayPeriod", T<JavaScript.Function>
            ]
        }

    let FormatLong =
        Pattern.Config "FormatLong" {
            Required = []
            Optional = [
                "date", T<JavaScript.Function>
                "time", T<JavaScript.Function>
                "dateTime", T<JavaScript.Function>
            ]
        }

    let Match =
        Pattern.Config "Match" {
            Required = []
            Optional = [
                "ordinalNumber", T<JavaScript.Function>
                "era", T<JavaScript.Function>
                "quarter", T<JavaScript.Function>
                "month", T<JavaScript.Function>
                "day", T<JavaScript.Function>
                "dayPeriod", T<JavaScript.Function>
            ]
        }

    let DayFromZero =
        Pattern.EnumInlines "DayFromZero" [
            "0", "0"
            "1", "1"
            "2", "2"
            "3", "3"
            "4", "4"
            "5", "5"
            "6", "6"
        ]

    let DayFromOne =
        Pattern.EnumInlines "DayFromOne" [
            "1", "1"
            "2", "2"
            "3", "3"
            "4", "4"
            "5", "5"
            "6", "6"
            "7", "7"
        ]

    let Options =
        Pattern.Config "Options" {
            Required = []
            Optional = [
                "weekStartsOn", DayFromZero.Type
                "firstWeekContainsDate", DayFromOne.Type
            ]
        }

    let Locale =
        Pattern.Config "Locale" {
            Required = []
            Optional = [
                "code", T<string>
                "formatDistance", T<JavaScript.Function>
                "formatRelative", T<JavaScript.Function>
                "localize", Localize.Type
                "formatLong", FormatLong.Type
                "match", Match.Type
                "options", Options.Type
            ]
        }

    let Duration =
        Pattern.Config "Duration" {
            Required = []
            Optional = [
                "years", Num
                "motnhs", Num
                "weeks", Num
                "days", Num
                "hours", Num
                "minutes", Num
                "seconds", Num
            ]
        }

    let FormatOptions =
        Pattern.Config "FormatOptions" {
            Required = []
            Optional = [
                "locale", Locale.Type
                "weekStartsOn", DayFromZero.Type
                "firstWeekContainsDate", Num
                "useAdditionalWeekYearTokens", T<bool>
                "useAdditionalDayOfYearTokens", T<bool>
            ]
        }

    let FormatDistanceOptions =
        Pattern.Config "FormatDistanceOptions" {
            Required = []
            Optional = [
                "includeSeconds", T<bool>
                "addSuffix", T<bool>
                "locale", Locale.Type
            ]
        }

    let Unit =
        Pattern.EnumStrings "Unit" [
            "second"
            "minute"
            "hour"
            "day"
            "month"
            "year"
        ]

    let RoundingMethod =
        Pattern.EnumStrings "RoundingMethod" [
            "floor"
            "ceil"
            "round"
        ]

    let FormatDistanceStrictOptions =
        Pattern.Config "FormatDistanceStrictOptions" {
            Required = []
            Optional = [
                "addSuffix", T<bool>
                "unit", Unit.Type
                "roundingMethod", RoundingMethod.Type
                "locale", Locale.Type
            ]
        }

    let FormatDurationOptions =
        Pattern.Config "FormatDurationOptions" {
            Required = []
            Optional = [
                "format", !| T<string>
                "zero", T<bool>
                "delimeter", T<string>
                "locale", Locale.Type
            ]
        }

    let Format =
        Pattern.EnumStrings "Format" [
            "extended"
            "basic"
        ]

    let Representation =
        Pattern.EnumStrings "Representation" [
            "complete"
            "date"
            "time"
        ]

    let FormatISOOptions =
        Pattern.Config "FormatISOOptions" {
            Required = []
            Optional = [
                "format", Format.Type
                "representation", Representation.Type
            ]
        }

    let FractionDigits =
        Pattern.EnumInlines "FractionDigits" [
            "0", "0"
            "1", "1"
            "2", "2"
            "3", "3"
        ]

    let FormatRFC3339Options =
        Pattern.Config "FormatRFC3339Options" {
            Required = []
            Optional = [
                "fractionDigits", FractionDigits.Type
            ]
        }

    let FormatRelativeOptions =
        Pattern.Config "FormatRelativeOptions" {
            Required = []
            Optional = [
                "locale", Locale.Type
                "weekStartsOn", DayFromZero.Type
            ]
        }

    let LocaleMatcher =
        Pattern.EnumInlines "LocaleMatcher" [
            "lookup", "'lookup'"
            "bestFit", "'best fit'"
        ]

    let IntlFormatRepresentation1 =
        Pattern.EnumStrings "IntlFormatRepresentation1" [
            "narrow"
            "short"
            "long"
        ]
    
    let IntlFormatRepresentation2 =
        Pattern.EnumStrings "IntlFormatRepresentation2" [
            "numeric"
            "2-digit"
        ]

    let IntlFormatRepresentation3 =
        Pattern.EnumStrings "IntlFormatRepresentation3" [
            "narrow"
            "short"
            "long"
            "numeric"
            "2-digit"
        ]

    let IntlFormatRepresentation4 =
        Pattern.EnumStrings "IntlFormatRepresentation4" [
            "short"
            "long"
        ]

    let FormatMatcher =
        Pattern.EnumInlines "FormatMatcher" [
            "basic", "'basic'"
            "bestFit", "'best fit'"
        ]

    let IntlFormatOptions =
        Pattern.Config "IntlFormatOptions" {
            Required = []
            Optional = [
                "localeMatcher", LocaleMatcher.Type
                "weekday", IntlFormatRepresentation1.Type
                "era", IntlFormatRepresentation1.Type
                "year", IntlFormatRepresentation2.Type
                "month", IntlFormatRepresentation3.Type
                "day", IntlFormatRepresentation2.Type
                "hour", IntlFormatRepresentation2.Type
                "minute", IntlFormatRepresentation2.Type
                "second", IntlFormatRepresentation2.Type
                "timeZoneName", IntlFormatRepresentation4.Type
                "formatMatcher", FormatMatcher.Type
                "hour12", T<bool>
                "timeZone", T<string>
            ]
        }

    let IntlLocaleOptions =
        Pattern.Config "IntlLocaleOptions" {
            Required = []
            Optional = [
                "locale", Locale.Type
            ]
        }

    let IsMatchOptions =
        Pattern.Config "IsMatchOptions" {
            Required = []
            Optional = [
                "locale", Locale.Type
                "weekStartsOn", DayFromZero.Type
                "firstWeekContainsDate", DayFromOne.Type
                "useAdditionalWeekYearTokens", T<bool>
                "useAdditionalDayOfYearTokens", T<bool>
            ]
        }

    let ParseOptions =
        Pattern.Config "ParseOptions" {
            Required = []
            Optional = [
                "locale", Locale.Type
                "weekStartsOn", DayFromZero.Type
                "firstWeekContainsDate", DayFromOne.Type
                "useAdditionalWeekYearTokens", T<bool>
                "useAdditionalDayOfYearTokens", T<bool>
            ]
        }

    let AdditionalDigits =
        Pattern.EnumInlines "AdditionalDigits" [
            "0", "0"
            "1", "1"
            "2", "2"
        ]

    let ParseISOOptions =
        Pattern.Config "ParseISOOptions" {
            Required = []
            Optional = [
                "additionalDigits", AdditionalDigits.Type
            ]
        }

    let SetValues =
        Pattern.Config "SetValues" {
            Required = []
            Optional = [
                "year", Num
                "motnh", Num
                "date", Num
                "hours", Num
                "minutes", Num
                "seconds", Num
                "milliseconds", Num
            ]
        }

    let AreIntervalsOverlappingOptions =
        Pattern.Config "AreIntervalsOverlappingOptions" {
            Required = []
            Optional = [
                "inclusive", T<bool>
            ]
        }

    let EachDHMOfIntervalOptions =
        Pattern.Config "EachDayOfIntervalOptions" {
            Required = []
            Optional = [
                "step", Num
            ]
        }

    let EachWeekOfIntervalOptions =
        Pattern.Config "EachWeekOfIntervalOptions" {
            Required = []
            Optional = [
                "locale", Locale.Type
                "weekStartsOn", DayFromZero.Type
            ]
        }

    let RoundToNearestMinuteOptions =
        Pattern.Config "RoundToNearestMinuteOptions" {
            Required = []
            Optional = [
                "nearestTo", Num
            ]
        }

    let SetDayOptions =
        Pattern.Config "SetDayOptions" {
            Required = []
            Optional = [
                "locale", Locale.Type
                "weekStartsOn", DayFromZero.Type
            ]
        }

    let DateFNS =
        Class "globalThis['date-fns']"
        |> WithSourceName "DateFNS"
        |+> Static [
            // Common helpers
            "add" => (T<Date> + Num)?date * Duration?duration ^-> T<Date>
            |> WithComment "Add the specified years, months, weeks, days, hours, minutes and seconds to the given date"
            "closestIndexTo" => (T<Date> + Num)?dateToCompare * (!| T<Date> + !| Num)?datesArray ^-> Num
            |> WithComment "Return an index of the closest date from the array comparing to the given date"
            "closestTo" => (T<Date> + Num)?dateToCompare * (!| T<Date> + !| Num)?datesArray ^-> T<Date>
            |> WithComment "Return a date from the array closest to the given date"
            "compareAsc" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            |> WithComment "Compare the two dates and return 1 if the first date is after the second, -1 if the first date is before the second or 0 if dates are equal"
            "comparedesc" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            |> WithComment "Compare the two dates and return -1 if the first date is after the second, 1 if the first date is before the second or 0 if dates are equal"
            "format" => (T<Date> + Num)?date * T<string>?format * !? FormatOptions?options ^-> T<string>
            |> WithComment "Return the formatted date string in the given format. The result may vary by locale"
            "formatDistance" => (T<Date> + Num)?date * (T<Date> + Num)?baseDate * !? FormatDistanceOptions?options ^-> T<string>
            |> WithComment "Return the distance between the given dates in words"
            "formatDistanceStrict" => (T<Date> + Num)?date * (T<Date> + Num)?baseDate * !? FormatDistanceStrictOptions?options ^-> T<string>
            |> WithComment "Return the distance between the given dates in words, using strict units. This is like `formatDistance`, but does not use helpers like 'almost', 'over', 'less than' and the like"
            "formatDistanceToNow" => (T<Date> + Num)?date * FormatDistanceOptions?options ^-> T<string>
            |> WithComment "Return the distance between the given date and now in words"
            "formatDistanceToNowStrict" => (T<Date> + Num)?date * !? FormatDistanceStrictOptions?options ^-> T<string>
            |> WithComment "Return the distance between the given dates in words, using strict units. This is like `formatDistance`, but does not use helpers like 'almost', 'over', 'less than' and the like"
            "formatDuration" => Duration?duration * !? FormatDurationOptions?options ^-> T<string>
            |> WithComment "Return human-readable duration string i.e. `9 months 2 days`"
            "formatISO" => (T<Date> + Num)?date * !? FormatISOOptions?options ^-> T<string>
            |> WithComment "Return the formatted date string in ISO 8601 format. Options may be passed to control the parts and notations of the date"
            "formatISO9075" => (T<Date> + Num)?date * !? FormatISOOptions?options ^-> T<string>
            |> WithComment "Return the formatted date string in ISO 9075 format. Options may be passed to control the parts and notations of the date"
            "formatISODuration" => Duration?duration ^-> T<string>
            |> WithComment "Format a duration object according to the ISO 8601 duration standard"
            "formatRFC3339" => (T<Date> + Num)?date * !? FormatRFC3339Options?options ^-> T<string>
            |> WithComment "Return the formatted date string in RFC 3339 format. Options may be passed to control the parts and notations of the date"
            "formatRFC7231" => (T<Date> + Num)?date ^-> T<string>
            |> WithComment "Return the formatted date string in RFC 7231 format. The result will always be in UTC timezone"
            "formatRelative" => (T<Date> + Num)?date * (T<Date> + Num)?baseDate * !? FormatRelativeOptions?options ^-> T<string>
            |> WithComment "Represent the date in words relative to the given base date"
            "intervalToDuration" => Interval?interval ^-> Duration
            |> WithComment "Convert a interval object to a duration object"
            "intlFormat" => (T<Date> + Num)?argument * !? IntlFormatOptions?formatOptions * !? IntlLocaleOptions?localeOptions ^-> T<string>
            |> WithComment "Return the formatted date string in the given format. The method uses `Intl.DateTimeFormat` inside. `formatOptions` are the same as `Intl.DateTimeFormat` options"
            "isAfter" => (T<Date> + Num)?date * (T<Date> + Num)?dateToCompare ^-> T<bool>
            |> WithComment "Is the first date after the second one?"
            "isBefore" => (T<Date> + Num)?date * (T<Date> + Num)?dateToCompare ^-> T<bool>
            |> WithComment "Is the first date before the second one?"
            "isDate" => T<obj>?value ^-> T<bool>
            |> WithComment "Returns true if the given value is an instance of Date. The function works for dates transferred across iframes"
            "isEqual" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> T<bool>
            |> WithComment "Are the given dates equal?"
            "isExists" => Num?year * Num?month * Num?day ^-> T<bool>
            |> WithComment "Checks if the given arguments convert to an existing date"
            "isFuture" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date in the future?"
            "isMatch" => T<string>?dateString * T<string>?formatString * !? IsMatchOptions?options ^-> T<bool>
            |> WithComment "Return the true if given date is string correct against the given format else will return false"
            "isPast" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date in the past?"
            "isValid" => T<obj>?date ^-> T<bool>
            |> WithComment "Returns false if argument is Invalid Date and true otherwise. Argument is converted to Date using `toDate`. See toDate Invalid Date is a Date, whose time value is NaN"
            "lightFormat" => (T<Date> + Num)?date * T<string>?format ^-> T<string>
            |> WithComment "Return the formatted date string in the given format. Unlike `format`, `lightFormat` doesn't use locales and outputs date using the most popular tokens"
            "max" => (!| T<Date> + !| Num)?datesArray ^-> T<Date>
            |> WithComment "Return the latest of the given dates"
            "min" => (!| T<Date> + !| Num)?datesArray ^-> T<Date>
            |> WithComment "Returns the earliest of the given dates"
            "parse" => T<string>?dateString * T<string>?formatString * (T<Date> + Num)?referenceDate * !? ParseOptions ^-> T<Date>
            |> WithComment "Return the date parsed from string using the given format string"
            "parseISO" => T<string>?argument * !? ParseISOOptions?options ^-> T<Date>
            |> WithComment "Parse the given string in ISO 8601 format and return an instance of Date"
            "parseJSON" => (T<string> + Num + T<Date>)?argument ^-> T<Date>
            |> WithComment "Converts a complete ISO date string in UTC time, the typical format for transmitting a date in JSON, to a JavaScript `Date` instance"
            "set" => (T<Date> + Num)?date * SetValues?values ^-> T<Date>
            |> WithComment "Set date values to a given date"
            "sub" => (T<Date> + Num)?date * Duration?duration ^-> T<Date>
            |> WithComment "Subtract the specified years, months, weeks, days, hours, minutes and seconds from the given date"
            "toDate" => (T<Date> + Num)?argument ^-> T<Date>
            |> WithComment "Convert the given argument to an instance of Date"
            // Conversion helpers
            "daysToWeeks" => Num?days ^-> Num
            |> WithComment "Convert a number of days to a full number of weeks"
            "hoursToMilliseconds" => Num?hours ^-> Num
            |> WithComment "Convert a number of hours to a full number of milliseconds"
            "hoursToMinutes" => Num?hours ^-> Num
            |> WithComment "Convert a number of hours to a full number of minutes"
            "hoursToSeconds" => Num?hours ^-> Num
            |> WithComment "Convert a number of hours to a full number of seconds"
            "millisecondsToHours" => Num?milliseconds ^-> Num
            |> WithComment "Convert a number of milliseconds to a full number of hours"
            "millisecondsToMinutes" => Num?milliseconds ^-> Num
            |> WithComment "Convert a number of milliseconds to a full number of minutes"
            "millisecondsToSeconds" => Num?milliseconds ^-> Num
            |> WithComment "Convert a number of milliseconds to a full number of seconds"
            "minutesToHours" => Num?minutes ^-> Num
            |> WithComment "Convert a number of minutes to a full number of hours"
            "minutesToMilliseconds" => Num?minutes ^-> Num
            |> WithComment "Convert a number of minutes to a full number of milliseconds"
            "minutesToSeconds" => Num?minutes ^-> Num
            |> WithComment "Convert a number of minutes to a full number of seconds"
            "monthsToQuarters" => Num?months ^-> Num
            |> WithComment "Convert a number of months to a full number of quarters"
            "monthsToYears" => Num?months ^-> Num
            |> WithComment "Convert a number of months to a full number of years"
            "quartersToMonths" => Num?quarters ^-> Num
            |> WithComment "Convert a number of quarters to a full number of months"
            "quartersToYears" => Num?quarters ^-> Num
            |> WithComment "Convert a number of quarters to a full number of years"
            "secondsToHours" => Num?seconds ^-> Num
            |> WithComment "Convert a number of seconds to a full number of hours"
            "secondsToMilliseconds" => Num?seconds ^-> Num
            |> WithComment "Convert a number of seconds to a full number of milliseconds"
            "secondsToMinutes" => Num?seconds ^-> Num
            |> WithComment "Convert a number of seconds to a full number of minutes"
            "weeksToDays" => Num?weeks ^-> Num
            |> WithComment "Convert a number of weeks to a full number of days"
            "yearsToMonths" => Num?years ^-> Num
            |> WithComment "Convert a number of years to a full number of months"
            "yearsToQuarters" => Num?years ^-> Num
            |> WithComment "Convert a number of years to a full number of quarters"
            // Interval helpers
            "areIntervalsOverlapping" => Interval?intervalLeft * Interval?intervalRight * !? AreIntervalsOverlappingOptions?options ^-> T<bool>
            |> WithComment "Is the given time interval overlapping with another time interval? Adjacent intervals do not count as overlapping"
            "clamp" => (T<Date> + Num)?date * Interval?interval ^-> T<Date>
            |> WithComment "Clamps a date to the lower bound with the start of the interval and the upper bound with the end of the interval"
            "eachDayOfInterval" => Interval?interval * !? EachDHMOfIntervalOptions?options ^-> !| T<Date>
            |> WithComment "Return the array of dates within the specified time interval"
            "eachHourOfInterval" => Interval?interval * !? EachDHMOfIntervalOptions?options ^-> !| T<Date>
            |> WithComment "Return the array of hours within the specified time interval"
            "eachMinuteOfInterval" => Interval?interval * !? EachDHMOfIntervalOptions?options ^-> !| T<Date>
            |> WithComment "Returns the array of minutes within the specified time interval"
            "eachMonthOfInterval" => Interval?interval ^-> !| T<Date>
            |> WithComment "Return the array of months within the specified time interval"
            "eachQuarterOfInterval" => Interval?interval ^-> !| T<Date>
            |> WithComment "Return the array of quarters within the specified time interval"
            "eachWeekOfInterval" => Interval?interval * !? EachWeekOfIntervalOptions?options ^-> !| T<Date>
            |> WithComment "Return the array of weeks within the specified time interval"
            "eachWeekendOfInterval" => Interval?interval ^-> !| T<Date>
            |> WithComment "Get all the Saturdays and Sundays in the given date interval"
            "eachYearOfInterval" => Interval?interval ^-> !| T<Date>
            |> WithComment "Return the array of yearly timestamps within the specified time interval"
            "getOverlappingDaysInIntervals" => Interval?intervalLeft * Interval?intervalRight ^-> !| Num
            |> WithComment "Get the number of days that overlap in two time intervals"
            "isWithinInterval" => (T<Date> + Num)?date * Interval?interval ^-> T<bool>
            |> WithComment "Is the given date within the interval? (Including start and end)"
            // Timestamp helpers
            "fromUnixTime" => Num?unixTime ^-> T<Date>
            |> WithComment "Create a date from a Unix timestamp"
            "getTime" => (T<Date> + Num)?date ^-> Num
            |> WithComment "Get the milliseconds timestamp of the given date"
            "getUnixTime" => (T<Date> + Num)?date ^-> Num
            |> WithComment "Get the seconds timestamp of the given date"
            // Millisecond helpers
            "addMilliseconds" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Add the specified number of milliseconds to the given date"
            "differenceInMilliseconds" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            |> WithComment "Get the number of milliseconds between the given dates"
            "getMilliseconds" => (T<Date> + Num)?date ^-> T<Date> 
            |> WithComment "Get the milliseconds of the given date"
            "milliseconds" => Duration?duration ^-> Num
            |> WithComment "Returns the number of milliseconds in the specified, years, months, weeks, days, hours, minutes and seconds"
            "setMilliseconds" => (T<Date> + Num)?date * Num?milliseconds ^-> T<Date>
            |> WithComment "Set the milliseconds to the given date"
            "subMilliseconds" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Subtract the specified number of milliseconds from the given date"
            // Second helpers
            "addSeconds" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Add the specified number of seconds to the given date"
            "differenceInSeconds" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            |> WithComment "Get the number of seconds between the given dates"
            "endOfSecond" => (T<Date> + Num)?date ^-> T<Date> 
            |> WithComment "Return the end of a second for the given date. The result will be in the local timezone"
            "getSeconds" => (T<Date> + Num)?date ^-> Num
            |> WithComment "Get the seconds of the given date"
            "isSameSecond" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> T<bool>
            |> WithComment "Are the given dates in the same second?"
            "isThisSecond" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date in the same second as the current date?"
            "setSeconds" => (T<Date> + Num)?date * Num?seconds ^-> T<Date>
            |> WithComment "Set the seconds to the given date"
            "startOfSecond" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "Return the start of a second for the given date. The result will be in the local timezone"
            "subSeconds" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Subtract the specified number of seconds from the given date"
            // Minute helpers
            "addMinutes" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Add the specified number of minutes to the given date"
            "differenceInMinutes" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            |> WithComment "Get the signed number of full (rounded towards 0) minutes between the given dates"
            "endOfMinute" => (T<Date> + Num)?date ^-> T<Date> 
            |> WithComment "Return the end of a minute for the given date. The result will be in the local timezone"
            "getMinutes" => (T<Date> + Num)?date ^-> Num
            |> WithComment "Get the minutes of the given date"
            "isSameMinute" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> T<bool>
            |> WithComment "Are the given dates in the same minute?"
            "isThisMinute" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date in the same minute as the current date?"
            "roundToNearestMinutes" => (T<Date> + Num)?date * !? RoundToNearestMinuteOptions?options ^-> T<Date>
            |> WithComment "Rounds the given date to the nearest minute (or number of minutes). Rounds up when the given date is exactly between the nearest round minutes"
            "setMinutes" => (T<Date> + Num)?date * Num?minutes ^-> T<Date>
            |> WithComment "Set the minutes to the given date"
            "startOfMinute" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "Return the start of a minute for the given date. The result will be in the local timezone"
            "subMinutes" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Subtract the specified number of minutes from the given date"
            // Hour helpers
            "addHours" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Add the specified number of hours to the given date"
            "differenceInHours" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            |> WithComment "Get the number of hours between the given dates"
            "endOfHour" => (T<Date> + Num)?date ^-> T<Date> 
            |> WithComment "Return the end of an hour for the given date. The result will be in the local timezone"
            "getHours" => (T<Date> + Num)?date ^-> Num
            |> WithComment "Get the hours of the given date"
            "isSameHour" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> T<bool>
            |> WithComment "Are the given dates in the same hour?"
            "isThisHour" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date in the same hour as the current date?"
            "setHours" => (T<Date> + Num)?date * Num?hours ^-> T<Date>
            |> WithComment "Set the hours to the given date"
            "startOfHour" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "Return the start of an hour for the given date. The result will be in the local timezone"
            "subHours" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Subtract the specified number of hours from the given date"
            // Day helpers
            "addBusinessDays" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Add the specified number of business days (mon - fri) to the given date, ignoring weekends"
            "addDays" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Add the specified number of days to the given date"
            "differenceInBusinessDays" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            |> WithComment "Get the number of business day periods between the given dates. Business days being days that arent in the weekend. Like `differenceInCalendarDays`, the function removes the times from the dates before calculating the difference"
            "differenceInCalendarDays" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            |> WithComment "Get the number of calendar days between the given dates. This means that the times are removed from the dates and then the difference in days is calculated"
            "differenceInDays" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            |> WithComment "Get the number of full day periods between two dates. Fractional days are truncated towards zero"
            "endOfDay" => (T<Date> + Num)?date ^-> T<Date> 
            |> WithComment "Return the end of a day for the given date. The result will be in the local timezone"
            "endOfToday" => T<unit> ^-> T<Date>
            |> ObsoleteWithMessage "Please note that this function is not present in the FP submodule as it uses `Date.now()` internally hence impure and can't be safely curried"
            "endOfTomorrow" => T<unit> ^-> T<Date>
            |> ObsoleteWithMessage "Please note that this function is not present in the FP submodule as it uses `Date.now()` internally hence impure and can't be safely curried"
            "endOfYesterday" => T<unit> ^-> T<Date>
            |> ObsoleteWithMessage "Please note that this function is not present in the FP submodule as it uses `Date.now()` internally hence impure and can't be safely curried"
            "getDate" => (T<Date> + Num)?date ^-> Num
            |> WithComment "Get the day of the month of the given date"
            "getDayOfYear" => (T<Date> + Num)?date ^-> Num
            |> WithComment "Get the day of the year of the given date"
            "isSameDay" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> T<bool>
            |> WithComment "Are the given dates in the same day?"
            "isToday" => (T<Date> + Num)?date ^-> T<bool>
            |> ObsoleteWithMessage "Please note that this function is not present in the FP submodule as it uses `Date.now()` internally hence impure and can't be safely curried"
            "isTomorrow" => (T<Date> + Num)?date ^-> T<bool>
            |> ObsoleteWithMessage "Please note that this function is not present in the FP submodule as it uses `Date.now()` internally hence impure and can't be safely curried"
            "isYesterday" => (T<Date> + Num)?date ^-> T<bool>
            |> ObsoleteWithMessage "Please note that this function is not present in the FP submodule as it uses `Date.now()` internally hence impure and can't be safely curried"
            "setDate" => (T<Date> + Num)?date * Num?dayOfMonth ^-> T<Date>
            |> WithComment "Set the day of the month to the given date"
            "setDayOfYear" => (T<Date> + Num)?date * Num?dayOfYear ^-> T<Date>
            |> WithComment "Set the day of the year to the given date"
            "startOfDay" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "Return the start of a day for the given date. The result will be in the local timezone"
            "startOfToday" => T<unit> ^-> T<Date>
            |> ObsoleteWithMessage "Please note that this function is not present in the FP submodule as it uses `Date.now()` internally hence impure and can't be safely curried"
            "startOfTomorrow" => T<unit> ^-> T<Date>
            |> ObsoleteWithMessage "Please note that this function is not present in the FP submodule as it uses `Date.now()` internally hence impure and can't be safely curried"
            "startOfYesterday" => T<unit> ^-> T<Date>
            |> ObsoleteWithMessage "Please note that this function is not present in the FP submodule as it uses `Date.now()` internally hence impure and can't be safely curried"
            "subBusinessDays" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Substract the specified number of business days (mon - fri) to the given date, ignoring weekends"
            "subDays" => (T<Date> + Num)?date * Num?amount ^-> T<Date>
            |> WithComment "Subtract the specified number of days from the given date"
            // Weekday helpers
            "getDay" => (T<Date> + Num)?date ^-> DayFromZero
            |> WithComment "Get the day of the week of the given date"
            "getISODay" => (T<Date> + Num)?date ^-> DayFromZero
            |> WithComment "Get the day of the ISO week of the given date, which is 7 for Sunday, 1 for Monday etc."
            "isFriday" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date Friday?"
            "isMonday" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date Monday?"
            "isSaturday" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date Saturday?"
            "isSunday" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date Sunday?"
            "isThursday" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date Thursday?"
            "isTuesday" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date Tuesday?"
            "isWednesday" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Is the given date Wednesday?"
            "isWeekend" => (T<Date> + Num)?date ^-> T<bool>
            |> WithComment "Does the given date fall on a weekend?"
            "nextDay" => (T<Date> + Num)?date * DayFromZero?day ^-> T<Date>
            |> WithComment "When is the next day of the week? 0-6 the day of the week, 0 represents Sunday"
            "nextFriday" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "When is the next Friday?"
            "nextMonday" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "When is the next Monday?"
            "nextSaturday" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "When is the next Saturday?"
            "nextSunday" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "When is the next Sunday?"
            "nextThursday" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "When is the next Thursday?"
            "nextTuesday" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "When is the next Tuesday?"
            "nextWednesday" => (T<Date> + Num)?date ^-> T<Date>
            |> WithComment "When is the next Wednesday?"
            "setDay" => (T<Date> + Num)?date * DayFromZero?day * !? SetDayOptions?options ^-> T<Date>
            |> WithComment "Set the day of the week to the given date"
            "setISODay" => (T<Date> + Num)?date * DayFromZero?day ^-> T<Date>
            |> WithComment "Set the day of the ISO week to the given date. ISO week starts with Monday. 7 is the index of Sunday, 1 is the index of Monday etc."
            // Week helpers
            // TODO
            // ISO Week helpers
            // TODO
            // Month helpers
            // TODO
            // Quarter helpers
            // TODO
            // Year helpers
            // TODO
            // ISO Week-Numbering Year helpers
            // TODO
            // Decade helpers
            // TODO
            // Week-Numbering Year helpers
            // TODO
        ]

    let Assembly =
        Assembly [
            // Namespace "WebSharper.DateFNS.Resource" [
            //     Resource "DateFNSCDN" "https://cdn.jsdelivr.net/npm/date-fns@2.23.0/index.min.js"
            //     |> AssemblyWide
            // ]
            Namespace "WebSharper.DateFNS" [
                Interval
                Localize
                FormatLong
                Match
                DayFromZero
                DayFromOne
                Options
                Locale
                Duration
                FormatOptions
                FormatDistanceOptions
                Unit
                RoundingMethod
                FormatDistanceStrictOptions
                FormatDurationOptions
                Format
                Representation
                FormatISOOptions
                FractionDigits
                FormatRFC3339Options
                FormatRelativeOptions
                LocaleMatcher
                IntlFormatRepresentation1
                IntlFormatRepresentation2
                IntlFormatRepresentation3
                IntlFormatRepresentation4
                FormatMatcher
                IntlFormatOptions
                IntlLocaleOptions
                IsMatchOptions
                ParseOptions
                AdditionalDigits
                ParseISOOptions
                SetValues
                AreIntervalsOverlappingOptions
                EachDHMOfIntervalOptions
                EachWeekOfIntervalOptions
                RoundToNearestMinuteOptions
                SetDayOptions
                DateFNS
            ]
        ]

[<Sealed>]
type Extension() =
    interface IExtension with
        member ext.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
