const express = require('express');
const app = express();

const PORT = 9494;
const HOST = '0.0.0.0';

app.get('/', (req, res) => res.send('Hello World!'));

app.listen(PORT, HOST, () => console.log('Login API listening on port 9494!'));
