var path = require('path');

module.exports = {
    context: path.join(__dirname, 'App'),
    entry: ['../main.jsx'],
    output: {
        path: path.join(__dirname, '..', 'Content', 'js'),
        publicPath: "/Content/js/",
        filename: "app.js",
        libraryTarget: "umd",
        library: "ReactNancyAspnetDemo"
    },
    module: {
        loaders: [
            {
                test: /\.jsx$/,
                loader: 'babel-loader',
                query: { presets: ['es2015', 'react'] }
            }, 
            {
                test: /\.css$/,
                loader: "style-loader!css-loader"
            }
        ]
    },
    resolve: {
        extensions: ['', '.js', '.jsx']
    }
};