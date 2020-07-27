var path = require('path');

// Constant with our paths
const paths = {
    DIST: path.resolve(__dirname, 'public'),
    SRC: path.resolve(__dirname, 'src'),
};

module.exports = {
    devtool: 'source-map',
    mode: "development",
    entry: path.join(paths.SRC, 'index.js'),
    output: {
        path: paths.DIST,
        filename: 'app.bundle.js',
        publicPath: '/'
    },
    devServer: {
        historyApiFallback: true,
        contentBase: paths.SRC,
    },
    resolve: {
        extensions: ['*', '.js', '.jsx']
    },
    module: {
        rules: [
            {
                //test: /\.js$/,
                test: /\.jsx?$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-react', '@babel/preset-env']
                    }
                }
            },
            {
                test: /\.css$/i,
                use: ['style-loader', 'css-loader'],
                //use: ['css-loader']
            }
        ]
    }
}