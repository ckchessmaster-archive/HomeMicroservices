const express = require('express');
const routes = require('./routes');
const config = require('./config');
const mongoose = require('mongoose');

const app = express();

start();

async function start() {
  // Setup mongodb
  console.log("Starting mongo connection...");
  try{
    await mongoose.connect(config.mongo);
    console.log('MongoDB connected!');
  } catch(err) {
    console.log('Error connecting to MongoDB: ' + err + ', exiting...');
    process.exit(1);
  }

  //start main application
  console.log('Starting express server...');
  app.use('/', routes);
  app.listen(config.port, config.host, () => console.log('Login API listening on port 9494!'));
}

module.exports = app;
