namespace WebSharper.DateFNS.Tests

open WebSharper
open WebSharper.JavaScript
open WebSharper.DateFNS

[<JavaScript>]
module Testing =

    type Chai =
        [<Name "assert">]
        abstract ``assert`` : Assert

    and [<Name "">] Assert =
        abstract equal: obj * obj -> unit

    type Mocha =
        [<Inline "$global.describe($category, $fn)">]
        static member describe (category: string, fn: (unit -> unit)) = X<unit>
        [<Inline "$global.it($testName, $fn)">]
        static member it(testName: string, fn: (unit -> unit)) = X<unit>

    let mocha () : Mocha = JS.ImportDefault "mocha"
    let chai () : Chai = JS.ImportDefault "chai"

[<JavaScript>]
module Tests =
    let Main () =
        let mocha = Testing.mocha ()
        let chai = Testing.chai ()
        Testing.Mocha.describe("DateFNS", fun () ->
            Testing.Mocha.describe("format", fun () ->
                Testing.Mocha.it("format as MM/dd/yyyy", fun () ->
                    let date = Date(2014, 0, 11)
                    chai.``assert``.equal(DateFNS.Format(date, "MM/dd/yyyy"), "01/12/2014")
                )   
            )
        )

    Main ()

