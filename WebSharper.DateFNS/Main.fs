namespace WebSharper.DateFNS

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
        Pattern.Config "Localize" {
            Required = []
            Optional = [
                "date", T<JavaScript.Function>
                "time", T<JavaScript.Function>
                "dateTime", T<JavaScript.Function>
            ]
        }

    let Match =
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
                "firstWeekContainsDate", T<bool>
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

    let DateFNS =
        Class "DateFNS"
        |+> Static [
            // Common helpers
            "add" => (T<Date> + Num)?date * Duration?duration ^-> T<Date>
            "closestIndexTo" => (T<Date> + Num)?dateToCompare * (!| T<Date> + !| Num)?datesArray ^-> Num
            "closestTo" => (T<Date> + Num)?dateToCompare * (!| T<Date> + !| Num)?datesArray ^-> T<Date>
            "compareAsc" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            "comparedesc" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> Num
            "format" => (T<Date> + Num)?date * T<string>?format * !? FormatOptions?options ^-> T<string>
            "formatDistance" => (T<Date> + Num)?date * (T<Date> + Num)?baseDate * !? FormatDistanceOptions?options ^-> T<string>
            "formatDistanceStrict" => (T<Date> + Num)?date * (T<Date> + Num)?baseDate * !? FormatDistanceStrictOptions?options ^-> T<string>
            "formatDistanceToNow" => (T<Date> + Num)?date * FormatDistanceOptions?options ^-> T<string>
            "formatDistanceToNowStrict" => (T<Date> + Num)?date * !? FormatDistanceStrictOptions?options ^-> T<string>
            "formatDuration" => Duration?duration * !? FormatDurationOptions?options ^-> T<string>
            "formatISO" => (T<Date> + Num)?date * !? FormatISOOptions?options ^-> T<string>
            "formatISO9075" => (T<Date> + Num)?date * !? FormatISOOptions?options ^-> T<string>
            "formatISODuration" => Duration?duration ^-> T<string>
            "formatRFC3339" => (T<Date> + Num)?date * !? FormatRFC3339Options?options ^-> T<string>
            "formatRFC7231" => (T<Date> + Num)?date ^-> T<string>
            "formatRelative" => (T<Date> + Num)?date * (T<Date> + Num)?baseDate * !? FormatRelativeOptions?options ^-> T<string>
            "intervalToDuration" => Interval?interval ^-> Duration
            "intlFormat" => (T<Date> + Num)?argument * !? IntlFormatOptions?formatOptions * !? IntlLocaleOptions?localeOptions ^-> T<string>
            "isAfter" => (T<Date> + Num)?date * (T<Date> + Num)?dateToCompare ^-> T<bool>
            "isBefore" => (T<Date> + Num)?date * (T<Date> + Num)?dateToCompare ^-> T<bool>
            "isDate" => T<obj>?value ^-> T<bool>
            "isEqual" => (T<Date> + Num)?dateLeft * (T<Date> + Num)?dateRight ^-> T<bool>
            "isExists" => Num?year * Num?month * Num?day ^-> T<bool>
            "isFuture" => (T<Date> + Num)?date ^-> T<bool>
            "isMatch" => T<string>?dateString * T<string>?formatString * !? IsMatchOptions?options ^-> T<bool>
            "isPast" => (T<Date> + Num)?date ^-> T<bool>
            "isValid" => T<obj>?date ^-> T<bool>
            "lightFormat" => (T<Date> + Num)?date * T<string>?format ^-> T<string>
            "max" => (!| T<Date> + !| Num)?datesArray ^-> T<Date>
            "min" => (!| T<Date> + !| Num)?datesArray ^-> T<Date>
            "parse" => T<string>?dateString * T<string>?formatString * (T<Date> + Num)?referenceDate * !? ParseOptions ^-> T<Date>
            "parseISO" => T<string>?argument * !? ParseISOOptions?options ^-> T<Date>
            "parseJSON" => (T<string> + Num + T<Date>)?argument ^-> T<Date>
            "set" => (T<Date> + Num)?date * SetValues?values ^-> T<Date>
            "sub" => (T<Date> + Num)?date * Duration?duration ^-> T<Date>
            "toDate" => (T<Date> + Num)?argument ^-> T<Date>
            // Conversion helpers
            // TODO
            // Interval helpers
            // TODO
            // Timestamp helpers
            // TODO
            // Millisecond helpers
            // TODO
            // Second helpers
            // TODO
            // Minute helpers
            // TODO
            // Hour helpers
            // TODO
            // Day helpers
            // TODO
            // Weekday helpers
            // TODO
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
            Namespace "WebSharper.DateFNS.Resource" [
                Resource "DateFNSCDN" "https://unpkg.com/date-fns@2.23.0/index.js"
                |> AssemblyWide
            ]
            Namespace "WebSharper.DateFFNS" [
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
