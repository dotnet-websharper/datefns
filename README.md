# WebSharper.DateFNS

Provides `date-fns` bindings for [WebSharper](https://websharper.com/).

## date-fns sources

* Check [API documentation](https://date-fns.org/docs/Getting-Started)
* Check [date-fns GH](https://github.com/date-fns/date-fns)

## Examples

From the F# side, use `DateFNS` object:

```fsharp
let date = DateFNS.Format(Date(2014, 1, 11), "MM/dd/yyyy") // "02/11/2014"
```

You can use locales for example like this:

```fsharp
let formatOpt = FormatOptions()
formatOpt.Locale <- Locales.JA
let localeDate = DateFNS.Format(Date(2021, 7, 10), "MMM dd yyyy", formatOpt) // "8月 10 2021"
let defaultDate = DateFNS.Format(Date(2021, 7, 10), "MMM dd yyyy") // "Aug 10 2021"
```

Helper methods for different date kinds:

```fsharp
let b = DateFNS.IsLastDayOfMonth(Date(2021, 6, 31)) // true

let isT = DateFNS.IsTuesday(Date(2021, 7, 10)) // true

let diff = DateFNS.DifferenceInMinutes(
    Date(2014, 6, 2, 12, 20, 0),
    Date(2014, 6, 2, 12, 7, 59)) // 12
```

## Contributing

The case with date-fns is that we'd like to have a bundled JS version of it but since there we haven't found a CDN that like that we have to make it ourselves.

The following steps should help you make a bundled js version of both the main date-fns and its locales. If you find a better way to achieve all this, please update the README with a guide!

* clone the [date-fns repository](https://github.com/date-fns/date-fns)
* compile the project
* supposing the output is in the dist folder, use [rollup](https://rollupjs.org/guide/en/) to make a bundle. Now it might not be able to resolve everything when using `rollup dist/src/index.js --format iife --file output.js --name datefns`. You might need to use the `nodeResolve` plugin for it to work. Make a rollup config file for that. Example:

  ```js
  import { nodeResolve } from '@rollup/plugin-node-resolve';

  export default {
      input: 'dist/src/index.js',
      output: {
          file: 'output.js',
          format: 'iife',
          name: 'datefns'
      },
      plugins: [nodeResolve()]
  };
  ```
  

  With this do `rollup --config rollup.config.js`
* Use rollup on the locale files and put them into the `locales` folder
* Make sure to minify all js files
