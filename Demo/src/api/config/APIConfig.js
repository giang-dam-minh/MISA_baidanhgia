var APIConfig = {
    development: 'http://localhost:56094/api',
    production: 'local:8080'
}

export default APIConfig[process.env.NODE_ENV];