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

        IndexTemplate.Main()
            .FormatDate(
                Doc.Concat [
                    h2 [] [text "Date formating"]
                    p [] [text (DateFNS.Format(Date(2014, 1, 11), "MM/dd/yyyy"))]
                ]
            )
            .Doc()
        |> Doc.RunById "main"
