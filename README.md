# WebSharper.DateFNS

* Check [API documentation](https://date-fns.org/docs/Getting-Started)
* Check [date-fns GH](https://github.com/date-fns/date-fns)

## Contributing

Since date-fns has no CDN version since 1.30.1 and what you can find are JS modules which WIG cannot handle, we have to make a bundled version ourselves.

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