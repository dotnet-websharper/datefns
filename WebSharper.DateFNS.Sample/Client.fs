// date-fns date arguments are modeled as a union (Date | number | string); the
// implicit conversions to `Date` below are intentional.
#nowarn "3391"

namespace WebSharper.DateFNS.Sample

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Notation
open WebSharper.UI.Templating
open WebSharper.UI.Html
open WebSharper.DateFNS

[<JavaScript>]
module Client =

    type IndexTemplate = Template<"index.html", ClientLoad.FromDocument>

    // ------------------------------------------------------------------
    // Small helpers
    // ------------------------------------------------------------------

    let private truth (b: bool) = if b then "true" else "false"

    let private mkDate (y: int) (m: int) (d: int) = Date(y, m, d)
    let private mkDateTime (y: int) (m: int) (d: int) (h: int) (mi: int) (s: int) = Date(y, m, d, h, mi, s)

    // `DateFNS.Interval` is ambiguous (the `interval` function vs. the `Interval` type),
    // so qualify the function explicitly.
    let private iv (a: Date, b: Date) = WebSharper.DateFNS.DateFNS.Interval(a, b)

    let private ymd (d: Date) = DateFNS.Format(d, "yyyy-MM-dd")
    let private ymdhm (d: Date) = DateFNS.Format(d, "yyyy-MM-dd HH:mm")

    let private formatWith (locale: Locale) (d: Date) (fmt: string) =
        let o = FormatOptions()
        o.Locale <- locale
        DateFNS.Format(d, fmt, o)

    // ------------------------------------------------------------------
    // Assertion suite
    // ------------------------------------------------------------------

    type Check =
        {
            Group: string
            Name: string
            Expected: string
            Actual: string
        }

    let private chk group name expected actual =
        { Group = group; Name = name; Expected = expected; Actual = actual }

    let private runChecks () : Check list =
        [
            // --- Formatting -------------------------------------------------
            chk "Formatting" "format MM/dd/yyyy" "01/11/2014"
                (DateFNS.Format(mkDate 2014 0 11, "MM/dd/yyyy"))
            chk "Formatting" "format with the ja locale" "8月 10 2021"
                (formatWith Locales.JA (mkDate 2021 7 10) "MMM dd yyyy")
            chk "Formatting" "format with the default locale" "Aug 10 2021"
                (DateFNS.Format(mkDate 2021 7 10, "MMM dd yyyy"))
            chk "Formatting" "format accepts a string date" "02/11/2014"
                (DateFNS.Format("2014-02-11T00:00:00", "MM/dd/yyyy"))
            chk "Formatting" "lightFormat" "02/11/2014"
                (DateFNS.LightFormat(mkDate 2014 1 11, "MM/dd/yyyy"))
            chk "Formatting" "parseISO then format" "02/11/2014"
                (DateFNS.Format(DateFNS.ParseISO("2014-02-11"), "MM/dd/yyyy"))
            chk "Formatting" "parse then format" "02/11/2014"
                (DateFNS.Format(DateFNS.Parse("02/11/2014", "MM/dd/yyyy", mkDate 2014 0 1), "MM/dd/yyyy"))
            chk "Formatting" "formatISO (date representation)" "2014-02-11"
                (let o = FormatISOOptions()
                 o.Representation <- Representation.Date
                 DateFNS.FormatISO(mkDate 2014 1 11, o))
            chk "Formatting" "isMatch" "true"
                (truth (DateFNS.IsMatch("02/11/2014", "MM/dd/yyyy")))

            // --- Arithmetic -------------------------------------------------
            chk "Arithmetic" "addDays +10" "2021-01-11"
                (ymd (DateFNS.AddDays(mkDate 2021 0 1, 10)))
            chk "Arithmetic" "subDays -10" "2021-01-01"
                (ymd (DateFNS.SubDays(mkDate 2021 0 11, 10)))
            chk "Arithmetic" "addMonths clamps to month end" "2021-02-28"
                (ymd (DateFNS.AddMonths(mkDate 2021 0 31, 1)))
            chk "Arithmetic" "addYears on a leap day" "2021-02-28"
                (ymd (DateFNS.AddYears(mkDate 2020 1 29, 1)))
            chk "Arithmetic" "differenceInMinutes" "12"
                (string (DateFNS.DifferenceInMinutes(mkDateTime 2014 6 2 12 20 0, mkDateTime 2014 6 2 12 7 59)))
            chk "Arithmetic" "differenceInDays" "4"
                (string (DateFNS.DifferenceInDays(mkDate 2014 6 2, mkDate 2014 5 28)))
            chk "Arithmetic" "set replaces several fields at once" "2015-10-20"
                (let v = SetValues()
                 v.Year <- 2015
                 v.Month <- 9
                 v.Date <- 20
                 ymd (DateFNS.Set(mkDate 2014 8 20, v)))

            // --- Predicates -------------------------------------------------
            chk "Predicates" "isTuesday" "true"
                (truth (DateFNS.IsTuesday(mkDate 2021 7 10)))
            chk "Predicates" "isLastDayOfMonth" "true"
                (truth (DateFNS.IsLastDayOfMonth(mkDate 2021 6 31)))
            chk "Predicates" "isLeapYear" "true"
                (truth (DateFNS.IsLeapYear(mkDate 2020 0 1)))
            chk "Predicates" "isWeekend" "true"
                (truth (DateFNS.IsWeekend(mkDate 2021 7 7)))
            chk "Predicates" "isValid" "true"
                (truth (DateFNS.IsValid(mkDate 2021 0 1)))

            // --- Getters ----------------------------------------------------
            chk "Getters" "getDaysInMonth (Feb 2020)" "29"
                (string (DateFNS.GetDaysInMonth(mkDate 2020 1 1)))
            chk "Getters" "getISOWeek" "1"
                (string (DateFNS.GetISOWeek(mkDate 2021 0 4)))
            chk "Getters" "getWeekOfMonth" "2"
                (string (DateFNS.GetWeekOfMonth(mkDate 2021 7 10)))
            chk "Getters" "getDayOfYear" "32"
                (string (DateFNS.GetDayOfYear(mkDate 2021 1 1)))
            chk "Getters" "getQuarter" "2"
                (string (DateFNS.GetQuarter(mkDate 2021 4 1)))
            chk "Getters" "getISOWeekYear" "2021"
                (string (DateFNS.GetISOWeekYear(mkDate 2021 0 4)))
            chk "Getters" "nextMonday" "2021-08-16"
                (ymd (DateFNS.NextMonday(mkDate 2021 7 10)))
            chk "Getters" "previousFriday" "2021-08-06"
                (ymd (DateFNS.PreviousFriday(mkDate 2021 7 10)))
            chk "Getters" "startOfDay" "2021-08-10"
                (ymd (DateFNS.StartOfDay(mkDate 2021 7 10)))
            chk "Getters" "endOfMonth" "2021-02-28"
                (ymd (DateFNS.EndOfMonth(mkDate 2021 1 10)))
            chk "Getters" "endOfYear" "2021-12-31"
                (ymd (DateFNS.EndOfYear(mkDate 2021 7 10)))

            // --- Intervals --------------------------------------------------
            chk "Intervals" "eachDayOfInterval length" "5"
                (string (DateFNS.EachDayOfInterval(iv(mkDate 2021 0 1, mkDate 2021 0 5)).Length))
            chk "Intervals" "eachMonthOfInterval with step 2" "2"
                (let o = EachDayOfIntervalOptions()
                 o.Step <- 2
                 string (DateFNS.EachMonthOfInterval(iv(mkDate 2021 0 1, mkDate 2021 3 1), o).Length))
            chk "Intervals" "eachWeekendOfMonth (Aug 2021)" "9"
                (string (DateFNS.EachWeekendOfMonth(mkDate 2021 7 1)).Length)
            chk "Intervals" "eachWeekOfInterval length" "6"
                (string (DateFNS.EachWeekOfInterval(iv(mkDate 2021 0 1, mkDate 2021 0 31)).Length))
            chk "Intervals" "eachQuarterOfInterval length" "4"
                (string (DateFNS.EachQuarterOfInterval(iv(mkDate 2021 0 1, mkDate 2021 11 31)).Length))
            chk "Intervals" "eachYearOfInterval length" "3"
                (string (DateFNS.EachYearOfInterval(iv(mkDate 2019 0 1, mkDate 2021 11 31)).Length))
            chk "Intervals" "areIntervalsOverlapping" "true"
                (truth (DateFNS.AreIntervalsOverlapping(iv(mkDate 2021 0 1, mkDate 2021 0 5), iv(mkDate 2021 0 3, mkDate 2021 0 9))))
            chk "Intervals" "isWithinInterval" "true"
                (truth (DateFNS.IsWithinInterval(mkDate 2021 0 3, iv(mkDate 2021 0 1, mkDate 2021 0 5))))
            chk "Intervals" "clamp" "2021-01-05"
                (ymd (DateFNS.Clamp(mkDate 2021 0 10, iv(mkDate 2021 0 1, mkDate 2021 0 5))))
            chk "Intervals" "getOverlappingDaysInIntervals" "2"
                (string (DateFNS.GetOverlappingDaysInIntervals(iv(mkDate 2021 0 1, mkDate 2021 0 5), iv(mkDate 2021 0 3, mkDate 2021 0 9))))
            chk "Intervals" "interval normalizes start and end" "2021-01-01..2021-01-05"
                (let i = iv(mkDate 2021 0 1, mkDate 2021 0 5)
                 ymd i.Start + ".." + ymd i.End)
            chk "Intervals" "intervalToDuration" "3"
                (string (DateFNS.IntervalToDuration(iv(mkDate 2021 0 1, mkDate 2021 3 1)).Months))

            // --- Durations --------------------------------------------------
            chk "Durations" "formatDuration" "9 months 2 days"
                (let d = Duration()
                 d.Months <- 9
                 d.Days <- 2
                 DateFNS.FormatDuration d)
            chk "Durations" "formatDuration with zero = true" "0 years 9 months"
                (let d = Duration()
                 d.Years <- 0
                 d.Months <- 9
                 let o = FormatDurationOptions()
                 o.Zero <- true
                 DateFNS.FormatDuration(d, o))
            chk "Durations" "formatDuration with format and delimiter" "9 months, 3 weeks"
                (let d = Duration()
                 d.Years <- 2
                 d.Months <- 9
                 d.Weeks <- 3
                 let o = FormatDurationOptions()
                 o.Format <- [| DurationUnit.Months; DurationUnit.Weeks |]
                 o.Delimiter <- ", "
                 DateFNS.FormatDuration(d, o))
            chk "Durations" "formatDistanceStrict" "2 days"
                (DateFNS.FormatDistanceStrict(mkDate 2021 0 3, mkDate 2021 0 1))
            chk "Durations" "formatDistanceStrict with a forced unit" "48 hours"
                (let o = FormatDistanceStrictOptions()
                 o.Unit <- FormatDistanceStrictUnit.Hour
                 DateFNS.FormatDistanceStrict(mkDate 2021 0 3, mkDate 2021 0 1, o))
            chk "Durations" "intlFormatDistance (en-US)" "tomorrow"
                (let o = IntlFormatDistanceOptions()
                 o.Locale <- "en-US"
                 DateFNS.IntlFormatDistance(mkDate 2021 0 2, mkDate 2021 0 1, o))

            // --- Conversions ------------------------------------------------
            chk "Conversions" "daysToWeeks" "1"
                (string (DateFNS.DaysToWeeks(7)))
            chk "Conversions" "yearsToMonths" "24"
                (string (DateFNS.YearsToMonths(2)))
            chk "Conversions" "yearsToDays" "365"
                (string (DateFNS.YearsToDays(1)))
            chk "Conversions" "hoursToMinutes" "120"
                (string (DateFNS.HoursToMinutes(2)))
            chk "Conversions" "monthsToQuarters" "2"
                (string (DateFNS.MonthsToQuarters(6)))

            // --- Rounding ---------------------------------------------------
            chk "Rounding" "roundToNearestMinutes" "12:35"
                (DateFNS.Format(DateFNS.RoundToNearestMinutes(mkDateTime 2014 6 10 12 34 56), "HH:mm"))
            chk "Rounding" "roundToNearestHours" "13:00"
                (DateFNS.Format(DateFNS.RoundToNearestHours(mkDateTime 2014 6 10 12 34 56), "HH:mm"))

            // --- Misc -------------------------------------------------------
            chk "Misc" "max" "2021-01-05"
                (ymd (DateFNS.Max([| mkDate 2021 0 1; mkDate 2021 0 5 |])))
            chk "Misc" "min" "2021-01-01"
                (ymd (DateFNS.Min([| mkDate 2021 0 1; mkDate 2021 0 5 |])))
            chk "Misc" "compareAsc" "1"
                (string (DateFNS.CompareAsc(mkDate 2021 0 5, mkDate 2021 0 1)))
            chk "Misc" "closestIndexTo" "0"
                (string (DateFNS.ClosestIndexTo(mkDate 2021 0 3, [| mkDate 2021 0 1; mkDate 2021 0 5 |])))
            chk "Misc" "addDays accepts a string date" "2021-01-11"
                (ymd (DateFNS.AddDays("2021-01-01T00:00:00", 10)))
            chk "Misc" "isAfter accepts string dates" "true"
                (truth (DateFNS.IsAfter("2021-01-05", "2021-01-01")))
            chk "Misc" "constructFrom" "2021-06-15"
                (ymd (DateFNS.ConstructFrom(mkDate 2021 0 1, mkDate 2021 5 15)))

            // --- Locales ----------------------------------------------------
            chk "Locales" "enUS.code" "en-US" Locales.ENUS.Code
            chk "Locales" "ja.code" "ja" Locales.JA.Code
            chk "Locales" "beTarask.code (hyphenated id)" "be-tarask" Locales.BETARASK.Code
            chk "Locales" "ckb.code (new in date-fns 4)" "ckb" Locales.CKB.Code
            chk "Locales" "se.code (new in date-fns 4)" "se" Locales.SE.Code
        ]

    // ------------------------------------------------------------------
    // Rendering
    // ------------------------------------------------------------------

    let private checkRow (c: Check) =
        let ok = c.Expected = c.Actual
        tr [Attr.Create "class" (if ok then "row ok" else "row fail")] [
            td [Attr.Create "class" "name"] [text c.Name]
            td [] [code [] [text c.Expected]]
            td [] [code [] [text c.Actual]]
            td [] [span [Attr.Create "class" (if ok then "badge ok" else "badge fail")] [text (if ok then "pass" else "fail")]]
        ]

    let private testsPage () =
        let results = runChecks ()
        let total = results.Length
        let passed = results |> List.filter (fun c -> c.Expected = c.Actual) |> List.length
        let groups = results |> List.groupBy (fun c -> c.Group)
        div [] [
            header [Attr.Create "class" "page-head"] [
                h2 [] [text "Assertion suite"]
                p [Attr.Create "class" "lede"] [
                    text "Every call below is executed in this browser against the date-fns 4 binding, and the result is compared with a known value."
                ]
                span [Attr.Create "class" (if passed = total then "summary ok" else "summary fail")] [
                    text (sprintf "%d / %d assertions passed" passed total)
                ]
            ]
            yield! (groups |> List.map (fun (group, checks) ->
                section [Attr.Create "class" "group"] [
                    h3 [] [text group]
                    table [Attr.Create "class" "results"] [
                        thead [] [
                            tr [] [
                                th [] [text "Assertion"]
                                th [] [text "Expected"]
                                th [] [text "Actual"]
                                th [] [text "Result"]
                            ]
                        ]
                        tbody [] (checks |> List.map checkRow)
                    ]
                ]))
        ]

    // ------------------------------------------------------------------
    // Demo page
    // ------------------------------------------------------------------

    let private demoLocales =
        [ "en-US"; "en-GB"; "de"; "fr"; "ja"; "ar"; "zh-CN"; "be-tarask"; "ckb"; "se" ]

    let private localeOf (id: string) =
        match id with
        | "en-GB" -> Locales.ENGB
        | "de" -> Locales.DE
        | "fr" -> Locales.FR
        | "ja" -> Locales.JA
        | "ar" -> Locales.AR
        | "zh-CN" -> Locales.ZHCN
        | "be-tarask" -> Locales.BETARASK
        | "ckb" -> Locales.CKB
        | "se" -> Locales.SE
        | _ -> Locales.ENUS

    let private demDate = Var.Create "2021-08-10"
    let private demFormat = Var.Create "PPPP"
    let private demLocale = Var.Create "en-US"
    let private demStart = Var.Create "2021-08-01"
    let private demEnd = Var.Create "2021-08-31"
    let private demMoment = Var.Create "2021-08-10T13:24"
    let private demNearest = Var.Create "15"

    let private parseOr (s: string) (fallback: Date) =
        let d = DateFNS.ParseISO(s)
        if DateFNS.IsValid(d) then d else fallback

    let private nearestOf (s: string) =
        if s = "5" then 5
        elif s = "10" then 10
        elif s = "30" then 30
        else 15

    let private formatOutput =
        View.Map3
            (fun (ds: string) (fmt: string) (lid: string) ->
                formatWith (localeOf lid) (parseOr ds (mkDate 2021 7 10)) fmt)
            demDate.View demFormat.View demLocale.View

    let private relativeOutput =
        demDate.View
        |> View.Map (fun (ds: string) ->
            let o = FormatDistanceOptions()
            o.AddSuffix <- true
            DateFNS.FormatDistanceToNow(parseOr ds (mkDate 2021 7 10), o))

    let private intervalOutput =
        View.Map2
            (fun (a: string) (b: string) ->
                let ivl = iv(parseOr a (mkDate 2021 7 1), parseOr b (mkDate 2021 7 31))
                let days = DateFNS.EachDayOfInterval(ivl).Length
                let dur = DateFNS.FormatDuration(DateFNS.IntervalToDuration(ivl))
                sprintf "%d days · %s" days dur)
            demStart.View demEnd.View

    let private roundingOutput =
        View.Map2
            (fun (ms: string) (n: string) ->
                let o = RoundToNearestMinuteOptions()
                o.NearestTo <- nearestOf n
                ymdhm (DateFNS.RoundToNearestMinutes(parseOr ms (mkDate 2021 7 10), o)))
            demMoment.View demNearest.View

    let private dateField (caption: string) (v: Var<string>) =
        div [Attr.Create "class" "field"] [
            label [] [text caption]
            Doc.InputType.Date [Attr.Create "class" "control"] v
        ]

    let private textField (caption: string) (v: Var<string>) =
        div [Attr.Create "class" "field"] [
            label [] [text caption]
            Doc.InputType.Text [Attr.Create "class" "control"] v
        ]

    let private card (title: string) (hint: string) (body: Doc) =
        section [Attr.Create "class" "card"] [
            h3 [] [text title]
            p [Attr.Create "class" "hint"] [text hint]
            body
        ]

    let private outputFor (v: View<string>) =
        div [Attr.Create "class" "output"] [textView v]

    let private demoPage () =
        div [] [
            header [Attr.Create "class" "page-head"] [
                h2 [] [text "Interactive demo"]
                p [Attr.Create "class" "lede"] [
                    text "Change the fields below — every result is computed live by the date-fns 4 binding running in this page."
                ]
            ]
            div [Attr.Create "class" "cards"] [
                card "Format" "Format a date with Unicode tokens, in any supported locale." (
                    div [] [
                        div [Attr.Create "class" "field-row"] [
                            dateField "Date" demDate
                            textField "Format tokens" demFormat
                            div [Attr.Create "class" "field"] [
                                label [] [text "Locale"]
                                Doc.InputType.Select [Attr.Create "class" "control"] (fun (s: string) -> s) demoLocales demLocale
                            ]
                        ]
                        outputFor formatOutput
                    ])
                card "Relative time" "Format the distance between a date and now in words." (
                    div [] [
                        div [Attr.Create "class" "field-row"] [
                            dateField "Date" demDate
                        ]
                        outputFor relativeOutput
                    ])
                card "Intervals" "Count days and describe the duration between two dates." (
                    div [] [
                        div [Attr.Create "class" "field-row"] [
                            dateField "Start" demStart
                            dateField "End" demEnd
                        ]
                        outputFor intervalOutput
                    ])
                card "Rounding" "Round a date and time to the nearest 5, 10, 15 or 30 minutes." (
                    div [] [
                        div [Attr.Create "class" "field-row"] [
                            div [Attr.Create "class" "field"] [
                                label [] [text "Date and time"]
                                Doc.InputType.Text [Attr.Create "class" "control"; Attr.Create "type" "datetime-local"] demMoment
                            ]
                            div [Attr.Create "class" "field mid"] [
                                label [] [text "Nearest"]
                                Doc.InputType.Select [Attr.Create "class" "control"] (fun (s: string) -> s) [ "5"; "10"; "15"; "30" ] demNearest
                            ]
                        ]
                        outputFor roundingOutput
                    ])
                card "Generic helpers" "The generic helpers keep working with plain Date values." (
                    div [] [
                        div [Attr.Create "class" "output"] [
                            text "transpose(date, Date) = "
                            text (ymd (DateFNS.Transpose(mkDate 2021 0 1, mkDate 2021 0 1)))
                        ]
                        div [Attr.Create "class" "output"] [
                            text "constructNow(date) = "
                            text (ymdhm (DateFNS.ConstructNow(mkDate 2021 0 1)))
                        ]
                    ])
            ]
        ]

    // ------------------------------------------------------------------
    // Shell
    // ------------------------------------------------------------------

    let private theme = Var.Create "light"
    let private page = Var.Create "tests"

    let private setTheme (t: string) =
        theme := t
        JS.Document.DocumentElement.SetAttribute("data-theme", t)

    let private navDoc (p: string) =
        div [Attr.Create "class" "nav"] [
            Doc.Button "Tests" [Attr.Create "class" (if p = "tests" then "tab active" else "tab")] (fun () -> page := "tests")
            Doc.Button "Demo" [Attr.Create "class" (if p = "demo" then "tab active" else "tab")] (fun () -> page := "demo")
            Doc.Button "Toggle theme" [Attr.Create "class" "ghost"] (fun () ->
                if theme.Get() = "light" then setTheme "dark" else setTheme "light")
        ]

    let private pageView =
        page.View
        |> View.Map (fun p -> if p = "demo" then demoPage () else testsPage ())

    [<SPAEntryPoint>]
    let Main () =
        JS.Document.DocumentElement.SetAttribute("data-theme", theme.Get())
        IndexTemplate()
            .Nav(Doc.EmbedView (page.View |> View.Map navDoc))
            .Page(Doc.EmbedView pageView)
            .Bind()
