namespace WebSharper.DateFNS.Tests

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Html
open WebSharper.UI.Client
open WebSharper.UI.Templating
open WebSharper.DateFNS

[<JavaScript>]
module Client =
    // The templates are loaded from the DOM, so you just can edit index.html
    // and refresh your browser, no need to recompile unless you add or remove holes.
    type IndexTemplate = Template<"index.html", ClientLoad.FromDocument>

    [<SPAEntryPoint>]
    let Main () =
        let newName = Var.Create ""
        let date = DateFNS.Format(Date(2014, 1, 11), "MM/dd/yyyy")
        let nextD = DateFNS.NextDay(Date(), DayFromZero.``0``).ToString()
        let nextM = DateFNS.NextMonday(Date()).ToString()
        let formatOpt = FormatOptions()
        formatOpt.Locale <- Locales.JA
        let localeDate = DateFNS.Format(Date(), "MMM dd yyyy", formatOpt)
        let defaultDate = DateFNS.Format(Date(), "MMM dd yyyy")
        IndexTemplate.Main()
            .FormatDate(
                Doc.Concat [
                    h2 [] [text "Date formating"]
                    p [] [text date]
                ]
            )
            .NextDay(
                Doc.Concat [
                    h2 [] [text "Next Day (Sunday) test"]
                    p [] [text nextD]
                    h2 [] [text "Next Monday test"]
                    p [] [text nextM]
                ]
            )
            .LocaleTest(
                Doc.Concat [
                    h2 [] [text "Locale Test"]
                    p [] [text ("With default locale: " + defaultDate)]
                    p [] [text ("With Japanese locale: "+ localeDate)]
                ]
            )
            .Doc()
        |> Doc.RunById "main"
